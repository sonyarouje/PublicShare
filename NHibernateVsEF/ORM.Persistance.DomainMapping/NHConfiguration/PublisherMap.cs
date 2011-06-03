using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORM.Domain;
using FluentNHibernate.Mapping;
namespace ORM.Persistance.DomainMapping
{
    public class PublisherMap:ClassMap<Publisher>
    {
        public PublisherMap()
        {
            Id(p => p.Id, "pub_id").Not.Nullable();
            Map(p => p.City, "city");
            Map(p => p.Country, "country");
            Map(p => p.Name, "pub_name");
            Map(p => p.State,"state");
            HasMany(p => p.BooksPublished).Inverse().Cascade.All();
            Not.LazyLoad();
            Table("publishers");
        }
    }
}
