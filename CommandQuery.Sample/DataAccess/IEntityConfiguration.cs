using System.Data.Entity.ModelConfiguration.Configuration;

namespace CommandQuery.Sample.DataAccess
{
    public interface IEntityConfiguration
    {
        void AddConfiguration(ConfigurationRegistrar registrar);
    }
}