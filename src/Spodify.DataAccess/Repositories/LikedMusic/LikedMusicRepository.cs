using Dapper;
using Spodify.DataAccess.Interfaces;
using Spodify.DataAccess.ViewModels;

namespace Spodify.DataAccess.Repositories
{
    public class LikedMusicRepository : BaseRepasitory, ILikedMusicRepository
    {
        public async Task<IEnumerable<LikedMusicViewModel>> GetByUserId(int userId)
        {
            try
            {
                await _connection.OpenAsync();
                var query = "SELECT * FROM UserLikedMusics WHERE user_id = @UserId";
                return await _connection.QueryAsync<LikedMusicViewModel>(query, new { UserId = userId });
            }
            catch
            {
                return Enumerable.Empty<LikedMusicViewModel>();
            }
            finally
            {
                await _connection.CloseAsync();
            }

        }

        public async Task<int> Like(int userId, int musicId)
        {
            var query = @"INSERT INTO Liked_Musics (user_id, music_id, liked_at) 
                          VALUES (@UserId, @MusicId, @LikedAt)";
            return await _connection.ExecuteAsync(query, new { UserId = userId, MusicId = musicId, LikedAt = DateTime.Now });
        }

        public async Task<int> Unlike(int userId, int musicId)
        {
            var query = "DELETE FROM Liked_Musics WHERE user_id = @UserId AND music_id = @MusicId";
            return await _connection.ExecuteAsync(query, new { UserId = userId, MusicId = musicId });
        }
    }
}
