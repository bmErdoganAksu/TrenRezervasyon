using Core.Entities.Concrete;

namespace Entities.Concrete;

public class Vagon : BaseEntity
{
    public string Name{ get; set; }
    public int Capacity { get; set; }
    public int RentedSeatCount { get; set; }

    public int TrainId { get; set; }
    //public virtual Train Train { get; set; }
}
