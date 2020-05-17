using System;
using System.Collections.Generic;
using System.Text;

namespace STODataBaseImplement.Models
{
    public class WorkParts
    {
        public int Id { get; set; }
        public int workId { get; set; }
        public int PartId { get; set; }
        public int count { get; set; }
        public int partPrice { get; set; }
        public virtual Part Part { get; set; }
        public virtual Work Work { get; set; }

    }
}
