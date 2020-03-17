namespace Lab3
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
            this.btnRefil = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.txtOut = new System.Windows.Forms.RichTextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.txtThread = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnRefil
            // 
            this.btnRefil.Location = new System.Drawing.Point(12, 12);
            this.btnRefil.Name = "btnRefil";
            this.btnRefil.Size = new System.Drawing.Size(246, 23);
            this.btnRefil.TabIndex = 0;
            this.btnRefil.Text = "Перезаполнить";
            this.btnRefil.UseVisualStyleBackColor = true;
            this.btnRefil.Click += new System.EventHandler(this.btnRefil_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfo.Location = new System.Drawing.Point(12, 41);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(246, 33);
            this.txtInfo.TabIndex = 1;
            this.txtInfo.Text = "Информация о животных";
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(12, 79);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(165, 96);
            this.txtOut.TabIndex = 2;
            this.txtOut.Text = "Информация о животном";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(183, 79);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 96);
            this.btnGet.TabIndex = 3;
            this.btnGet.Text = "Взять";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // txtThread
            // 
            this.txtThread.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtThread.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtThread.Location = new System.Drawing.Point(264, 12);
            this.txtThread.Name = "txtThread";
            this.txtThread.ReadOnly = true;
            this.txtThread.Size = new System.Drawing.Size(82, 163);
            this.txtThread.TabIndex = 4;
            this.txtThread.Text = "Очередь";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 185);
            this.Controls.Add(this.txtThread);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtOut);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnRefil);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRefil;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.RichTextBox txtOut;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.RichTextBox txtThread;
    }
}

