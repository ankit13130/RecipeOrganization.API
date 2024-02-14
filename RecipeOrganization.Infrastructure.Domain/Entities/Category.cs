namespace RecipeOrganization.Infrastructure.Domain.Entities;

public class Category : Audit
{
    public long CategoryId { get; set; }
    public string CategoryName { get; set; }
}
