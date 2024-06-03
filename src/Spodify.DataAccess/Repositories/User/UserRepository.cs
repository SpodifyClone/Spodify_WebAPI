using Dapper;
using Spodify.DataAccess.Interfaces;
using Spodify.DataAccess.ViewModels;
using Spodify.Domain.Entities;
using System.Data;

namespace Spodify.DataAccess.Repositories
{
    public class UserRepository :BaseRepasitory, IUserRepository
    {

        public async Task<UserViewModel> GetById(int id)
        {
            try
            {
                await _connection.OpenAsync();
                var query = "SELECT * FROM AllUsers WHERE id = @Id";
                return await _connection.QueryFirstOrDefaultAsync<UserViewModel>(query, new { Id = id });
            }
            catch
            {
                return null;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    await _connection.CloseAsync();
            }
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            try
            {
                await _connection.OpenAsync();
                var query = "SELECT * FROM AllUsers";
                return await _connection.QueryAsync<UserViewModel>(query);
            }
            catch
            {
                return null;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    await _connection.CloseAsync();
            }
        }

        public async Task<int> Create(User user)
        {
            try
            {
                await _connection.OpenAsync();
                var query = @"INSERT INTO Users (username, email, password, role, created_at) 
                              VALUES (@Username, @Email, @Password, @Role, @CreatedAt)";
                return await _connection.ExecuteAsync(query, user);
            }
            catch
            {
                return 0;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                    await _connection.CloseAsync();
            }
        }

        public async Task<int> Update(User user)
        {
            try
            {
                await _connection.OpenAsync();
                var query = @"UPDATE Users 
                              SET username = @Username, email = @Email, password = @Password, role = @Role 
                              WHERE id = @Id";
                return await _connection.ExecuteAsync(query, user);
            }
            catch
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
                var query = "DELETE FROM Users WHERE id = @Id";
                return await _connection.ExecuteAsync(query, new { Id = id });
            }
            catch
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
