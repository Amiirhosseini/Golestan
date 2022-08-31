using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace golestan
{
    public partial class SingUpStudentForm : Form
    {
        public SingUpStudentForm()
        {
            InitializeComponent();
            btnEnter.Enabled = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SaveBut_Click(object sender, EventArgs e)
        {
            var input = txtBoxPassword.Text;
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);

            if (isValidated)
            {
                //Student s1 = new Student(txtboxFirstName.Text, txtboxLastName.Text, Convert.ToInt32(txtboxId.Text), txtBoxBranch.Text, txtBoxPassword.Text);
                //string path1 = @"E:\Golestan project\golestan\golestan\Files\Students.txt";

                //string input1 = txtboxFirstName.Text + "/" + txtboxLastName.Text + "/" + txtboxId.Text + "/" + txtBoxBranch.Text + "/" + txtBoxPassword.Text +"\n";

                //File.AppendAllText(path1, input1);

                if (checkBox1.Checked)
                {
                    GuestStudent s1 = new GuestStudent(txtboxFirstName.Text, txtboxLastName.Text, Convert.ToInt32(txtboxId.Text), txtBoxBranch.Text, txtBoxPassword.Text);
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\GuestStudentsBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"GuestStudentsBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();
                }
                else
                {
                    Student s1 = new Student(txtboxFirstName.Text, txtboxLastName.Text, Convert.ToInt32(txtboxId.Text), txtBoxBranch.Text, txtBoxPassword.Text);
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\StudentsBinary.txt";
                   // Directory.CreateDirectory(@"\Files\");
                    string path1 = Environment.CurrentDirectory + @"StudentsBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();
                }

                MessageBox.Show("دانشجو با موفقیت اضافه شد");
                btnEnter.Enabled = true;
                btnEnter.BackColor = Color.Green;
            }
            else
                MessageBox.Show("رمز شما باید شامل حداقل یک حرف بزرگ و عدد باشد");



            

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.ShowDialog();
            this.Close();
        }
    }
}
