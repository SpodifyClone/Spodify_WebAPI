using Spodify.DataAccess.ViewModels;

namespace Spodify.DataAccess.Interfaces
{
    public interface ILikedPlaylistRepository
    {
        Task<IEnumerable<LikedPlaylistViewModel>> GetByUserId(int userId);
        Task<int> Like(int userId, int playlistId);
        Task<int> Unlike(int userId, int playlistId);
    }
}
