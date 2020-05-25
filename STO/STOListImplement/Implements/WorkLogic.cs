using STOBusinessLogic.Binding_models;
using STOBusinessLogic.Interfaces;
using STOBusinessLogic.View_models;
using STOListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STOListImplement.Implements
{
    public class WorkLogic : IWork
    {
        private readonly DataListSingleton source;
        public WorkLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(WorkBindingModel model)
        {
            Work tempProduct = model.Id.HasValue ? null : new Work { Id = 1 };
            foreach (var product in source.Works)
            {
                if (product.WorkName == model.WorkName && product.Id != model.Id)
                {
                    throw new Exception("Уже есть работа с таким названием");
                }
                if (!model.Id.HasValue && product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
                else if (model.Id.HasValue && product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempProduct == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempProduct);
            }
            else
            {
                source.Works.Add(CreateModel(model, tempProduct));
            }
        }

        public void Delete(WorkBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<WorkViewModel> Read(WorkBindingModel model)
        {
            List<WorkViewModel> result = new List<WorkViewModel>();
            foreach (var component in source.Works)
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
        private Work CreateModel(WorkBindingModel model, Work product)
        {
            product.WorkName = model.WorkName;
            product.Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.WorkParts.Count; ++i)
            {
                if (source.WorkParts[i].Id > maxPCId)
                {
                    maxPCId = source.WorkParts[i].Id;
                }
                if (source.WorkParts[i].workId == product.Id)
                {
                    if
                    (model.WorkParts.ContainsKey(source.WorkParts[i].partId))
                    {
                        source.WorkParts[i].count =
                        model.WorkParts[source.WorkParts[i].partId].Item2;
                        source.WorkParts[i].partPrice =
                        model.WorkParts[source.WorkParts[i].partId].Item3;
                        model.WorkParts.Remove(source.WorkParts[i].partId);
                    }
                    else
                    {
                        source.WorkParts.RemoveAt(i--);
                     }
                }
            }
            // новые записи
            foreach (var pc in model.WorkParts)
            {
                source.WorkParts.Add(new WorkParts
                {
                    Id = ++maxPCId,
                    workId = product.Id,
                    partId = pc.Key,
                    count = pc.Value.Item2,
                    partPrice = pc.Value.Item3
                });
            }
            return product;
        }
        private WorkViewModel CreateViewModel(Work product)
        {
            // требуется дополнительно получить список компонентов для изделия с
            Dictionary<int, (string, int, int)> productComponents = new Dictionary<int,
    (string, int, int)>();
            foreach (var pc in source.WorkParts)
            {
                if (pc.workId == product.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Parts)
                    {
                        if (pc.partId == component.Id)
                        {
                            componentName = component.PartName;
                            break;
                        }
                    }
                    productComponents.Add(pc.partId, (componentName, pc.count, pc.partPrice));
                }
            }
            return new WorkViewModel
            {
                Id = product.Id,
                WorkName = product.WorkName,
                Price = product.Price,
                WorkParts = productComponents
            };
        }

    }
}
