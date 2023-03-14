using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS400Project.Data
{
    public interface IImport
    {
        int Id { get; set; }
        bool processed { get; set; }
        DateTimeOffset Created { get; set; }
        public static void OnModelCreating<TEntity>(ModelBuilder modelBuilder) where TEntity : class, IImport
        {
            modelBuilder.Entity<TEntity>().HasKey(entity => entity.Id);
        }
    }
}
