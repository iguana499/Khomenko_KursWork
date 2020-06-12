using STOBusinessLogic.Binding_models;
using STOBusinessLogic.BusinessLogics;
using STOBusinessLogic.Enums;
using STOBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STOView
{
    public partial class FormReportParts : Form
    {
        private readonly ReportLogic logic;
        private readonly IWork worklogic;
        public FormReportParts(ReportLogic logic, IWork work)
        {
            this.logic = logic;
            this.worklogic = work;
            InitializeComponent();
        }

        [Obsolete]
        private void buttonPdf_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            var works = worklogic.Read(null);
            foreach (var work in works)
            {
                if (work.DateImplement >= dateTimePickerFrom.Value && work.DateImplement <= dateTimePickerTo.Value && work.status == WorkStatus.Готов)
                {
                    ids.Add(work.Id);
                }
            }
            logic.PdfParts(new ReportBindingModel
            {
                FileName = "Report.pdf",
                worksId = ids

            });
            logic.SendMessage(new ReportBindingModel
            {
                FileName = "Report.pdf"
            });
            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [Obsolete]
        private void FormReportParts_Load(object sender, EventArgs e)
        {
            loadData();
        }

        [Obsolete]
        public void loadData()
        {
            List<int> ids = new List<int>();
            var works = worklogic.Read(null);
            foreach (var work in works)
            {
                if (work.DateImplement >= dateTimePickerFrom.Value && work.DateImplement <= dateTimePickerTo.Value && work.status == WorkStatus.Готов)
                {
                    ids.Add(work.Id);
                }
            }
            logic.PdfParts(new ReportBindingModel
            {
                FileName = "D:\\Report.pdf",
                worksId = ids

            });
            axAcroPDF1.src = "D:\\Report.pdf";
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            loadData();
        }
        
        
    }
}
