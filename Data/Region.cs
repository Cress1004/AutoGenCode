using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Data
{
    public class Region
    {
        public int RegionId { get; set; }
        public float LeftPos { get; set; }
        public float RightPos { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public GenUI GenUI { get; set; }
        public int GenUIId { get; set; }
    }
}
