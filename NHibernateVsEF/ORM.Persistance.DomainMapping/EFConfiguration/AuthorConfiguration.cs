using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using ORM.Domain;
namespace ORM.Persistance.DomainMapping.EFConfiguration
{
    public class AuthorConfiguration:EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration()
        {
            HasKey(a => a.Id);
            HasMany(a => a.TitlesAuthored);
            Property(a => a.Id).HasColumnName("au_id");
            Property(a => a.Address).HasColumnName("address");
            Property(a => a.FirstName).HasColumnName("au_fname");
            Property(a => a.LastName).HasColumnName("au_lname");
            Property(a => a.Phone).HasColumnName("phone");
            Property(a => a.Contract).HasColumnName("contract");
            ToTable("dbo.authors");
        }
    }
}
