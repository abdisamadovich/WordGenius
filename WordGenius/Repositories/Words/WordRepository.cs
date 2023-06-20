using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordGenius.Constans;
using WordGenius.Entities.Words;
using WordGenius.Interfaces;
using WordGenius.Interfaces.Words;
using WordGenius.Utils;

namespace WordGenius.Repositories.Words;

class WordRepository : IWordsRepository
{
    private readonly NpgsqlConnection _connection;
    public WordRepository()
    {
        _connection = new NpgsqlConnection(DbConstans.DB_CONNECTIONSTRING);
    }

    public Task<int> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public async Task<int> CreateAsync(Word Obj)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.words(" +
                "word, tranlate, discription, sound, is_remember, created_at, update_at) " +
                "VALUES(@name, @translate, @discription, @sound, @isremember, @created_at, @updated_at);";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("name", Obj.Text);
                command.Parameters.AddWithValue("translate", Obj.Translate);
                command.Parameters.AddWithValue("discription", Obj.Discription);
                command.Parameters.AddWithValue("sound", Obj.Sounds);
                command.Parameters.AddWithValue("isremember", Obj.Is_Remember);
                command.Parameters.AddWithValue("created_at", Obj.CreateAt);
                command.Parameters.AddWithValue("updated_at", Obj.UpdateAt);

                var dbResult = await command.ExecuteNonQueryAsync();
                return dbResult;
            }
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> DeleteAsync(long Id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<Word>> GetAllAsync(PagenationParams @params)
    {
        throw new System.NotImplementedException();
    }

    public Task<Word> GetAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long Id, Word EditedObj)
    {
        throw new System.NotImplementedException();
    }
}
