using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace STODataBaseImplement.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string PartName { get; set; }
        public int PartPrice { get; set; }
        [ForeignKey ("PartId")] 
        public virtual List<WorkParts> WorkParts { get; set; }

    }
}
