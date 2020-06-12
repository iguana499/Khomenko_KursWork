using STOBusinessLogic.Binding_models;
using STOBusinessLogic.BusnessLogics;
using STOBusinessLogic.Enums;
using STOBusinessLogic.Helpermodels;
using STOBusinessLogic.HelperModels;
using STOBusinessLogic.Interfaces;
using STOBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace STOBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IWork work;
        private readonly IPart part;
        public ReportLogic(IWork work, IPart part)
        {
            this.work = work;
            this.part = part;
        }
        public void DocWorks(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Работы",
                Works = GetWorks(model)
            });
        }
        public void ExcelWorks(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Работы",
                Works = GetWorks(model)
            });
        }

        [Obsolete]
        public void PdfParts(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Детали",
                Works = GetParts(model)
            });
        }
        public List<ReportWorksViewModel> GetWorks(ReportBindingModel model)
        {
            var list = new List<ReportWorksViewModel>();
            var works = work.Read(null);
            foreach (var Work in works)
            {
               
                        if (Work.status == WorkStatus.Готов)
                        {
                            var record = new ReportWorksViewModel
                            {
                                WorkName = Work.WorkName, Price = Work.Price, Status = Work.status
                            };
                            list.Add(record);
                        }
                    
                
            }
            return list;
        }
        public List<ReportPartsViewModel> GetParts(ReportBindingModel model) 
        {
            var list = new List<ReportPartsViewModel>();
            if (model.worksId == null)
            {
                return null;
            }
            foreach (var WorkId in model.worksId)
            {
                var parts = part.Read(null);
                var works = this.work.Read(new WorkBindingModel()
                {
                    Id = WorkId
                });
                foreach (var work in works)
                {
                    foreach (var part in parts)
                    {
                        if (work.WorkParts.ContainsKey(part.Id))
                        {
                            var record = new ReportPartsViewModel
                            {
                                WorkName = work.WorkName,
                                PartName = part.PartName,
                                date = work.DateImplement,
                                count = work.WorkParts[part.Id].Item2
                            };
                            list.Add(record);
                        }
                    }
                }
            }
            return list;
        }
        public void SendMessage(ReportBindingModel model)
        {
            MailAddress from = new MailAddress("labwork15kafis@gmail.com");
            MailAddress to = new MailAddress(ConfigurationManager.AppSettings["Email"]);
            MailMessage m = new MailMessage(from, to);
            m.Attachments.Add(new Attachment(model.FileName));
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("labwork15kafis@gmail.com", "passlab15");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
