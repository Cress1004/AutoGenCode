using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Data
{
    public class GenUI
    {
        public int GenUIId { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ICollection<GenUITag> Tags { get; set; }
        /*public ICollection<GenUITag> GenUITags { get; set; }*/
        public ICollection<Region> Regions { get; set; }
    }
}
