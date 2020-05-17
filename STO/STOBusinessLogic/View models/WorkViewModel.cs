using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace STOBusinessLogic.View_models
{
    public class WorkViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название ремонта")]
        public string WorkName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int, int)> WorkParts { get; set; }
    }
}
