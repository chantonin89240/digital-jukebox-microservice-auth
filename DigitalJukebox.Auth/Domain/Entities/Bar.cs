﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Bar
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public double Fee { get; set; }
        public bool IsOpen { get; set; } = false;
        public Guid User { get; set; }
    }
}