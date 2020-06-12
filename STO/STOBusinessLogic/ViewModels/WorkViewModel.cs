using STOBusinessLogic.Enums;
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
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
        [DisplayName("Статус")]
        public WorkStatus status { get; set; }
        public Dictionary<int, (string, int, int)> WorkParts { get; set; }
    }
}
