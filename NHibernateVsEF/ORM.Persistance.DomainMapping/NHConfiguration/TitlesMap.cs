using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ORM.Domain;
using FluentNHibernate.Mapping;
namespace ORM.Persistance.DomainMapping
{
    public class TitlesMap:ClassMap<Titles>
    {
        public TitlesMap()
        {
            Id(t => t.Id, "title_id").Not.Nullable();
            Map(t => t.Advance, "advance");
            Map(t => t.Price, "price");
            Map(t => t.PublishedDate, "pubdate").Not.Nullable();
            Map(t => t.Royalty, "royalty");
            Map(t => t.Title, "title").Not.Nullable();
            Map(t => t.Type, "type").Not.Nullable();
            References(t => t.BookPublisher, "pub_id").Not.LazyLoad();
            HasManyToMany(t => t.Authors).Cascade.All().Inverse().Table("titleauthor").ChildKeyColumn("au_id").ParentKeyColumn("title_id");
            Not.LazyLoad();
            Table("titles");
        }
    }
}
