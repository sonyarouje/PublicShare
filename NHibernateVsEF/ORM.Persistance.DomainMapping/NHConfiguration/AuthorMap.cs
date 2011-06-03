using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORM.Domain;
using FluentNHibernate.Mapping;
namespace ORM.Persistance.DomainMapping
{
    public class AuthorMap:ClassMap<Author>
    {
        public AuthorMap()
        {
            Id(x => x.Id,"au_id");
            Map(x => x.LastName, "au_lname");
            Map(x => x.FirstName, "au_fname");
            Map(x => x.Address, "address");
            Map(x => x.Phone, "phone");
            Map(x => x.Contract, "contract");
            HasManyToMany(t => t.TitlesAuthored).Cascade.All().Table("titleauthor").ChildKeyColumn("title_id").ParentKeyColumn("au_id");//.KeyColumn("au_id").KeyColumn("title_id");
            Table("dbo.authors");
            Not.LazyLoad();
        }
    }
}
