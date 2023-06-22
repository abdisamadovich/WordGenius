using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGenius.Entities.Results;

namespace WordGenius.Interfaces.Results;

public interface IResultsRepository 
{
    public Task<Result> GetAsync(long id);


    public Task<int> CreateAsync(Result Obj);


    public Task<int> UpdateStepAsync(Result Obj, int StepNumber);

}
