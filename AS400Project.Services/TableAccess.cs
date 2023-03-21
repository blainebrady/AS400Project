using AS400Project.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Services
{
    public class TableAccess
    {
        protected ApiDbContext _db;

        public TableAccess([NotNull] ApiDbContext db)
        {
            _db = db;
        }
        public virtual async Task<List<X_SUSMSTP>> ReadAllAsync(bool tracking = true)
        {
            IQueryable<X_SUSMSTP> query = _db.Set<X_SUSMSTP>();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }
    }
    
}
