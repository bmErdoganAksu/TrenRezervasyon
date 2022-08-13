using Core.Entities.Concrete;

namespace Entities.Concrete;

public class Train : BaseEntity
{
    public string Name { get; set; }
    public List<Vagon> Vagons { get; set; }
}
