using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RecipeOrganization.Core.Builder;
using RecipeOrganization.Core.Contract;
using RecipeOrganization.Core.Domain.EncryptDecrypt;
using RecipeOrganization.Core.Domain.RequestModels;
using RecipeOrganization.Infrastructure.Contract;
using RecipeOrganization.Infrastructure.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RecipeOrganization.Core.Services;

public class ValidationServices : IValidationServices
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    public ValidationServices(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }
    //helper methods
    private User AuthenticateUser(LoginRequestModel loginRequestModel)
    {
        EncryptionDecryption encryptionDecryption = new EncryptionDecryption();
        User user = _userRepository.GetUser(loginRequestModel.Email).Result;

        if (user == null || !user.IsActive)
            throw new Exception("User Not Found");

        if (!encryptionDecryption.VerifyPassword(loginRequestModel.Password, user.Hash, Convert.FromHexString(user.Salt)))
            throw new Exception("Wrong Password");

        return user;
    }
    private string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Sid,user.UserId.ToString()),
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.Role,user.Role),
        };

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(1),
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    //[AllowAnonymous]

    public async Task<string> ValidateLoginAsync(LoginRequestModel loginRequestModel)
    {
        string response = null;
        var student = AuthenticateUser(loginRequestModel);
        if (student != null)
        {
            var tokenString = GenerateToken(student);
            response = tokenString;
        }
        return response;
    }
    public async Task ValidateSignupAsync(UserRequestModel userRequestModel)
    {
        if (_userRepository.GetUser(userRequestModel.Email).Result != null)
        {
            throw new Exception("User Already Exists");
        }
        
        EncryptionDecryption encryptDecrypt = new EncryptionDecryption();
        string Hash = encryptDecrypt.HashPasword(userRequestModel.Password, out var salt);
        string Salt = Convert.ToHexString(salt);

        //image upload
        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(userRequestModel.UserImage.FileName);
        Directory.CreateDirectory("UserProfile");
        string path = Path.Combine(Environment.CurrentDirectory, @"UserProfile\", fileName);
        using (var stream = new FileStream(path, FileMode.Create,FileAccess.ReadWrite))
        {
            userRequestModel.UserImage.CopyToAsync(stream);
        }

        User user = UserBuilder.Build(userRequestModel, Hash, Salt,path);

        await _userRepository.AddUser(user);
    }
}
