using STOBusinessLogic.View_models;
using STOBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace STOBusinessLogic.Helpermodels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportWorksViewModel> Works { get; set; }
    }

}