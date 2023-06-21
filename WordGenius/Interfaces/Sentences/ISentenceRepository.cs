using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGenius.Entities.Sentences;

namespace WordGenius.Interfaces.Sentences;

public interface ISentenceRepository : IRepository<Sentence, Sentence>
{
    public Task<int> CountAsync();
}


