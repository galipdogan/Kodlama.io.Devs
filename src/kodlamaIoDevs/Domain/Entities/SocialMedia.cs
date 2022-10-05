using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialMedia:Entity
    {
        public SocialMedia()
        {

        }

        public SocialMedia(int id, int userId, string link, string firstName, string lastName) : this()
        {
            Id = id;
            UserId = userId;
            Link = link;
        }

        public int UserId { get; set; }
        public string Link { get; set; }

        public virtual User? User { get; set; }

       

        
    }
}
