using STOBusinessLogic.Binding_models;
using STOBusinessLogic.Interfaces;
using STOBusinessLogic.View_models;
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
    public partial class FormWorkParts : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public readonly IPart logicP;
        public int Id
        {
            get { return Convert.ToInt32(comboBoxPart.SelectedValue); }
            set { comboBoxPart.SelectedValue = value; }
        }
        public string ComponentName { get { return comboBoxPart.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        public int partPrice
        {
            get { return Convert.ToInt32(textBoxPrice.Text); }
            set
            {
                textBoxPrice.Text = value.ToString();
            }
        }
        public FormWorkParts(IPart logic)
        {
            InitializeComponent();
            this.logicP = logic;
            List<PartViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxPart.DisplayMember = "PartName";
                comboBoxPart.ValueMember = "Id";
                comboBoxPart.DataSource = list;
                comboBoxPart.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxPart.SelectedValue == null)
            {
                MessageBox.Show("Выберите запчасть", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void CalcSum()
        {
            if (comboBoxPart.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxPart.SelectedValue);
                    PartViewModel product = logicP.Read(new PartBindingModel
                    {
                        Id =
                    id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxPrice.Text = (count * product?.PartPrice ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

    }
}
