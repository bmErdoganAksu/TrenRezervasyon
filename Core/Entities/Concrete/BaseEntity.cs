using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class BaseEntity : IEntity
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
