using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
namespace ORM.Persistance
{
    public class NHInterceptor:EmptyInterceptor
    {
        public override bool OnLoad(object entity, object id, object[] state, string[] propertyNames, NHibernate.Type.IType[] types)
        {
            return base.OnLoad(entity, id, state, propertyNames, types);
        }
    }
}
