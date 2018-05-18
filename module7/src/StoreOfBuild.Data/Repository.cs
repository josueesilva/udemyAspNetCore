using StoreOfBuild.Domain;
using System.Collections.Generic;
using System.Linq;

namespace StoreOfBuild.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TEntity GetById(int id)
        {
            var query = _context.Set<TEntity>().Where(e => e.Id == id);
            if(query.Any())
                return query.First();
            return null;
        }

        public IEnumerable<TEntity> All()
        {
            var query = _context.Set<TEntity>();

            if(query.Any())
                return query.ToList();

            return new List<TEntity>();
        }

        public void Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
    }
}