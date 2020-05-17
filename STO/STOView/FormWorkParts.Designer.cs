namespace STOView
{
    partial class FormWorkParts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxPart = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelKol = new System.Windows.Forms.Label();
            this.labelCom = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(198, 104);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(117, 104);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxPart
            // 
            this.comboBoxPart.FormattingEnabled = true;
            this.comboBoxPart.Location = new System.Drawing.Point(94, 10);
            this.comboBoxPart.Name = "comboBoxPart";
            this.comboBoxPart.Size = new System.Drawing.Size(235, 21);
            this.comboBoxPart.TabIndex = 9;
            this.comboBoxPart.SelectedIndexChanged += new System.EventHandler(this.comboBoxPart_SelectedIndexChanged);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(94, 35);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(236, 20);
            this.textBoxCount.TabIndex = 8;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // labelKol
            // 
            this.labelKol.AutoSize = true;
            this.labelKol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelKol.Location = new System.Drawing.Point(7, 34);
            this.labelKol.Name = "labelKol";
            this.labelKol.Size = new System.Drawing.Size(86, 17);
            this.labelKol.TabIndex = 7;
            this.labelKol.Text = "Количество";
            // 
            // labelCom
            // 
            this.labelCom.AutoSize = true;
            this.labelCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelCom.Location = new System.Drawing.Point(7, 9);
            this.labelCom.Name = "labelCom";
            this.labelCom.Size = new System.Drawing.Size(81, 17);
            this.labelCom.TabIndex = 6;
            this.labelCom.Text = "Компонент";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(94, 61);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(236, 20);
            this.textBoxPrice.TabIndex = 12;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelPrice.Location = new System.Drawing.Point(7, 61);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(78, 17);
            this.labelPrice.TabIndex = 13;
            this.labelPrice.Text = "Стоимость";
            // 
            // FormWorkParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 150);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxPart);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelKol);
            this.Controls.Add(this.labelCom);
            this.Name = "FormWorkParts";
            this.Text = "FormWorkParts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxPart;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelKol;
        private System.Windows.Forms.Label labelCom;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
    }
}