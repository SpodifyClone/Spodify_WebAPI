using Spodify.DataAccess.ViewModels;
using Spodify.Domain.Entities;

namespace Spodify.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<UserViewModel> GetById(int id);
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<int> Create(User user);
        Task<int> Update(User user);
        Task<int> Delete(int id);
    }
}
