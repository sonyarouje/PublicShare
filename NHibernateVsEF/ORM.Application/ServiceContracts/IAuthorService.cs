using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ORM.Domain;
namespace ORM.Application.ServiceContracts
{
    [ServiceContract]
    public interface IAuthorService
    {
        [OperationContract]
        List<Author> GetAllAuthors();

        [OperationContract]
        Author GetAuthor(string id);

        [OperationContract]
        void Save(Author author);
    }
}
