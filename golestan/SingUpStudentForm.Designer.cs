﻿namespace golestan
{
    partial class SingUpStudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingUpStudentForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEnter = new System.Windows.Forms.Button();
            this.SaveBut = new System.Windows.Forms.Button();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.txtBoxBranch = new System.Windows.Forms.TextBox();
            this.passtex = new System.Windows.Forms.Label();
            this.branchTex = new System.Windows.Forms.Label();
            this.txtboxId = new System.Windows.Forms.TextBox();
            this.txtboxLastName = new System.Windows.Forms.TextBox();
            this.StudentNumberTex = new System.Windows.Forms.Label();
            this.txtboxFirstName = new System.Windows.Forms.TextBox();
            this.LastNameTex = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstNameTex = new System.Windows.Forms.Label();
            this.requiredFieldValidator1 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.requiredFieldValidator2 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.requiredFieldValidator3 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.requiredFieldValidator4 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.requiredFieldValidator5 = new ValidationComponents.RequiredFieldValidator(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.btnEnter);
            this.panel2.Controls.Add(this.SaveBut);
            this.panel2.Controls.Add(this.txtBoxPassword);
            this.panel2.Controls.Add(this.txtBoxBranch);
            this.panel2.Controls.Add(this.passtex);
            this.panel2.Controls.Add(this.branchTex);
            this.panel2.Controls.Add(this.txtboxId);
            this.panel2.Controls.Add(this.txtboxLastName);
            this.panel2.Controls.Add(this.StudentNumberTex);
            this.panel2.Controls.Add(this.txtboxFirstName);
            this.panel2.Controls.Add(this.LastNameTex);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.FirstNameTex);
            this.panel2.Location = new System.Drawing.Point(42, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(445, 404);
            this.panel2.TabIndex = 2;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Silver;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Location = new System.Drawing.Point(67, 329);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(162, 27);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "ورود به سامانه ";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // SaveBut
            // 
            this.SaveBut.BackColor = System.Drawing.Color.Silver;
            this.SaveBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBut.Location = new System.Drawing.Point(67, 290);
            this.SaveBut.Name = "SaveBut";
            this.SaveBut.Size = new System.Drawing.Size(75, 23);
            this.SaveBut.TabIndex = 3;
            this.SaveBut.Text = "ثبت";
            this.SaveBut.UseVisualStyleBackColor = false;
            this.SaveBut.Click += new System.EventHandler(this.SaveBut_Click);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxPassword.Location = new System.Drawing.Point(225, 222);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPassword.TabIndex = 1;
            // 
            // txtBoxBranch
            // 
            this.txtBoxBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxBranch.Location = new System.Drawing.Point(225, 184);
            this.txtBoxBranch.Name = "txtBoxBranch";
            this.txtBoxBranch.Size = new System.Drawing.Size(100, 20);
            this.txtBoxBranch.TabIndex = 1;
            // 
            // passtex
            // 
            this.passtex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.passtex.AutoSize = true;
            this.passtex.ForeColor = System.Drawing.Color.Black;
            this.passtex.Location = new System.Drawing.Point(346, 229);
            this.passtex.Name = "passtex";
            this.passtex.Size = new System.Drawing.Size(44, 13);
            this.passtex.TabIndex = 0;
            this.passtex.Text = "گذرواژه";
            // 
            // branchTex
            // 
            this.branchTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.branchTex.AutoSize = true;
            this.branchTex.ForeColor = System.Drawing.Color.Black;
            this.branchTex.Location = new System.Drawing.Point(347, 191);
            this.branchTex.Name = "branchTex";
            this.branchTex.Size = new System.Drawing.Size(30, 13);
            this.branchTex.TabIndex = 0;
            this.branchTex.Text = "رشته";
            // 
            // txtboxId
            // 
            this.txtboxId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxId.Location = new System.Drawing.Point(225, 151);
            this.txtboxId.Name = "txtboxId";
            this.txtboxId.Size = new System.Drawing.Size(100, 20);
            this.txtboxId.TabIndex = 1;
            // 
            // txtboxLastName
            // 
            this.txtboxLastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxLastName.Location = new System.Drawing.Point(225, 109);
            this.txtboxLastName.Name = "txtboxLastName";
            this.txtboxLastName.Size = new System.Drawing.Size(100, 20);
            this.txtboxLastName.TabIndex = 1;
            // 
            // StudentNumberTex
            // 
            this.StudentNumberTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentNumberTex.AutoSize = true;
            this.StudentNumberTex.ForeColor = System.Drawing.Color.Black;
            this.StudentNumberTex.Location = new System.Drawing.Point(346, 158);
            this.StudentNumberTex.Name = "StudentNumberTex";
            this.StudentNumberTex.Size = new System.Drawing.Size(87, 13);
            this.StudentNumberTex.TabIndex = 0;
            this.StudentNumberTex.Text = "شماره دانشجویی";
            // 
            // txtboxFirstName
            // 
            this.txtboxFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtboxFirstName.Location = new System.Drawing.Point(225, 71);
            this.txtboxFirstName.Name = "txtboxFirstName";
            this.txtboxFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtboxFirstName.TabIndex = 1;
            // 
            // LastNameTex
            // 
            this.LastNameTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LastNameTex.AutoSize = true;
            this.LastNameTex.ForeColor = System.Drawing.Color.Black;
            this.LastNameTex.Location = new System.Drawing.Point(346, 112);
            this.LastNameTex.Name = "LastNameTex";
            this.LastNameTex.Size = new System.Drawing.Size(69, 13);
            this.LastNameTex.TabIndex = 0;
            this.LastNameTex.Text = "نام خانوادگی";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(166, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "ثبت نام دانشجو";
            // 
            // FirstNameTex
            // 
            this.FirstNameTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstNameTex.AutoSize = true;
            this.FirstNameTex.ForeColor = System.Drawing.Color.Black;
            this.FirstNameTex.Location = new System.Drawing.Point(347, 74);
            this.FirstNameTex.Name = "FirstNameTex";
            this.FirstNameTex.Size = new System.Drawing.Size(20, 13);
            this.FirstNameTex.TabIndex = 0;
            this.FirstNameTex.Text = "نام";
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator1.ControlToValidate = this.txtboxFirstName;
            this.requiredFieldValidator1.ErrorMessage = "کادر مربوطه را پر کنید";
            this.requiredFieldValidator1.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator1.Icon")));
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator2.ControlToValidate = this.txtboxId;
            this.requiredFieldValidator2.ErrorMessage = "کادر مربوطه را پر کنید";
            this.requiredFieldValidator2.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator2.Icon")));
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator3.ControlToValidate = this.txtBoxBranch;
            this.requiredFieldValidator3.ErrorMessage = "کادر مربوطه را پر کنید";
            this.requiredFieldValidator3.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator3.Icon")));
            // 
            // requiredFieldValidator4
            // 
            this.requiredFieldValidator4.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator4.ControlToValidate = this.txtBoxPassword;
            this.requiredFieldValidator4.ErrorMessage = "کادر مربوطه را پر کنید";
            this.requiredFieldValidator4.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator4.Icon")));
            // 
            // requiredFieldValidator5
            // 
            this.requiredFieldValidator5.CancelFocusChangeWhenInvalid = false;
            this.requiredFieldValidator5.ControlToValidate = this.txtboxLastName;
            this.requiredFieldValidator5.ErrorMessage = "کادر مربوطه را پر کنید";
            this.requiredFieldValidator5.Icon = ((System.Drawing.Icon)(resources.GetObject("requiredFieldValidator5.Icon")));
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(225, 260);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "دانشجوی مهمان";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SingUpStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 423);
            this.Controls.Add(this.panel2);
            this.Name = "SingUpStudentForm";
            this.Text = "ثبت نام دانشجو";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SaveBut;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.TextBox txtBoxBranch;
        private System.Windows.Forms.Label passtex;
        private System.Windows.Forms.Label branchTex;
        private System.Windows.Forms.TextBox txtboxId;
        private System.Windows.Forms.TextBox txtboxLastName;
        private System.Windows.Forms.Label StudentNumberTex;
        private System.Windows.Forms.TextBox txtboxFirstName;
        private System.Windows.Forms.Label LastNameTex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label FirstNameTex;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator1;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator2;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator3;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator4;
        private ValidationComponents.RequiredFieldValidator requiredFieldValidator5;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}