using DataAccess.Abstract;
using DataAccess.Configuration;
using Entities.Concrete;

namespace DataAccess.Concrete;

public class VagonDal : IVagonDal
{
    private readonly TrainContext _context;

    public VagonDal(TrainContext context)
    {
        _context = context;
    }

    public async Task<Vagon> AddAsync(Vagon vagon)
    {
        await _context.Vagons.AddAsync(vagon);
        var result = await _context.SaveChangesAsync();
        return vagon;
    }

    public Task<Vagon> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Vagon> UpdateAsync(Vagon vagon)
    {
        throw new NotImplementedException();
    }
}
