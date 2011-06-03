using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
namespace ORM.Domain
{
    [DataContract]
    public class Author
    {
        [DataMember]
        public virtual string Id { get; private set; }
        [DataMember]
        public virtual string LastName { get; set; }
        [DataMember]
        public virtual string FirstName { get; set; }
        [DataMember]
        public virtual string Phone { get; set; }
        [DataMember]
        public virtual string Address { get; set; }
        [DataMember]
        public virtual IList<Titles> TitlesAuthored { get; set; }
        public virtual bool Contract { get; set; }

        public Author()
        {
            this.TitlesAuthored = new List<Titles>();
        }
        public virtual void AddTitles(Titles titles)
        {
            this.TitlesAuthored.Add(titles);
            titles.Authors.Add(this);
        }
    }
}
