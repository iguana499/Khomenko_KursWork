using STOBusinessLogic.Enums;
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
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public WorkStatus status { get; set; }
        public virtual List<WorkParts> WorkParts { get; set; }
    }
}
