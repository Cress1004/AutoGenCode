using AutoGenCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Models
{
    public class RegionModel
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public float LeftPos { get; set; }
        public float RightPos { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Tag Tag { get; set; }
        public GenUI GenUI { get; set; }
        public int GenUIId { get; set; }
    }
}
