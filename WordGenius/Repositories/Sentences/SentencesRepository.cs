using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGenius.Entities.Sentences;
using WordGenius.Interfaces.Sentences;
using WordGenius.Utils;

namespace WordGenius.Repositories.Sentences;

internal class SentencesRepository : ISentenceRepository
{
    public Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(Sentence Obj)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Sentence>> GetAllAsync(PagenationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<Sentence> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long Id, Sentence EditedObj)
    {
        throw new NotImplementedException();
    }
}
   

