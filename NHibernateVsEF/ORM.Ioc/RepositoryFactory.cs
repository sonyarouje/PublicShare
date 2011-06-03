using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
namespace ORM.Ioc
{
    public static class RepositoryFactory
    {
        private static IWindsorContainer _container = null;
        public static T GetRepository<T>() where T : class
        {
            if (_container == null)
                InitializeWindsorContainer();

            return _container.Resolve<T>();
        }

        private static void InitializeWindsorContainer()
        {
            try
            {
                if (_container == null)
                {
                    StringBuilder basePath = new StringBuilder(AppDomain.CurrentDomain.BaseDirectory);
#if TEST
                    basePath.Append(@"\IOCConfig.xml");
#else
                    if (basePath.ToString().EndsWith("\\") == false)
                        basePath.Append("\\");
                    if (!basePath.ToString().Contains("bin"))
                    {
                        basePath.Append(@"bin\");
                    }
                    basePath.Append(@"IOCConfig.xml");
#endif
                    //_container = new WindsorContainer(new XmlInterpreter(AppDomain.CurrentDomain.BaseDirectory + @"\bin\IOC\Configuration\IocConfiguration.xml"));
                    _container = new WindsorContainer(new XmlInterpreter(basePath.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
