﻿namespace STOView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запчастиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отправитьОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетВФорматеWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетВФорматеExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетВФорматеPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonChangeStatus = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникToolStripMenuItem,
            this.отправитьОтчетToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // справочникToolStripMenuItem
            // 
            this.справочникToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запчастиToolStripMenuItem});
            this.справочникToolStripMenuItem.Name = "справочникToolStripMenuItem";
            this.справочникToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.справочникToolStripMenuItem.Text = "Справочник";
            // 
            // запчастиToolStripMenuItem
            // 
            this.запчастиToolStripMenuItem.Name = "запчастиToolStripMenuItem";
            this.запчастиToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.запчастиToolStripMenuItem.Text = "Запчасти";
            this.запчастиToolStripMenuItem.Click += new System.EventHandler(this.запчастиToolStripMenuItem_Click);
            // 
            // отправитьОтчетToolStripMenuItem
            // 
            this.отправитьОтчетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчетВФорматеWordToolStripMenuItem,
            this.отчетВФорматеExcelToolStripMenuItem,
            this.отчетВФорматеPDFToolStripMenuItem});
            this.отправитьОтчетToolStripMenuItem.Name = "отправитьОтчетToolStripMenuItem";
            this.отправитьОтчетToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.отправитьОтчетToolStripMenuItem.Text = "Отправить отчет";
            // 
            // отчетВФорматеWordToolStripMenuItem
            // 
            this.отчетВФорматеWordToolStripMenuItem.Name = "отчетВФорматеWordToolStripMenuItem";
            this.отчетВФорматеWordToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.отчетВФорматеWordToolStripMenuItem.Text = "Отчет в формате Word";
            this.отчетВФорматеWordToolStripMenuItem.Click += new System.EventHandler(this.отчетВФорматеWordToolStripMenuItem_Click);
            // 
            // отчетВФорматеExcelToolStripMenuItem
            // 
            this.отчетВФорматеExcelToolStripMenuItem.Name = "отчетВФорматеExcelToolStripMenuItem";
            this.отчетВФорматеExcelToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.отчетВФорматеExcelToolStripMenuItem.Text = "Отчет в формате Excel";
            this.отчетВФорматеExcelToolStripMenuItem.Click += new System.EventHandler(this.отчетВФорматеExcelToolStripMenuItem_Click);
            // 
            // отчетВФорматеPDFToolStripMenuItem
            // 
            this.отчетВФорматеPDFToolStripMenuItem.Name = "отчетВФорматеPDFToolStripMenuItem";
            this.отчетВФорматеPDFToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.отчетВФорматеPDFToolStripMenuItem.Text = "Отчет в формате PDF";
            this.отчетВФорматеPDFToolStripMenuItem.Click += new System.EventHandler(this.отчетВФорматеPDFToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(674, 411);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(692, 27);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(96, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonChangeStatus
            // 
            this.buttonChangeStatus.Location = new System.Drawing.Point(693, 57);
            this.buttonChangeStatus.Name = "buttonChangeStatus";
            this.buttonChangeStatus.Size = new System.Drawing.Size(95, 23);
            this.buttonChangeStatus.TabIndex = 3;
            this.buttonChangeStatus.Text = "Работа готова";
            this.buttonChangeStatus.UseVisualStyleBackColor = true;
            this.buttonChangeStatus.Click += new System.EventHandler(this.buttonChangeStatus_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonChangeStatus);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "СТО \"Руки-крюки\"";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запчастиToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonChangeStatus;
        private System.Windows.Forms.ToolStripMenuItem отправитьОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетВФорматеWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетВФорматеExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетВФорматеPDFToolStripMenuItem;
    }
}