using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace golestan
{
    public partial class SIngUpKarmandzForm : Form
    {
        public SIngUpKarmandzForm()
        {
            InitializeComponent();
            btnEnter.Enabled = false;
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
                if (comboBox1.Text == "کارمند آموزش")
                {
                    KarmandAmoozesh s1 = new KarmandAmoozesh(Convert.ToInt32(txtboxId.Text),txtBoxPassword.Text);
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\KarmandAmoozeshBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"KarmandAmoozeshBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();

                    MessageBox.Show("کارمند با موفقیت اضافه شد");
                    btnEnter.Enabled = true;
                    btnEnter.BackColor = Color.Green;
                }
                else if (comboBox1.Text == "کارمند آموزش دانشکده")
                {
                    KarmandAmoozeshDaneshkade s1 = new KarmandAmoozeshDaneshkade(Convert.ToInt32(txtboxId.Text), txtBoxPassword.Text);
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\KarmandAmoozeshDaneshkadeBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"KarmandAmoozeshDaneshkadeBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();


                    MessageBox.Show("کارمند با موفقیت اضافه شد");
                    btnEnter.Enabled = true;
                    btnEnter.BackColor = Color.Green;

                }
                else if (comboBox1.Text == "کارمند آموزش کل")
                {
                    KarmandAmoozeshKol s1 = new KarmandAmoozeshKol(Convert.ToInt32(txtboxId.Text), txtBoxPassword.Text);
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\KarmandAmoozeshKolBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"KarmandAmoozeshKolBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();

                    MessageBox.Show("کارمند با موفقیت اضافه شد");
                    btnEnter.Enabled = true;
                    btnEnter.BackColor = Color.Green;
                }

                else
                {
                    MessageBox.Show("لطفا سمت کارمند را انتخاب کنید");

                }

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
      




   

