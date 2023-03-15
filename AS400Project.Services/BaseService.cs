using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using AS400Project.Data;

namespace AS400Project.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
       where TEntity : class, IImport
    {
        protected ApiDbContext _ApiDbContext;

        protected BaseService([NotNull] ApiDbContext ApiDbContext)
        {
            _ApiDbContext = ApiDbContext;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _ApiDbContext.Set<TEntity>().AddAsync(entity);
            await _ApiDbContext.SaveChangesAsync();

            return entity;
        }
        public virtual async Task<TEntity> ReadAsync(int id, bool Tracking = true)
        {
            var query = _ApiDbContext.Set<TEntity>().AsQueryable();
            if (!Tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }
        public virtual async Task<List<TEntity>> ReadAllAsync(bool tracking = true)
        {
            IQueryable<TEntity> query = _ApiDbContext.Set<TEntity>();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> UpdateAsync(int id, TEntity updateEntity)
        {
            //check that the record exists
            var entity = await ReadAsync(id);
            if (entity == null)
                throw new Exception("Unable to find record with id " + id.ToString());
            //update changes if any of the values have been modified
            _ApiDbContext.Entry(entity).CurrentValues.SetValues(updateEntity);
            _ApiDbContext.Entry(entity).State = EntityState.Modified;
            if (_ApiDbContext.Entry(entity).Properties.Any(property => property.IsModified))
            {
                await _ApiDbContext.SaveChangesAsync();
            }
            return entity;
        }


        public virtual async Task<TEntity> ParseType(string[] header, string[] _line, TEntity entity)
        {
            //move the data to the object and then create a record

            PropertyInfo[] myPropertyInfo;
            // Get the properties of 'Type' class object.
            myPropertyInfo = (entity as Type).GetProperties();

            foreach (var item in myPropertyInfo)
            {
                int pos = Array.IndexOf(header, item.Name);
                if (pos >= 0)
                    item.Equals(_line[pos]);
            }
            await _ApiDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
