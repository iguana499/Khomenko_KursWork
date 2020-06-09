using STOBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace STOBusinessLogic.ViewModels
{
    public class ReportWorksViewModel
    {
        public string WorkName { get; set; }
        public decimal Price { get; set; }
        public WorkStatus Status { get; set; }
    }
}
