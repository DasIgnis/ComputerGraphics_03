namespace FloodFill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.penBtn = new System.Windows.Forms.RadioButton();
            this.fillBtn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(63, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 180);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // colorPanel
            // 
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorPanel.Location = new System.Drawing.Point(11, 145);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(38, 38);
            this.colorPanel.TabIndex = 4;
            this.colorPanel.Click += new System.EventHandler(this.colorPanel_Click);
            // 
            // penBtn
            // 
            this.penBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.penBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.penBtn.AutoSize = true;
            this.penBtn.Image = ((System.Drawing.Image)(resources.GetObject("penBtn.Image")));
            this.penBtn.Location = new System.Drawing.Point(0, 0);
            this.penBtn.Name = "penBtn";
            this.penBtn.Size = new System.Drawing.Size(38, 38);
            this.penBtn.TabIndex = 5;
            this.penBtn.TabStop = true;
            this.penBtn.UseVisualStyleBackColor = true;
            // 
            // fillBtn
            // 
            this.fillBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.fillBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.fillBtn.AutoSize = true;
            this.fillBtn.Image = ((System.Drawing.Image)(resources.GetObject("fillBtn.Image")));
            this.fillBtn.Location = new System.Drawing.Point(1, 44);
            this.fillBtn.Name = "fillBtn";
            this.fillBtn.Size = new System.Drawing.Size(38, 38);
            this.fillBtn.TabIndex = 6;
            this.fillBtn.TabStop = true;
            this.fillBtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fillBtn);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.penBtn);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(39, 126);
            this.panel1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(0, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 38);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 204);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.RadioButton penBtn;
        private System.Windows.Forms.RadioButton fillBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}

