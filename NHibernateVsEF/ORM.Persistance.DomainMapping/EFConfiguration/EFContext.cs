using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.SqlClient;
namespace ORM.Persistance.DomainMapping.EFConfiguration
{
    public class EFContext:ObjectContext
    {
        public EFContext(EntityConnection connection):base(connection)
        {

        }
        private static string _connectionString = string.Empty;

        public IObjectSet<TEntity> CreateGenericObjectSet<TEntity>() where TEntity : class
        {
            return base.CreateObjectSet<TEntity>();
        }
        public static EFContext GetContext(string connection)
        {
            SqlConnection con = new SqlConnection(connection);
            return EFModelBuilder.Model(con).CreateObjectContext<EFContext>(con);
        }
    }
}
