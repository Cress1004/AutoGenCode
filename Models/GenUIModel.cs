using AutoGenCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Models
{
    public class GenUIModel
    {
        public int Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public DateTime? CreatedAt { get; set; }
        /*public List<TagModel> Tags { get; set; }*/
        public List<Region> Regions { get; set; }
        public List<GenUITag> Tags { get; set; }
    }
}
