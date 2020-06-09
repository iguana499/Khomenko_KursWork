using STOBusinessLogic.Binding_models;
using STOBusinessLogic.Enums;
using STOBusinessLogic.Helpermodels;
using STOBusinessLogic.Interfaces;
using STOBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
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
        public void SendMessage(ReportBindingModel model)
        {
            MailAddress from = new MailAddress("labwork15kafis@gmail.com");
            MailAddress to = new MailAddress("goxaniguana@gmail.com");
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
