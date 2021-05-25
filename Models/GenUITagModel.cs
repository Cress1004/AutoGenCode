using AutoGenCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Models
{
    public class GenUITagModel
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public int GenUIId { get; set; }
        public GenUI GenUI { get; set; }
    }
}
