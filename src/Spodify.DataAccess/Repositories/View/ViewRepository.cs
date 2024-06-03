using Dapper;
using Spodify.DataAccess.Interfaces;
using Spodify.DataAccess.ViewModels;
using System.Data;

namespace Spodify.DataAccess.Repositories
{
    public class ViewRepository : BaseRepasitory, IViewRepository
    {

        public async Task<IEnumerable<UserViewModel>> GetByUserId(int userId)
        {
            try
            {
                await _connection.OpenAsync();
                var query = "SELECT * FROM UserViewedMusics WHERE user_id = @UserId";
                return await _connection.QueryAsync<UserViewModel>(query, new { UserId = userId });
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    await _connection.CloseAsync();
            }
        }

        public async Task<int> AddView(int userId, int musicId)
        {
            try
            {
                await _connection.OpenAsync();
                var query = @"INSERT INTO Views (user_id, music_id, viewed_at) 
                              VALUES (@UserId, @MusicId, CURRENT_TIMESTAMP)";
                return await _connection.ExecuteAsync(query, new { UserId = userId, MusicId = musicId });
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    await _connection.CloseAsync();
            }
        }
    }
}
