using Spodify.DataAccess.ViewModels;

namespace Spodify.DataAccess.Interfaces
{
    public interface IViewRepository
    {
        Task<IEnumerable<UserViewModel>> GetByUserId(int userId);
        Task<int> AddView(int userId, int musicId);
    }
}
