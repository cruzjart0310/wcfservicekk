using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceKKreme.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Emai { get; set; }

        public string Password { get; set; }

        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string DeletedAt { get; set; }

        public ICollection<Role> Roles { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}