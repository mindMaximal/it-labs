namespace Lab2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRes = new System.Windows.Forms.Button();
            this.txtPlentyA = new System.Windows.Forms.TextBox();
            this.labelPlantyA = new System.Windows.Forms.Label();
            this.labelPlentyB = new System.Windows.Forms.Label();
            this.txtPlentyB = new System.Windows.Forms.TextBox();
            this.cmbOperation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonRes
            // 
            this.buttonRes.Location = new System.Drawing.Point(12, 158);
            this.buttonRes.Name = "buttonRes";
            this.buttonRes.Size = new System.Drawing.Size(165, 23);
            this.buttonRes.TabIndex = 1;
            this.buttonRes.Text = "Вычислить";
            this.buttonRes.UseVisualStyleBackColor = true;
            this.buttonRes.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPlentyA
            // 
            this.txtPlentyA.Location = new System.Drawing.Point(12, 81);
            this.txtPlentyA.Name = "txtPlentyA";
            this.txtPlentyA.Size = new System.Drawing.Size(165, 20);
            this.txtPlentyA.TabIndex = 2;
            // 
            // labelPlantyA
            // 
            this.labelPlantyA.AutoSize = true;
            this.labelPlantyA.Location = new System.Drawing.Point(13, 65);
            this.labelPlantyA.Name = "labelPlantyA";
            this.labelPlantyA.Size = new System.Drawing.Size(75, 13);
            this.labelPlantyA.TabIndex = 3;
            this.labelPlantyA.Text = "Множество А";
            // 
            // labelPlentyB
            // 
            this.labelPlentyB.AutoSize = true;
            this.labelPlentyB.Location = new System.Drawing.Point(12, 104);
            this.labelPlentyB.Name = "labelPlentyB";
            this.labelPlentyB.Size = new System.Drawing.Size(75, 13);
            this.labelPlentyB.TabIndex = 5;
            this.labelPlentyB.Text = "Множество B";
            // 
            // txtPlentyB
            // 
            this.txtPlentyB.Location = new System.Drawing.Point(12, 120);
            this.txtPlentyB.Name = "txtPlentyB";
            this.txtPlentyB.Size = new System.Drawing.Size(165, 20);
            this.txtPlentyB.TabIndex = 4;
            // 
            // cmbOperation
            // 
            this.cmbOperation.FormattingEnabled = true;
            this.cmbOperation.Items.AddRange(new object[] {
            "Объединение",
            "Пересечение",
            "Разность",
            "Добавление элемента",
            "Удаление элемента"});
            this.cmbOperation.Location = new System.Drawing.Point(12, 25);
            this.cmbOperation.Name = "cmbOperation";
            this.cmbOperation.Size = new System.Drawing.Size(165, 21);
            this.cmbOperation.TabIndex = 6;
            this.cmbOperation.Text = "Объединение";
            this.cmbOperation.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Выберете действие";
            // 
            // labelRes
            // 
            this.labelRes.AutoSize = true;
            this.labelRes.Location = new System.Drawing.Point(13, 197);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(0, 13);
            this.labelRes.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 328);
            this.Controls.Add(this.labelRes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbOperation);
            this.Controls.Add(this.labelPlentyB);
            this.Controls.Add(this.txtPlentyB);
            this.Controls.Add(this.labelPlantyA);
            this.Controls.Add(this.txtPlentyA);
            this.Controls.Add(this.buttonRes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRes;
        private System.Windows.Forms.TextBox txtPlentyA;
        private System.Windows.Forms.Label labelPlantyA;
        private System.Windows.Forms.Label labelPlentyB;
        private System.Windows.Forms.TextBox txtPlentyB;
        private System.Windows.Forms.ComboBox cmbOperation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRes;
    }
}

