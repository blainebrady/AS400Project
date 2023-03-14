using AS400Project.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Services
{
    public abstract class FileConvert<TEntity> : IFileConvert<TEntity> where TEntity : class
    {
        public virtual async Task<TEntity> ConvertToEntity(string textString, List<Diagram> pattern, object entity)
        {
            PropertyInfo[] patternProperties = entity.GetType().GetProperties();        //this will give us the properties of the class we're using
            foreach (var item in patternProperties)
            {
                Diagram d = pattern.Find(p => p.fieldName == item.Name);
                if (d != null)
                {
                    string res = textString.Substring(d.start, d.length);
                    item.Equals(res);
                }
            }
            var convEntity = (TEntity)Convert.ChangeType(entity, typeof(TEntity));
            return convEntity;
        }

    }
}
