using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Globalization;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Data;
using ORM.Persistance.DomainMapping.EFConfiguration;
namespace ORM.Persistance
{
    public class EFRepo:Interface.IRepository
    {
        IDbTransaction _currentTransaction = null;
        string _connectionString = string.Empty;
        public EFRepo(string connectionString)
        {
            _connectionString = connectionString;
            this.IsProxyCreationEnabled = false;
        }

        private EFContext _context = null;
        private EFContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = EFContext.GetContext(_connectionString);
                    _context.ContextOptions.LazyLoadingEnabled = false;
                    _context.ContextOptions.ProxyCreationEnabled = IsProxyCreationEnabled;
                }
                return _context;
            }
        }

        private void OpenConnectionIfClosed()
        {
            if (this.Context.Connection.State != System.Data.ConnectionState.Open)
            {
                this.Context.Connection.Close();
                this.Context.Connection.Open();
            }
        }

        public bool IsProxyCreationEnabled
        {
            get;
            set;
        }

        public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class
        {
            this.OpenConnectionIfClosed();
            return this.Context.CreateGenericObjectSet<TEntity>();
        }

        public IList<TEntity> GetAll<TEntity>() where TEntity : class
        {
            IList<TEntity> entities = this.GetQuery<TEntity>().AsEnumerable<TEntity>().ToList();
            return entities;
        }

        public IList<TEntity> Find<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            IList<TEntity> entities = this.GetQuery<TEntity>().Where(criteria).ToList();
            this.Context.Refresh(RefreshMode.StoreWins, entities);
            return entities;
        }

        public TEntity Single<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            TEntity entity = this.GetQuery<TEntity>().SingleOrDefault<TEntity>(criteria);
            this.Context.Refresh(RefreshMode.StoreWins, entity);
            return entity;
        }

        public TEntity First<TEntity>(System.Linq.Expressions.Expression<Func<TEntity, bool>> criteria) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            this.Context.CreateGenericObjectSet<TEntity>().AddObject(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            this.Context.CreateGenericObjectSet<TEntity>().DeleteObject(entity);
        }

        public void Delete<TEntity>(IEnumerable<TEntity> entites) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class
        {
            
            this.Context.CreateGenericObjectSet<TEntity>().Attach(entity);
        }

        public void Attach<TEntity>(IEnumerable<TEntity> entites) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            this.Context.DetectChanges();
            this.Context.SaveChanges();
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

        
        public void BeginTransaction()
        {
            this.OpenConnectionIfClosed();
            _currentTransaction= this.Context.Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_currentTransaction != null)
                _currentTransaction.Commit();
        }

        public void Rollback()
        {
            if (_currentTransaction != null)
                _currentTransaction.Rollback();
        }

        public void Dispose()
        {
            if (_currentTransaction != null)
                _currentTransaction.Dispose();
            _currentTransaction = null;
            if (_context != null)
                _context.Dispose();
            _context = null;
        }


        public void InitializeAndLoad(object entityToLoad)
        {
            throw new NotImplementedException();
        }
    }
}
