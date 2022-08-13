using Core.Entities.Concrete;

namespace Entities.Concrete;

public class ReservationRequest : BaseEntity
{
    public Train Train { get; set; }
    public int PassengerCount { get; set; }
    public bool SeperatedVagon { get; set; } = false;
}
