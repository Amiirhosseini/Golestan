namespace golestan
{
    partial class SIngUpKarmandzForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SIngUpKarmandzForm));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.SaveBut = new System.Windows.Forms.Button();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.passtex = new System.Windows.Forms.Label();
            this.StudentNumberTex = new System.Windows.Forms.Label();
            this.txtboxId = new System.Windows.Forms.TextBox();
            this.requiredFieldValidator1 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.requiredFieldValidator2 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(239, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "ثبت کارمند";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.SaveBut);
            this.panel1.Controls.Add(this.txtBoxPassword);
            this.panel1.Controls.Add(this.passtex);
            this.panel1.Controls.Add(this.StudentNumberTex);
            this.panel1.Controls.Add(this.txtboxId);
            this.panel1.Location = new System.Drawing.Point(91, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 304);
            this.panel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(270, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "سمت کارمند";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "کارمند آموزش",
            "کارمند آموزش دانشکده",
            "کارمند آموزش کل"});
            this.comboBox1.Location = new System.Drawing.Point(130, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(118, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Silver;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Location = new System.Drawing.Point(15, 262);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(162, 27);
            this.btnEnter.TabIndex = 15;
            this.btnEnter.Text = "ورود به سامانه ";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // SaveBut
            // 
            this.SaveBut.BackColor = System.Drawing.Color.Silver;
            this.SaveBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBut.Location = new System.Drawing.Point(15, 233);
            this.SaveBut.Name = "SaveBut";
            this.SaveBut.Size = new System.Drawing.Size(75, 23);
            this.SaveBut.TabIndex = 14;
            this.SaveBut.Text = "ثبت";
            this.SaveBut.UseVisualStyleBackColor = false;
            this.SaveBut.Click += new System.EventHandler(this.SaveBut_Click);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxPassword.Location = new System.Drawing.Point(130, 49);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(118, 20);
            this.txtBoxPassword.TabIndex = 7;
            // 
            // passtex
            // 
            this.passtex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.passtex.AutoSize = true;
            this.passtex.ForeColor = System.Drawing.Color.Black;
            this.passtex.Location = new System.Drawing.Point(269, 56);
            this.passtex.Name = "passtex";
            this.passtex.Size = new System.Drawing.Size(44, 13);
            this.passtex.TabIndex = 2;
            this.passtex.Text = "گذرواژه";
            // 
            // StudentNumberTex
            // 
            this.StudentNumberTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentNumberTex.AutoSize = true;
            this.StudentNumberTex.ForeColor = System.Drawing.Color.Black;
            this.StudentNumberTex.Location = new System.Drawing.Point(269, 19);
            this.StudentNumberTex.Name = "StudentNumberTex";
            this.StudentNumberTex.Size = new System.Drawing.Size(57, 13);
            this.StudentNumberTex.TabIndex = 4;
            this.StudentNumberTex.Text = "کد پرسنلی";
            // 
            // txtboxId
            // 
            this.txtboxId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxId.Location = new System.Drawing.Point(130, 12);
            this.txtboxId.Name = "txtboxId";
            this.txtboxId.Size = new System.Drawing.Size(118, 20);
            this.txtboxId.TabIndex = 9;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator1.ControlToValidate = this.txtboxId;
            this.requiredFieldValidator1.ErrorMessage = null;
            this.requiredFieldValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator1.Icon")));
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator2.ControlToValidate = this.txtBoxPassword;
            this.requiredFieldValidator2.ErrorMessage = null;
            this.requiredFieldValidator2.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator2.Icon")));
            // 
            // SIngUpKarmandzForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 471);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "SIngUpKarmandzForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "ثبت نام کارمند";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button SaveBut;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Label passtex;
        private System.Windows.Forms.Label StudentNumberTex;
        private System.Windows.Forms.TextBox txtboxId;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator1;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator2;
    }
}