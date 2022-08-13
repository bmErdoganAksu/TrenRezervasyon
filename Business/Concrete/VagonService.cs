using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class VagonService : IVagonService
{
    private readonly IVagonDal _vagonDal;

    public VagonService(IVagonDal vagonDal)
    {
        _vagonDal = vagonDal;
    }

    public async Task<Vagon> AddAsync(Vagon vagon)
    {
        var result = await _vagonDal.AddAsync(vagon);
        return result;
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
