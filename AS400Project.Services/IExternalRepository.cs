using AS400Project.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Services
{
    public class IExternalRepository<TEntity> where TEntity : class
    {
        protected ApiDbContext _apiDbContext;

        public IExternalRepository([NotNull]ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }
        public virtual async Task<List<TEntity>> ReadAllAsync(bool tracking = true)
        {
            IQueryable<TEntity> query = _apiDbContext.Set<TEntity>();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

    }

}
