using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace ORM.Domain
{
    [DataContract]
    public class Titles
    {
        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual string Title { get; set; }

        [DataMember]
        public virtual string Type { get; set; }

        [DataMember]
        public virtual double Price { get; set; }

        [DataMember]
        public virtual double Advance { get; set; }

        [DataMember]
        public virtual int Royalty { get; set; }

        [DataMember]
        public virtual DateTime PublishedDate { get; set; }

        [DataMember]
        public virtual Publisher BookPublisher { get; set; }

        [DataMember]
        public virtual IList<Author> Authors { get; set; }

        public Titles()
        {
            this.Authors = new List<Author>();
        }

        public virtual void SetPublisher(Publisher publisher)
        {
            publisher.BooksPublished.Add(this);
            this.BookPublisher = publisher;
        }
        public virtual void AddAuthors(Author author)
        {
            author.AddTitles(this);
            this.Authors.Add(author);
        }
    }
}
