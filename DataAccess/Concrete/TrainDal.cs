using DataAccess.Abstract;
using DataAccess.Configuration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class TrainDal : ITrainDal
{
    private readonly TrainContext _context;

    public TrainDal(TrainContext context)
    {
        _context = context;
    }

    public async Task<Train> Add(Train train)
    {
        await _context.Trains.AddAsync(train);
        var result = await _context.SaveChangesAsync();
        return train;
    }

    public async Task<Train> Get(int id)
    {
        var train = await _context.Trains.Where(s=>s.Id == id).Include(s=>s.Vagons).FirstOrDefaultAsync();
        return train;
    }

    public async Task<List<Train>> GetAll()
    {
        var trains = await _context.Trains.Include(s=>s.Vagons).ToListAsync();
        return trains;
    }
}