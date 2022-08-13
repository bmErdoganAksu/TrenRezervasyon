using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ITrainDal
{
    Task<List<Train>> GetAll();
    Task<Train> Get(int id);
    Task<Train> Add(Train train);

}
