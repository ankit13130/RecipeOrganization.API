namespace RecipeOrganization.Infrastructure.Domain.Entities;

public class Audit
{
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
}
