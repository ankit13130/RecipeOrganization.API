using AutoMapper;
using RecipeOrganization.Core.Contract;
using RecipeOrganization.Core.Domain.CustomExceptions;
using RecipeOrganization.Core.Domain.RequestModels;
using RecipeOrganization.Core.Domain.ResponseModels;
using RecipeOrganization.Infrastructure.Contract;
using RecipeOrganization.Infrastructure.Domain.Entities;

namespace RecipeOrganization.Core.Services;

public class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserServices(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    //public async Task AddUser(UserRequestModel userRequestModel)
    //{
    //    EncryptionDecryption encryptionDecryption = new EncryptionDecryption();
    //    string hash = encryptionDecryption.HashPasword(userRequestModel.Password,out var salt);
    //    var user = UserBuilder.Build(userRequestModel, hash, Convert.ToHexString(salt));
    //    await _userRepository.AddUser(user);
    //}

    public async Task UpdateUser(UserRequestModel userRequestModel, long sid)
    {
        await _userRepository.UpdateUser(_mapper.Map<User>(userRequestModel),sid);
    }

    public async Task DeleteUser(long userId, long sid)
    {
        var user = _userRepository.GetUser(userId);
        if (user == null)
            throw new NotFoundException("User Not Found");
        await _userRepository.DeleteUser(user.Result,sid);
    }

    public async Task<UserResponseModel> GetUser(long userId)
    {
        var user = await _userRepository.GetUser(userId);
        if (user == null)
            throw new NotFoundException("User Not Found");
        return _mapper.Map<UserResponseModel>(user);
    }

    public async Task<ICollection<UserResponseModel>> GetUsers()
    {
        return _mapper.Map<IList<UserResponseModel>>(await _userRepository.GetUsers());
    }
}
