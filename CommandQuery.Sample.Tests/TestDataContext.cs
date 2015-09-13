using CommandQuery.Sample.DataAccess;
using CommandQuery.Sample.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CommandQuery.Sample.Tests
{
    public class TestDataContext : IDataContext
    {
        public TestDataContext()
        {
            Blogs = new TestDbSet<Blog>();
            Posts = new TestDbSet<Post>();
            Comments = new TestDbSet<Comment>();
            Authors = new TestDbSet<Author>();
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Author> Authors { get; set; }

        private int SaveChangesCount { get; set; }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            var props = GetType().GetProperties()
                            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.Name.StartsWith("DbSet"))
                            .Where(p => p.PropertyType.GetGenericArguments().All(t => t == typeof(TEntity)));
            return props.Select(p => (DbSet<TEntity>)p.GetValue(this, null)).FirstOrDefault();
        }

        public int SaveChanges()
        {
            SaveChangesCount++;
            return 1;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Task.FromResult(SaveChangesCount++);
        }

        public void SetModified(object entity)
        {
        }

        public void Dispose()
        {
        }
    }
}