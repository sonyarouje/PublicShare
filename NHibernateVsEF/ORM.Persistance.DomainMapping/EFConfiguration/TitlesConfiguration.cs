using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using ORM.Domain;
namespace ORM.Persistance.DomainMapping.EFConfiguration
{
    public class TitlesConfiguration:EntityTypeConfiguration<Titles>
    {
        public TitlesConfiguration()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("title_id");
            Property(t => t.Advance).HasColumnName("advance");
            Property(t => t.Price).HasColumnName("price");
            Property(t => t.PublishedDate).HasColumnName("pubdate");
            Property(t => t.Royalty).HasColumnName("royalty");
            Property(t => t.Title).HasColumnName("title");
            Property(t => t.Type).HasColumnName("type");
            this.HasRequired(t => t.BookPublisher).WithMany(p => p.BooksPublished).IsIndependent().Map(m => m.MapKey(k=>k.Id,"pub_id"));
            this.HasMany(t => t.Authors).WithMany(a => a.TitlesAuthored).Map(m =>
            {
                m.MapRightKey(t => t.Id, "title_id");
                m.MapLeftKey(a => a.Id, "au_id");
                m.ToTable("titleauthor");
            });
            ToTable("titles");
        }
    }
}
