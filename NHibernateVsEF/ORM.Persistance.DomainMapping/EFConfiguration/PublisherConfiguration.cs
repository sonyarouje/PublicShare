using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using ORM.Domain;
namespace ORM.Persistance.DomainMapping.EFConfiguration
{
    public class PublisherConfiguration:EntityTypeConfiguration<Publisher>
    {
        public PublisherConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("pub_id");
            Property(p => p.City).HasColumnName("city");
            Property(p => p.Country).HasColumnName("country");
            Property(p => p.Name).HasColumnName("pub_name");
            Property(p => p.State).HasColumnName("state");
            //this.HasMany(p=>p.BooksPublished).WithMany(t=>t.BookPublisher)
        }
    }
}
