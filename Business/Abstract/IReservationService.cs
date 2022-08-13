using Entities.Concrete;

namespace Business.Abstract;

public interface IReservationService
{
    Task<CheckResponse> CheckReservation(ReservationRequest reservationRequest);
}
