using Spodify.DataAccess.ViewModels;
using Spodify.Domain.Entities;

namespace Spodify.DataAccess.Interfaces
{
    public interface IMusicRepository
    {
        Task<MusicViewModel> GetById(int id);
        Task<IEnumerable<MusicViewModel>> GetAll();
        Task<int> Create(Music music);
        Task<int> Update(Music music);
        Task<int> Delete(int id);
    }
}
