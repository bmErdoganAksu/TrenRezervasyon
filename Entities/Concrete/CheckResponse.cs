using Core.Entities.Concrete;

namespace Entities.Concrete;

public class CheckResponse : BaseEntity
{
    public bool IsAvailable { get; set; } = false;
    public List<VagonReservationOffer> VagonReservationOffers { get; set; } = new();
}
