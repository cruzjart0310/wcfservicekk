﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceKKreme.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}