using Core.Entities.Concrete;

namespace Entities.Concrete;

public class VagonReservationOffer : BaseEntity
{
    public string VagonName { get; set; }
    public int PassengerCount { get; set; }
}
