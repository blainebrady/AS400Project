using AS400Project.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Services
{
    public class IExternalRepository<TEntity> where TEntity : class
    {
        private readonly ApiDbContext _apiDbContext;

        public IExternalRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<List<TEntity>> ReadAllAsync(bool tracking = true)
        {
            IQueryable<TEntity> query = _apiDbContext.Set<TEntity>();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }
    }

}
