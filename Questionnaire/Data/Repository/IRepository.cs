using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Data.Repository
{
	public interface IRepository<T> where T: class
	{
        Task<T> Create(T t);
        IQueryable<T> GetAll();
        Task<T> Update(T t);
        Task<T> Get(int id);
    }
}
