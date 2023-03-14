using Microsoft.EntityFrameworkCore;

namespace AS400Project.Data
{
    public class Import : IImport
    {
        public int Id { get; set; }
        public bool processed { get; set; }
        public DateTimeOffset Created { get; set; }

        public static void OnModelCreating<TEntity>(ModelBuilder modelBuilder) where TEntity : class, IImport
        {
            modelBuilder.Entity<TEntity>().HasKey(entity => entity.Id);
        }
    
    }
}
