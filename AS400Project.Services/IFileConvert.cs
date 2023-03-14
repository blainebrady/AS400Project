using AS400Project.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Services
{
    public interface IFileConvert<TEntity>
       where TEntity : class
    {
        Task<TEntity> ConvertToEntity(string textSring, List<Diagram> pattern, object entity);
    }
}
