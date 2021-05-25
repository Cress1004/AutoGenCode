using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Data
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public ICollection<Region> Regions { get; set; }
        /*public ICollection<GenUI> GenUIs { get; set; }*/
        public ICollection<GenUITag> GenUIs { get; set; }
    }
}
