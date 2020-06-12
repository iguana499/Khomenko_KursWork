using STOBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace STOBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportPartsViewModel> Works { get; set; }
    }
}
