using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace ORM.Domain
{
    [DataContract]
    public class Publisher
    {
        [DataMember]
        public virtual string Id { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual string City { get; set; }

        [DataMember]
        public virtual string State { get; set; }

        [DataMember]
        public virtual string Country { get; set; }

        [DataMember]
        public virtual IList<Titles> BooksPublished { get; set; }

        public Publisher()
        {
            this.BooksPublished = new List<Titles>();
        }
        public virtual void AddBooks(Titles titles)
        {
            titles.SetPublisher(this);
            this.BooksPublished.Add(titles);
        }
    }
}
