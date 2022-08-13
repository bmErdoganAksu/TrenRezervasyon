using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete;

public class ReservationService : IReservationService
{
    private readonly ITrainDal _trainDal;

    public ReservationService(ITrainDal trainDal)
    {
        _trainDal = trainDal;
    }

    public async Task<CheckResponse> CheckReservation(ReservationRequest reservationRequest)
    {
        var train = await _trainDal.Get(reservationRequest.Train.Id);
        if (train is null || !(train.Vagons.Count > 0)) throw new Exception("Sefer Mevcut Değil!");
        var listedVagons = train.Vagons.Distinct().OrderByDescending(s => s.Capacity - s.RentedSeatCount).ToList();
        if (!reservationRequest.SeperatedVagon)
        {
            var vagonCount = getVagonAvailableCount(listedVagons[0]);
            if (vagonCount < reservationRequest.PassengerCount)
                return new();
            else return new()
            {
                VagonReservationOffers = new() { new() { VagonName = listedVagons[0].Name, PassengerCount = reservationRequest.PassengerCount } }
            };
        }
        else
        {
            var trainAvailableCount = 0;
            foreach (var vagon in listedVagons)
            {
                trainAvailableCount += getVagonAvailableCount(vagon);
            }
            if (trainAvailableCount < reservationRequest.PassengerCount)
                return new();
            //throw new Exception("Bu trende bu kadar yer yok!");
            else
            {
                var restPassengerCount = reservationRequest.PassengerCount;
                var selectedVagons = new List<VagonReservationOffer>();
                foreach (var v in listedVagons)
                {
                    var availableCount = getVagonAvailableCount(v);
                    if (availableCount >= restPassengerCount)
                    {
                        selectedVagons.Add(new() { VagonName = v.Name, PassengerCount = restPassengerCount });
                        break;
                    }
                    else
                    {
                        restPassengerCount -= availableCount;
                        selectedVagons.Add(new() { VagonName = v.Name, PassengerCount = availableCount });
                    }
                }


                return new() { VagonReservationOffers = selectedVagons, IsAvailable = selectedVagons.Count > 0 };
            }
        }
    }
    // ---------- BUSINESS RULES

    private int getVagonAvailableCount(Vagon vagon)
    {
        var data = (vagon.Capacity * 70 / 100) - vagon.RentedSeatCount;
        return (data < 0) ? 0 : data;
    }
}
