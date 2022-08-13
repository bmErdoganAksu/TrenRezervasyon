using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class TrainService : ITrainService
{
    private readonly ITrainDal _trainDal;

    public TrainService(ITrainDal trainDal)
    {
        _trainDal = trainDal;
    }

    public async Task<Train> AddAsync(Train train)
    {
        var result = await _trainDal.Add(train);
        return result;
    }

    public async Task<Train> GetTrain(int trainId)
    {
        var train = await _trainDal.Get(trainId);
        return train;
    }

    public async Task<List<Train>> GetTrains()
    {
        var trains = await _trainDal.GetAll();
        return trains;
    }
}
