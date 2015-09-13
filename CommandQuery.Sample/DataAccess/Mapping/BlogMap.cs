using CommandQuery.Sample.Models;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace CommandQuery.Sample.DataAccess.Mapping
{
    public class BlogMap : EntityTypeConfiguration<Blog>, IEntityConfiguration
    {
        public BlogMap()
        {
            // Primary key
            HasKey(t => t.Id);

            // Properties
            Property(t => t.Name).IsRequired();

            Property(t => t.Name).HasMaxLength(200);

            // Table & Column Mappings
            ToTable("Blog");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
        }

        public void AddConfiguration(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}