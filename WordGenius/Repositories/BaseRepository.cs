using Npgsql;
using WordGenius.Constans;

namespace WordGenius.Repositories;

public abstract class BaseRepository
{
	protected readonly NpgsqlConnection _connection;
	public BaseRepository()
	{
		_connection = new NpgsqlConnection(DbConstans.DB_CONNECTIONSTRING);
	}
}
