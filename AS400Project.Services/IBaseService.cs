using AS400Project.Data;

namespace AS400Project.Services
{
    public interface IBaseService<TEntity>
       where TEntity : class, IImport
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> ReadAsync(int id, bool Tracking = true);
        Task<TEntity> UpdateAsync(int id, TEntity updateEntity);
        Task<TEntity> ParseType(string[] header, string[] _line, TEntity entity);
    }
}
