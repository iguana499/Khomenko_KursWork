﻿using System;
using System.Collections.Generic;
using System.Text;

namespace STOBusinessLogic.Binding_models
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<int> worksId { get; set; }
    }
}
