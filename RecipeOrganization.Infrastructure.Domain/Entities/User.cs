using System.Security.Claims;

namespace RecipeOrganization.Infrastructure.Domain.Entities;

public class User : Audit
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string Hash { get; set; }
    public string Salt { get; set; }
    public string Email { get; set; }
    public string UserImage { get; set; }
    public string Role { get; set; }
    public IList<Recipe> Recipes { get; set; }
    protected User() { }
    public User(string userName, string hash, string salt, string email,string userImage)
    {
        UserName = userName;
        Hash = hash;
        Salt = salt;
        Email = email;
        UserImage = userImage;
        Role = "user";
        IsActive = true;
        CreatedOn = DateTime.UtcNow;
    }
}
