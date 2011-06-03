using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Data.Entity;
namespace ORM.Persistance.DomainMapping.EFConfiguration
{
    public class EFModelBuilder
    {
        static ModelBuilder _builder = null;
        static DbModel _model = null;
        
        public static DbModel Model(SqlConnection con)
        {
            if ((_builder == null) || (_model == null))
            {
                _builder = new ModelBuilder();
                _builder.Configurations.Add(new AuthorConfiguration());
                _builder.Configurations.Add(new TitlesConfiguration());
                _builder.Configurations.Add(new PublisherConfiguration());
                var edm=_builder.Build(con);
                _model = new DbModel(edm);
            }
            return _model; ;
        }
    }
}
