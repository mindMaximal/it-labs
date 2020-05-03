namespace Lab4
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
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.tbSpread = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFromColor = new System.Windows.Forms.Button();
            this.btnToColor = new System.Windows.Forms.Button();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLife = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRadius = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 97);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(776, 341);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(12, 12);
            this.tbDirection.Maximum = 90;
            this.tbDirection.Minimum = -90;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(104, 37);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.TickFrequency = 30;
            this.tbDirection.Value = -90;
            this.tbDirection.Scroll += new System.EventHandler(this.tdDirection_Scroll);
            // 
            // tbSpread
            // 
            this.tbSpread.Location = new System.Drawing.Point(122, 12);
            this.tbSpread.Maximum = 180;
            this.tbSpread.Name = "tbSpread";
            this.tbSpread.Size = new System.Drawing.Size(104, 37);
            this.tbSpread.TabIndex = 2;
            this.tbSpread.TickFrequency = 10;
            this.tbSpread.Scroll += new System.EventHandler(this.tdSpread_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Направление";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Разброс";
            // 
            // btnFromColor
            // 
            this.btnFromColor.Location = new System.Drawing.Point(233, 12);
            this.btnFromColor.Name = "btnFromColor";
            this.btnFromColor.Size = new System.Drawing.Size(75, 23);
            this.btnFromColor.TabIndex = 5;
            this.btnFromColor.Text = "From Color";
            this.btnFromColor.UseVisualStyleBackColor = true;
            this.btnFromColor.Click += new System.EventHandler(this.btnFromColor_Click);
            // 
            // btnToColor
            // 
            this.btnToColor.Location = new System.Drawing.Point(233, 41);
            this.btnToColor.Name = "btnToColor";
            this.btnToColor.Size = new System.Drawing.Size(75, 23);
            this.btnToColor.TabIndex = 6;
            this.btnToColor.Text = "To Color";
            this.btnToColor.UseVisualStyleBackColor = true;
            this.btnToColor.Click += new System.EventHandler(this.btnToColor_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(314, 12);
            this.tbSpeed.Maximum = 100;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(104, 37);
            this.tbSpeed.TabIndex = 7;
            this.tbSpeed.TickFrequency = 20;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Скорость";
            // 
            // tbLife
            // 
            this.tbLife.Location = new System.Drawing.Point(424, 12);
            this.tbLife.Maximum = 100;
            this.tbLife.Name = "tbLife";
            this.tbLife.Size = new System.Drawing.Size(104, 37);
            this.tbLife.TabIndex = 9;
            this.tbLife.TickFrequency = 10;
            this.tbLife.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Интенсивность";
            // 
            // tbRadius
            // 
            this.tbRadius.Location = new System.Drawing.Point(534, 12);
            this.tbRadius.Name = "tbRadius";
            this.tbRadius.Size = new System.Drawing.Size(104, 37);
            this.tbRadius.TabIndex = 11;
            this.tbRadius.Scroll += new System.EventHandler(this.tbRadius_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Размер капель (превращаем в пар)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbRadius);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbLife);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.btnToColor);
            this.Controls.Add(this.btnFromColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSpread);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.TrackBar tbSpread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFromColor;
        private System.Windows.Forms.Button btnToColor;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tbLife;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbRadius;
        private System.Windows.Forms.Label label5;
    }
}

