using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class ProgrammingLanguage:Entity
    {
        public ProgrammingLanguage() { }

        public string Name { get; set; }

        public virtual ICollection<Technology> Technologies { get; set; }
           

        public ProgrammingLanguage(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }


    }
}
