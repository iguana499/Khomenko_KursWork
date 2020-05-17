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
using Unity;

namespace STOView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IWork logic;
        public FormMain(IWork logic)
        {
            InitializeComponent();
            this.logic = logic;

        }

        private void запчастиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormParts>();
            form.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void работыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormWorks>();
            form.ShowDialog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddWork>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = true;
                    dataGridView.Columns[2].Visible = true;
                    dataGridView.Columns[3].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
