using AutoGenCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Models
{
    public class TagModel
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Region> Regions { get; set; }
        /*public List<GenUI> GenUIs { get; set; }*/
        public List<GenUITag> GenUIs { get; set; }
    }
}
