namespace RecipeOrganization.Infrastructure.Domain.Entities;

public class Recipe : Audit
{
    public long RecipeId { get; set; }
    public string RecipeName { get; set;}
    public string RecipeDescription { get; set;}
    public string CookTime { get; set;}
    public string Ingredients { get; set;}
    public string Instructions { get; set;}
    public string RecipeImage { get; set;}
    public long UserId { get; set;}
    public long CategoryId { get; set;}
    public User User { get; set;}
}
