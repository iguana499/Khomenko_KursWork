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
    public partial class FormAddWork : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IWork logic;
        private int? id;
        private Dictionary<int, (string, int, int)> WorkParts;

        public FormAddWork(IWork service)
        {
            InitializeComponent();
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("PartName", "Компонент");
            dataGridView.Columns.Add("Count", "Количество");
            dataGridView.Columns.Add("PartPrice", "Стоимость");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.logic = service;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormWorkParts>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (WorkParts.ContainsKey(form.Id))
                {
                    WorkParts[form.Id] = (form.ComponentName, form.Count, form.partPrice);
                }
                else
                {
                    WorkParts.Add(form.Id, (form.ComponentName, form.Count, form.partPrice));
                }
                LoadData();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (WorkParts == null || WorkParts.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                int sum = 0;
                for (int i=1; i<=WorkParts.Count; i++)
                {
                    sum = sum + WorkParts[i].Item3;
                }
                logic.CreateOrUpdate(new WorkBindingModel
                {
                    Id = id,
                    WorkName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text) + sum,
                    WorkParts = WorkParts
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void FormAddWork_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    WorkViewModel view = logic.Read(new WorkBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.WorkName;
                        textBoxPrice.Text = view.Price.ToString();
                        WorkParts = view.WorkParts;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                WorkParts = new Dictionary<int, (string, int, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (WorkParts != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in WorkParts)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2, pc.Value.Item3 });
                    }
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
