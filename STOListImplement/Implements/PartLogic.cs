using STOBusinessLogic.Binding_models;
using STOBusinessLogic.Interfaces;
using STOBusinessLogic.View_models;
using STOListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STOListImplement.Implements
{
    public class PartLogic: IPart
    {
        private readonly DataListSingleton source;
        public PartLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(PartBindingModel model)
        {
            Part tempPart = model.Id.HasValue ? null : new Part
            {
                Id = 1
            };
            foreach (var part in source.Parts)
            {
                if (part.PartName == model.PartName && part.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (!model.Id.HasValue && part.Id >= tempPart.Id)
                {
                    tempPart.Id = part.Id + 1;
                }
                else if (model.Id.HasValue && part.Id == model.Id)
                {
                    tempPart = part;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempPart == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempPart);
            }
            else
            {
                source.Parts.Add(CreateModel(model, tempPart));
            }
        }

        public void Delete(PartBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<PartViewModel> Read(PartBindingModel model)
        {
            List<PartViewModel> result = new List<PartViewModel>();
            foreach (var component in source.Parts)
            {
                if (model != null)
                {
                    if (component.Id == model.Id)
                    {
                        result.Add(CreateViewModel(component));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(component));
            }
            return result;
        }

        private Part CreateModel(PartBindingModel model, Part component)
        {
            component.PartName = model.PartName;
            component.PartPrice = model.PartPrice;
            return component;
        }
        private PartViewModel CreateViewModel(Part component)
        {
            return new PartViewModel
            {
                Id = component.Id,
                PartName = component.PartName,
                PartPrice = component.PartPrice
            };
        }
    }
}
