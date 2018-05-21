using StoreOfBuild.Domain.Products;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreOfBuild.Data.Contexts;
using System.Collections.Generic;

namespace StoreOfBuild.Data.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override Product GetById(int id)
        {
            var query = _context.Set<Product>().Include(p => p.Category).Where(e => e.Id == id);

            return query.Any() ? query.First() : null;
        }
        
        public override IEnumerable<Product> All()
        {
            var query = _context.Set<Product>().Include(p => p.Category);

            return query.Any() ? query.ToList() : new List<Product>();
        }

    }
}