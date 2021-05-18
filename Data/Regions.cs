﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Data
{
    public class Regions
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public float LeftPos { get; set; }
        public float RightPos { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
