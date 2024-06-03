using Spodify.DataAccess.ViewModels;
using Spodify.Domain.Entities;

namespace Spodify.DataAccess.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<PlaylistViewModel> GetById(int id);
        Task<IEnumerable<PlaylistViewModel>> GetAll();
        Task<int> Create(Playlist playlist);
        Task<int> Update(Playlist playlist);
        Task<int> Delete(int id);
    }
}
