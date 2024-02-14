namespace RecipeOrganization.Infrastructure.Domain.Entities;

public class Review : Audit
{
    public long ReviewId { get; set; }
    public string Comment { get; set;}
    public decimal Rating { get; set;}
    public long UserId { get; set; }
    public long RecipeId { get; set; }
}
