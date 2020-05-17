using System;
using System.Collections.Generic;
using System.Text;

namespace STOBusinessLogic.Binding_models
{
    public class WorkBindingModel
    {
        public int? Id { get; set; }
        public string WorkName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int, int)> WorkParts { get; set; }
    }
}
