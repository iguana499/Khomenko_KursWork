using System;
using System.Collections.Generic;
using System.Text;

namespace STOListImplement.Models
{
    public class WorkParts
    {
        public int Id { get; set; }
        public int workId { get; set; }
        public int partId { get; set; }
        public int count { get; set;}
        public int partPrice { get; set; }
    }
}
