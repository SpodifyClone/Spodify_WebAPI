using Dapper;
using Spodify.DataAccess.Interfaces;
using Spodify.DataAccess.ViewModels;
using Spodify.Domain.Entities;
using System.Data;

namespace Spodify.DataAccess.Repositories
{
    public class PlaylistRepository : BaseRepasitory, IPlaylistRepository
    {

        public async Task<PlaylistViewModel> GetById(int id)
        {
            try
            {
                await _connection.OpenAsync();
                var query = "SELECT * FROM AllPlaylists WHERE id = @Id";
                return await _connection.QueryFirstOrDefaultAsync<PlaylistViewModel>(query, new { Id = id });
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

        public async Task<IEnumerable<PlaylistViewModel>> GetAll()
        {
            try
            {
                await _connection.OpenAsync();
                var query = "SELECT * FROM AllPlaylists";
                return await _connection.QueryAsync<PlaylistViewModel>(query);
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

        public async Task<int> Create(Playlist playlist)
        {
            try
            {
                await _connection.OpenAsync();
                var query = @"INSERT INTO Playlists (user_id, name, description, created_at) 
                              VALUES (@UserId, @Name, @Description, @CreatedAt)";
                return await _connection.ExecuteAsync(query, playlist);
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

        public async Task<int> Update(Playlist playlist)
        {
            try
            {
                await _connection.OpenAsync();
                var query = @"UPDATE Playlists 
                              SET name = @Name, description = @Description 
                              WHERE id = @Id";
                return await _connection.ExecuteAsync(query, playlist);
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

        public async Task<int> Delete(int id)
        {
            try
            {
                await _connection.OpenAsync();
                var query = "DELETE FROM Playlists WHERE id = @Id";
                return await _connection.ExecuteAsync(query, new { Id = id });
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
