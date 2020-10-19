using System;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Data.Repository
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly DatabaseContext _dataBase;

        public Repository(DatabaseContext database)
        {
            _dataBase = database;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _dataBase.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Create)} entity must not be null");
            }

            try
            {
                await _dataBase.AddAsync(entity);
                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Update)} entity must not be null");
            }

            try
            {
                _dataBase.Update(entity);
                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }

        public async Task<TEntity> Get(int id)
        {
            try 
            {
                return await _dataBase.Set<TEntity>().FindAsync(id);
            }
            catch (Exception)
            {
                throw new Exception($"{id} could not be found");
            }
           
        }
    }
}
