using Npgsql;

namespace Spodify.DataAccess.Repositories;

public class BaseRepasitory
{
    protected readonly NpgsqlConnection _connection;

    public BaseRepasitory()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=spodify-db; User Id=postgres; Password=Mirka_cr7;");
    }

}
