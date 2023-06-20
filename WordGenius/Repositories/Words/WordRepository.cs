using EduCenter.Desktop.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using WordGenius.Interfaces.Words;

namespace WordGenius.Repositories.Words;

class WordRepository : IWordsRepository
{
    private readonly NpgsqlConnection _connection;
    public WordRepository()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }

    public Task<int> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<int> CreateAsync(WordRepository Obj)
    {




    }

    public Task<int> DeleteAsync(long Id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<WordRepository>> GetAllAsync(PagenationParams @params)
    {
        throw new System.NotImplementedException();
    }

    public Task<WordRepository> GetAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long Id, WordRepository EditedObj)
    {
        throw new System.NotImplementedException();
    }
}
