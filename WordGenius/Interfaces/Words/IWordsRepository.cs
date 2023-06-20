using System.Threading.Tasks;
using WordGenius.Entities.Words;
namespace WordGenius.Interfaces.Words;

public interface IWordsRepository : IRepository<Word, Word>
{
    public Task<int> CountAsync();
}
