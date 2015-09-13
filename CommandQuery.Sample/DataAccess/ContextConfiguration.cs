using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace CommandQuery.Sample.DataAccess
{
    public class ContextConfiguration
    {
        [ImportMany(typeof(IEntityConfiguration))]
        public IEnumerable<IEntityConfiguration> Configurations
        {
            get;
            set;
        }
    }
}