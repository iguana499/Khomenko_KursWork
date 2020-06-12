using STOBusinessLogic.Binding_models;
using STOBusinessLogic.Enums;
using STOBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace STOBusinessLogic.BusinessLogics
{
    public class MainLogic
    {
        private readonly IWork work;
        public MainLogic(IWork work) 
        {
            this.work = work;
        }
        public void FinishWork(ChangeStatusBindingModel model)
        {
            var workModel = this.work.Read(new WorkBindingModel
            {
                Id = model.workId
            })?[0];
            if (workModel == null)
            {
                throw new Exception("Не найден заказ");
            }
            work.CreateOrUpdate(new WorkBindingModel
            {
                Id = workModel.Id,
                WorkName = workModel.WorkName,
                Price = workModel.Price,
                WorkParts = workModel.WorkParts,
                DateCreate = workModel.DateCreate,
                DateImplement = DateTime.Now,
                status = WorkStatus.Готов
            });
        }
    }
}
