using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORM.Persistance;
using ORM.Persistance.Interface;
using ORM.Domain;
using ORM.Ioc;
namespace ORM.Application
{
    //svcutil http://localhost:51027/AuthorService.svc?wsdl /edb /ct:System.Collections.Generic.List`1
    public class AuthorService:ServiceContracts.IAuthorService
    {
        public List<Domain.Author> GetAllAuthors()
        {
            IRepository repository = RepositoryFactory.GetRepository<IRepository>();
            try
            {
                List<Author> authors = repository.GetAll<Author>().ToList();
                return authors;
            }
            catch (Exception ex) { throw; }
            finally { repository.Dispose(); }
        }

        public Author GetAuthor(string id)
        {
            IRepository repository = RepositoryFactory.GetRepository<IRepository>();
            try
            {
                Author author= repository.Single<Author>(a => a.Id == id);
                //repository.InitializeAndLoad(author.TitlesAuthored);
                return author;
            }
            catch (Exception ex) { throw; }
            finally{repository.Dispose();}
        }


        public void Save(Author author)
        {
            IRepository repository = RepositoryFactory.GetRepository<IRepository>();
            try
            {
                repository.BeginTransaction();
                author.Contract = true;
                repository.Add<Author>(author);
                //repository.Attach<Author>(author);
                repository.SaveChanges();
                repository.CommitTransaction();
            }
            catch (Exception ex)
            {
                repository.Rollback();
                throw;
            }
            finally { repository.Dispose(); }
        }
    }
}
