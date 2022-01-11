using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceKKreme.Models
{
    public class Permission
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string DeletedAt { get; set; }
    }
}