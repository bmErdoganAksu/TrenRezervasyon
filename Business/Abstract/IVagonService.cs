using Entities.Concrete;

namespace Business.Abstract;

public interface IVagonService
{
    Task<Vagon> AddAsync(Vagon vagon);
    Task<Vagon> UpdateAsync(Vagon vagon);
    Task<Vagon> DeleteAsync(int id);
}
