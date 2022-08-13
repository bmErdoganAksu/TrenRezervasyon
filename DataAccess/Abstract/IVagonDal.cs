using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IVagonDal
{
    Task<Vagon> AddAsync(Vagon vagon);
    Task<Vagon> UpdateAsync(Vagon vagon);
    Task<Vagon> DeleteAsync(int id);
}
