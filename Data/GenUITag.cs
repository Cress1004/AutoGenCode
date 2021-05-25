using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Data
{
    public class GenUITag
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int GenUIId { get; set; }
        public GenUI GenUI { get; set; }
    }
}
