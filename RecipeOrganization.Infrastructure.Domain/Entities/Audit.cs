namespace RecipeOrganization.Infrastructure.Domain.Entities;

public class Audit
{
    public bool IsActive { get; set; } = true;
    public long CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public long UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public long DeletedBy { get; set; }
    public DateTime? DeletedOn { get; set; }
}
