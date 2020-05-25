using STOBusinessLogic.Binding_models;
using STOBusinessLogic.Interfaces;
using STOBusinessLogic.View_models;
using STODataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STODataBaseImplement.Implements
{
    public class PartLogic : IPart
    {
        public void CreateOrUpdate(PartBindingModel model)
        {
            using (var context = new STODataBase())
            {
                Part element = context.Part.FirstOrDefault(rec =>
               rec.PartName == model.PartName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Part.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Part();
                    context.Part.Add(element);
                }
                element.PartName = model.PartName;
                element.PartPrice = model.PartPrice;
                context.SaveChanges();
            }
        }

        public void Delete(PartBindingModel model)
        {
            using (var context = new STODataBase())
            {
                Part element = context.Part.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Part.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<PartViewModel> Read(PartBindingModel model)
        {
            using (var context = new STODataBase())
            {
                return context.Part
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new PartViewModel
                {
                    Id = rec.Id,
                    PartName = rec.PartName, 
                    PartPrice = rec.PartPrice
                })
                .ToList();
            }
        }
    }
}
