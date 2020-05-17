using Microsoft.EntityFrameworkCore;
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
    public class WorkLogic : IWork
    {
        public void CreateOrUpdate(WorkBindingModel model)
        {
            using (var context = new STODataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Work element = context.Work.FirstOrDefault(rec =>
                       rec.WorkName == model.WorkName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Work.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new Work();
                            context.Work.Add(element);
                        }
                        element.WorkName = model.WorkName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var workParts = context.WorkParts.Where(rec
                           => rec.workId == model.Id.Value).ToList();
                            context.WorkParts.RemoveRange(workParts.Where(rec =>
                            !model.WorkParts.ContainsKey(rec.PartId)).ToList());
                            context.SaveChanges();
                            foreach (var updateComponent in workParts)
                            {
                                updateComponent.count =
                               model.WorkParts[updateComponent.PartId].Item2;
                                updateComponent.partPrice =
                               model.WorkParts[updateComponent.PartId].Item3;

                                model.WorkParts.Remove(updateComponent.PartId);
                            }
                            context.SaveChanges();
                        }
                        foreach (var pc in model.WorkParts)
                        {
                            context.WorkParts.Add(new WorkParts
                            {
                                workId = element.Id,
                                PartId = pc.Key,
                                count = pc.Value.Item2,
                                partPrice = pc.Value.Item3
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(WorkBindingModel model)
        {
            using (var context = new STODataBase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.WorkParts.RemoveRange(context.WorkParts.Where(rec =>
                        rec.workId == model.Id));
                        Work element = context.Work.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Work.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<WorkViewModel> Read(WorkBindingModel model)
        {
            using (var context = new STODataBase())
            {
                return context.Work
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new WorkViewModel
               {
                   Id = rec.Id,
                   WorkName = rec.WorkName,
                   Price = rec.Price,
                   WorkParts = context.WorkParts
                .Include(recPC => recPC.Part)
               .Where(recPC => recPC.workId == rec.Id)
               .ToDictionary(recPC => recPC.PartId, recPC =>
                (recPC.Part?.PartName, recPC.count,recPC.partPrice))
               })
               .ToList();
            }
        }
    }
}
