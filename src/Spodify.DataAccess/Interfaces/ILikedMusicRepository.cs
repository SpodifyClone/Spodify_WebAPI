using Spodify.DataAccess.ViewModels;

namespace Spodify.DataAccess.Interfaces
{
    public interface ILikedMusicRepository
    {
        Task<IEnumerable<LikedMusicViewModel>> GetByUserId(int userId);
        Task<int> Like(int userId, int musicId);
        Task<int> Unlike(int userId, int musicId);
    }
}
