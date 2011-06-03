using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Cfg;
using NHibernate.Proxy;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;
namespace ORM.Persistance
{
    public class HibernateRepo:Interface.IRepository
    {
        IList _itemsAdded = new System.Collections.ArrayList();//  List();
        private static string _connectionString;

        public HibernateRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        private static ISessionFactory CreateSessionFactory()
        {
            StringBuilder basePath = new StringBuilder(AppDomain.CurrentDomain.BaseDirectory);
            if (basePath.ToString().EndsWith("\\") == false)
                basePath.Append("\\");
            basePath.Append(@"bin\ORM.Persistance.DomainMapping.dll");
            //basePath.Append(@"ORM.Persistance.DomainMapping.dll");

            Assembly asm = Assembly.LoadFile(basePath.ToString());
            return Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2008.ConnectionString(_connectionString))
            .Mappings(m =>
                m.FluentMappings.AddFromAssembly(asm)
                .Conventions.Add(FluentNHibernate.Conventions.Helpers.LazyLoad.Never())) //.AddFromAssemblyOf<HibernateRepo>())
            .BuildSessionFactory();
        }

        ISession _session;
        private ISession Session
        {
            get 
            {
                if (_session == null)
                    _session = CreateSessionFactory().OpenSession();
                if (_session.IsOpen == false)
                    _session = CreateSessionFactory().OpenSession();
                if (_session.Connection.State != System.Data.ConnectionState.Open)
                {
                    _session.Connection.Close();
                    _session.Connection.Open();
                }
                return _session;
            }
        }

        ITransaction _currentTransaction = null;
        public void BeginTransaction()
        {
            _currentTransaction= this.Session.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _currentTransaction.Commit();
        }
        public void Rollback()
        {
            _currentTransaction.Rollback();
        }

        public bool IsProxyCreationEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

       
        public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
        {
            return this.Session.Query<TEntity>();
        }

        public IList<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return this.GetQuery<TEntity>().AsEnumerable<TEntity>().ToList();
        }

        public IList<TEntity> Find<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            IList<TEntity> entities= this.GetQuery<TEntity>().Where(criteria).ToList();
            NHibernateUtil.Initialize(entities);
            return entities;
        }

        public TEntity Single<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            TEntity entity= this.GetQuery<TEntity>().SingleOrDefault<TEntity>(criteria);
            entity.UnproxyObjectTree(CreateSessionFactory(), 3);
            //this.InitializeAndLoad(entity);
            return entity;
        }

        public void InitializeAndLoad(object entityToLoad)
        {
            //NHibernateUtil.Initialize(entityToLoad);
            NHibernateProxyUtils.UnproxyObjectTree<HibernateRepo>(this, CreateSessionFactory(), 3);
        }
        public TEntity First<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _itemsAdded.Add(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            this.Session.Delete(entity);
        }

        public void Delete<TEntity>(IEnumerable<TEntity> entites) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Attach<TEntity>(IEnumerable<TEntity> entites) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            for (int i = 0; i < _itemsAdded.Count; i++)
            {
                this.Session.SaveOrUpdate(_itemsAdded[i]);
            }
        }

        public bool EnableEagerLoading
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Update<TEntity>(TEntity entity, TEntity old) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (this.Session != null)
            {
                _session.Close();
                _session.Dispose();
            }
            if (this._currentTransaction != null)
                _currentTransaction.Dispose();
        }
    }
}
