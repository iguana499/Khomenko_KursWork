using System;
using System.Collections.Generic;
using STOBusinessLogic.ViewModels;
using System.Text;

namespace STOBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportWorksViewModel> Works { get; set; }
    }
}
