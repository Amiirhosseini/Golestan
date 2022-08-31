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
    public partial class SingUpOStadForm : Form
    {
        public SingUpOStadForm()
        {
            InitializeComponent();
            btnEnter.Enabled = false;
        }

        public SingUpOStadForm(bool isMadov)
        {
            InitializeComponent();
            btnEnter.Hide();
            comboBox1.Text = "استاد مدعو";
            comboBox1.Enabled = false;
        }

        private void SingUpOStadForm_Load(object sender, EventArgs e)
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
                //string path1 = @"E:\Golestan project\golestan\golestan\Files\Ostads.txt";

                //string input1 = txtboxFirstName.Text + "/" + txtboxLastName.Text + "/" + txtboxId.Text + "/" + txtBoxBranch.Text + "/" + txtBoxPassword.Text + "\n";

                //File.AppendAllText(path1, input1);

                if(comboBox1.Text== "استاد مدعو")
                {
                    OstadMadov s1 = new OstadMadov(txtboxFirstName.Text, txtboxLastName.Text, Convert.ToInt32(txtboxId.Text), txtBoxBranch.Text, txtBoxPassword.Text);
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\OstadMadovBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"OstadMadovBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();

                    MessageBox.Show("استاد با موفقیت اضافه شد");
                    btnEnter.Enabled = true;
                    btnEnter.BackColor = Color.Green;
                }
                else if(comboBox1.Text== "هیئت علمی")
                {
                    OstadheyatElmi s1 = new OstadheyatElmi(txtboxFirstName.Text, txtboxLastName.Text, Convert.ToInt32(txtboxId.Text), txtBoxBranch.Text, txtBoxPassword.Text);
                    DialogResult dialogResult = MessageBox.Show("آیا این استاد،استاد راهنما نیز میباشد؟", "استاد راهنما", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        s1.IsRahnama = true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        s1.IsRahnama = false;
                    }

                    // string path1 = @"E:\Golestan project\golestan\golestan\Files\OstadHeyatElmiBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"OstadHeyatElmiBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();


                    MessageBox.Show("استاد با موفقیت اضافه شد");
                    btnEnter.Enabled = true;
                    btnEnter.BackColor = Color.Green;

                }
                else if(comboBox1.Text== "رییس دانشکده")
                {
                    HeadOfDepartment s1 = new HeadOfDepartment(txtboxFirstName.Text, txtboxLastName.Text, Convert.ToInt32(txtboxId.Text), txtBoxBranch.Text, txtBoxPassword.Text);
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\HeadOfDepartmentBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"HeadOfDepartmentBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();

                    MessageBox.Show("استاد با موفقیت اضافه شد");
                    btnEnter.Enabled = true;
                    btnEnter.BackColor = Color.Green;
                }
                else if (comboBox1.Text == "مدیر گروه")
                {
                    ModirGP s1 = new ModirGP(txtboxFirstName.Text, txtboxLastName.Text, Convert.ToInt32(txtboxId.Text), txtBoxBranch.Text, txtBoxPassword.Text);
                    DialogResult dialogResult = MessageBox.Show("آیا این استاد،استاد راهنما نیز میباشد؟", "استاد راهنما", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        s1.IsRahnama = true;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        s1.IsRahnama = false;
                    }

                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\ModirGPBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"ModirGPBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();


                    MessageBox.Show("استاد با موفقیت اضافه شد");
                    btnEnter.Enabled = true;
                    btnEnter.BackColor = Color.Green;

                }
                else
                {
                    MessageBox.Show("لطفا سمت استاد را انتخاب کنید");
                    
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
