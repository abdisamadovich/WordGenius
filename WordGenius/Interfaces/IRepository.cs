using System.Collections.Generic;
using System.Threading.Tasks;
using WordGenius.Utils;

namespace WordGenius.Interfaces;

public interface IRepository<TModel, TViewModel>
{

    public Task<int> CreateAsync(TModel Obj);


    public Task<int> UpdateAsync(long Id, TModel EditedObj);


    public Task<int> DeleteAsync(long Id);


    public Task<IList<TViewModel>> GetAllAsync(PagenationParams @params);


    public Task<TViewModel> GetAsync(long id);
}
