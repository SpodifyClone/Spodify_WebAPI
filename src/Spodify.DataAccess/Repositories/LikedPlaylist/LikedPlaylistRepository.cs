using Dapper;
using Spodify.DataAccess.Interfaces;
using Spodify.DataAccess.ViewModels;
using System.Data;

namespace Spodify.DataAccess.Repositories
{
    public class LikedPlaylistRepository : BaseRepasitory, ILikedPlaylistRepository
    {

        public async Task<IEnumerable<LikedPlaylistViewModel>> GetByUserId(int userId)
        {
            try
            {
                await _connection.OpenAsync();
                var query = "SELECT * FROM UserLikedPlaylists WHERE user_id = @UserId";
                return await _connection.QueryAsync<LikedPlaylistViewModel>(query, new { UserId = userId });
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    await _connection.CloseAsync();
            }
        }

        public async Task<int> Like(int userId, int playlistId)
        {
            try
            {
                await _connection.OpenAsync();
                var query = @"INSERT INTO Liked_Playlists (user_id, playlist_id, liked_at) 
                              VALUES (@UserId, @PlaylistId, @LikedAt)";
                return await _connection.ExecuteAsync(query, new { UserId = userId, PlaylistId = playlistId, LikedAt = DateTime.Now });
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    await _connection.CloseAsync();
            }
        }

        public async Task<int> Unlike(int userId, int playlistId)
        {
            try
            {
                await _connection.OpenAsync();
                var query = "DELETE FROM Liked_Playlists WHERE user_id = @UserId AND playlist_id = @PlaylistId";
                return await _connection.ExecuteAsync(query, new { UserId = userId, PlaylistId = playlistId });
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    await _connection.CloseAsync();
            }
        }
    }
}
