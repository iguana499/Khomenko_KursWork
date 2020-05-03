using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace STOBusinessLogic.View_models
{
    public class PartViewModel
    {
        public int? Id { get; set; }
        [DisplayName ("Запчасть")]
        public string PartName { get; set; }
        [DisplayName("Стоимость")]
        public int PartPrice { get; set; }
    }
}
