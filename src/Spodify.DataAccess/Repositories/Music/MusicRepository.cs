using Dapper;
using Spodify.DataAccess.Interfaces;
using Spodify.DataAccess.ViewModels;
using Spodify.Domain.Entities;
using System.Data;

namespace Spodify.DataAccess.Repositories
{
    public class MusicRepository : BaseRepasitory, IMusicRepository
    {

        public async Task<MusicViewModel> GetById(int id)
        {
            try
            {
                await _connection.OpenAsync();
                var query = "SELECT * FROM AllMusic WHERE id = @Id";
                return await _connection.QueryFirstOrDefaultAsync<MusicViewModel>(query, new { Id = id });
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

        public async Task<IEnumerable<MusicViewModel>> GetAll()
        {
            try
            {
                await _connection.OpenAsync();
                var query = "SELECT * FROM AllMusic";
                return await _connection.QueryAsync<MusicViewModel>(query);
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

        public async Task<int> Create(Music music)
        {
            try
            {
                await _connection.OpenAsync();
                var query = @"INSERT INTO Music (title, artist, release_date, created_at) 
                              VALUES (@Title, @Artist, @ReleaseDate, @CreatedAt)";
                return await _connection.ExecuteAsync(query, music);
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

        public async Task<int> Update(Music music)
        {
            try
            {
                await _connection.OpenAsync();
                var query = @"UPDATE Music 
                              SET title = @Title, artist = @Artist, release_date = @ReleaseDate 
                              WHERE id = @Id";
                return await _connection.ExecuteAsync(query, music);
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
                var query = "DELETE FROM Music WHERE id = @Id";
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
