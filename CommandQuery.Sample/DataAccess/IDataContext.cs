using CommandQuery.Sample.Models;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CommandQuery.Sample.DataAccess
{
    public interface IDataContext
    {
        DbSet<Blog> Blogs { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Author> Authors { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        void SetModified(Object entity);

        void Dispose();
    }
}