using System;
using System.Collections.Generic;
using System.Text;

namespace STODataBaseImplement.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string WorkName { get; set; }
        public decimal Price { get; set; }
        public virtual List<WorkParts> WorkParts { get; set; }
    }
}
