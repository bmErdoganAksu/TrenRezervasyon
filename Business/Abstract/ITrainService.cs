using Entities.Concrete;

namespace Business.Abstract;

public interface ITrainService
{
    Task<List<Train>> GetTrains();
    Task<Train> GetTrain(int trainId);
    Task<Train> AddAsync(Train train);
}
