using System;
using System.Collections.Generic;
using System.Text;

namespace STOBusinessLogic.ViewModels
{
    public class ReportPartsViewModel
    {
        public string WorkName { get; set; }
        public string PartName { get; set; }
        public DateTime? date { get; set; }
        public int count { get; set; }
    }
}
