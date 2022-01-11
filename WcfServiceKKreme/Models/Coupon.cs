﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceKKreme.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Duration { get; set; }
        public Status Status { get; set; }
        public Establishment Establishment { get; set; }
        public string Serie { get; set; }

        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string DeletedAt { get; set; }
    }
}