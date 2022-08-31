using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
    public partial class KarmandMenu : Form
    {
        KarmandAmoozesh k1 = null;
        KarmandAmoozeshDaneshkade k2 = null;
        KarmandAmoozeshKol k3 = null;
        List<KarmandAmoozesh> karmands = new List<KarmandAmoozesh>();

        HeadOfDepartment searchHead = null;

        public KarmandMenu(object x)
        {
            InitializeComponent();

            if(x is KarmandAmoozeshKol)
            {
                k3 =(KarmandAmoozeshKol)x;
            }
            else if(x is KarmandAmoozeshDaneshkade)
            {
                k2 = (KarmandAmoozeshDaneshkade)x;
                tabPageAllStudentsInfo.Dispose();
                ToolStripMenuItemChangeStudentInfo.Dispose();
                toolstripmenuChooseHead.Dispose();
                tabPageChooseHead.Dispose();
            }
            else if(x is KarmandAmoozesh)
            {
                k1 = (KarmandAmoozesh)x;
                tabPageShowLessons.Dispose();
                ToolStripMenuItemShowLessons.Dispose();
                tabPageAllStudentsInfo.Dispose();
                ToolStripMenuItemChangeStudentInfo.Dispose();
                toolstripmenuChooseHead.Dispose();
                tabPageChooseHead.Dispose();
            }
            karmands.Add(k1);
            karmands.Add(k2);
            karmands.Add(k3);
        }

        private void KarmandMenu_Load(object sender, EventArgs e)
        {
            lblSayHi.Text += "خوش آمدید";
            persianCal();
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 800;
            timer.Start();
            tabControl1.Hide();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.ShowDialog();
            this.Close();
        }

        private void persianCal()
        {
            PersianCalendar p = new PersianCalendar();
            DateTime dt = DateTime.Now;
            int y, m, d;
            y = p.GetYear(dt);
            m = p.GetMonth(dt);
            d = p.GetDayOfMonth(dt);
            lblDate.Text = y.ToString() + "/"
            + m.ToString() + "/"
            + d.ToString();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss tt");//zaman ro mide
        }

        private void ToolStripMenuItemChangePass_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
            tabControl1.SelectedTab = tabPageEditPass;
            tabPageEditPass_Enter(null, null);
        }

        private void tabPageEditPass_Enter(object sender, EventArgs e)
        {
            foreach (var karmand in karmands)
            {
                if (karmand != null)
                {
                    txtboxId.Text = karmand.Id.ToString();
                    txtBoxPassword.Text = karmand.Password;
                }
            }
        }

        private void SaveBut_Click(object sender, EventArgs e)
        {
            var input = txtboxPassNew.Text;
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);

            if (isValidated)
            {
                int counter = 0;

                foreach (var karmand in karmands)
                {
                    if (karmand != null)
                    {
                        karmand.Password = txtboxPassNew.Text;
                        break;
                    }
                    counter++;
                }


                if (karmands[counter] is KarmandAmoozeshKol)
                {
                    // string path1 = @"E:\Golestan project\golestan\golestan\Files\KarmandAmoozeshKolBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"KarmandAmoozeshKolBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    formatter.Serialize(stream1, karmands[counter]);
                    stream1.Close();
                }
                else if (karmands[counter] is KarmandAmoozeshDaneshkade)
                {
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\KarmandAmoozeshDaneshkadeBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"KarmandAmoozeshDaneshkadeBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    formatter.Serialize(stream1, karmands[counter]);
                    stream1.Close();
                }
                else if (karmands[counter] is KarmandAmoozesh)
                {
                   // string path1 = @"E:\Golestan project\golestan\golestan\Files\KarmandAmoozeshBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"KarmandAmoozeshBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    formatter.Serialize(stream1, karmands[counter]);
                    stream1.Close();
                }
                MessageBox.Show("تغییرات با موفقیت انجام شد");
                tabControl1.Hide();
            }
            else
                MessageBox.Show("رمز شما باید شامل حداقل یک حرف بزرگ و عدد باشد");


        }

        private void ToolStripMenuItemAllStudents_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
            tabControl1.SelectedTab = tabPageAllStudentsInfo;
            tabPageAllStudentsInfo_Enter(null, null);
        }

        private void tabPageAllStudentsInfo_Enter(object sender, EventArgs e)
        {
            List<Student> AllStudents = new List<Student>();

            //string path1 = @"E:\Golestan project\golestan\golestan\Files\StudentsBinary.txt";
            string path1 = Environment.CurrentDirectory + @"StudentsBinary.txt";
            Stream stream1;
            try
            {
                stream1 = new FileStream(path1, FileMode.Open, FileAccess.Read);

                BinaryReader br1 = new BinaryReader(stream1, Encoding.GetEncoding("iso-8859-1"));
                IFormatter formatter = new BinaryFormatter();

                while (stream1.Position < stream1.Length)
                {
                    Student temp = (Student)formatter.Deserialize(stream1);
                    AllStudents.Add(temp);

                }
            }
            catch
            {
                stream1 = null;
            }

            //-----------------------------------------
            //string path2 = @"E:\Golestan project\golestan\golestan\Files\GuestStudentsBinary.txt";
            string path2 = Environment.CurrentDirectory + @"GuestStudentsBinary.txt";
            Stream stream2;
            try
            {
                stream2 = new FileStream(path2, FileMode.Open, FileAccess.Read);

                BinaryReader br2 = new BinaryReader(stream2, Encoding.GetEncoding("iso-8859-1"));
                IFormatter formatter2 = new BinaryFormatter();

                while (stream2.Position < stream2.Length)
                {
                    GuestStudent temp = (GuestStudent)formatter2.Deserialize(stream2);
                    AllStudents.Add(temp);
                }

            }
            catch
            {
                stream2 = null;
            }

            dataGridView1.DataSource = AllStudents.ToList();
        }

        private void ToolStripMenuItemShowLessons_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
            tabControl1.SelectedTab = tabPageShowLessons;
            tabPageShowLessons_Enter(null, null);
        }

        private void tabPageShowLessons_Enter(object sender, EventArgs e)
        {
            List<lesson> listOfLessons = new List<lesson>();
            //string path1 = @"E:\Golestan project\golestan\golestan\Files\LessonsBinary.txt";
            string path1 = Environment.CurrentDirectory + @"LessonsBinary.txt";

            using (Stream stream1 = new FileStream(path1, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter deserializer = new BinaryFormatter();

                while (stream1.Position < stream1.Length)
                {
                    lesson temp = (lesson)deserializer.Deserialize(stream1);
                    listOfLessons.Add(temp);
                }
            }

            dataGridView2.DataSource = listOfLessons.ToArray();
        }

        private void ToolStripMenuItemChangeStudentInfo_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
            tabControl1.SelectedTab = tabPageChangeStudentInfo;
            groupBoxInfo.Hide();
            tabPageChangeStudentInfo_Enter(null, null);
        }

        private void tabPageChangeStudentInfo_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBoxSearchId_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearchId.Text != "")
            {
                btnSearchId.Enabled = true;
            }
            else
                btnSearchId.Enabled = false;
        }

        private void btnSearchId_Click(object sender, EventArgs e)
        {
            Student SearchStudent=null;
            GuestStudent SearchGuestStudent=null;

            //string path1 = @"E:\Golestan project\golestan\golestan\Files\StudentsBinary.txt";
            string path1 = Environment.CurrentDirectory + @"StudentsBinary.txt";
            Stream stream1 = null;
            try
            {
                stream1 = new FileStream(path1, FileMode.Open, FileAccess.Read);

                BinaryReader br1 = new BinaryReader(stream1, Encoding.GetEncoding("iso-8859-1"));
                IFormatter formatter = new BinaryFormatter();

                while (stream1.Position < stream1.Length)
                {
                    Student temp = (Student)formatter.Deserialize(stream1);

                   if(temp.Id==Convert.ToInt32(textBoxSearchId.Text))
                    {
                        SearchStudent = temp;
                    }

                }
            }
            catch
            {
                stream1 = null;
            }
            finally
            {
                stream1.Close();
            }



            //-----------------------------------------
            //string path2 = @"E:\Golestan project\golestan\golestan\Files\GuestStudentsBinary.txt";
            string path2 = Environment.CurrentDirectory + @"GuestStudentsBinary.txt";
            Stream stream2 = null;
            try
            {
                stream2 = new FileStream(path2, FileMode.Open, FileAccess.Read);

                BinaryReader br2 = new BinaryReader(stream2, Encoding.GetEncoding("iso-8859-1"));
                IFormatter formatter2 = new BinaryFormatter();

                while (stream2.Position < stream2.Length)
                {
                    GuestStudent temp = (GuestStudent)formatter2.Deserialize(stream2);

                    
                    if(temp.Id==Convert.ToInt32(textBoxSearchId.Text))
                    {
                        SearchGuestStudent = temp;
                    }

                }

            }
            catch
            {
                stream2 = null;
            }
            finally
            {
                stream2.Close();
            }

            if(SearchStudent!=null)
            {
                groupBoxInfo.Show();
                txtboxFirstName.Text = SearchStudent.FirstName;
                txtboxLastName.Text = SearchStudent.LastName;
                txtBoxBranch.Text = SearchStudent.Branch;
                txtboxStudentId.Text = SearchStudent.Id.ToString();
                textBoxStudentPass.Text = SearchStudent.Password;
                txtBoxVahed.Text = SearchStudent.VahedPassed.ToString();
                txtBoxAvrgeMark.Text = SearchStudent.AvrageMark.ToString();
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
            }
            if(SearchGuestStudent!=null)
            {
                groupBoxInfo.Show();
                txtboxFirstName.Text = SearchGuestStudent.FirstName;
                txtboxLastName.Text = SearchGuestStudent.LastName;
                txtBoxBranch.Text = SearchGuestStudent.Branch;
                txtboxStudentId.Text = SearchGuestStudent.Id.ToString();
                textBoxStudentPass.Text = SearchGuestStudent.Password;
                txtBoxVahed.Text = SearchGuestStudent.VahedPassed.ToString();
                txtBoxAvrgeMark.Text = SearchGuestStudent.AvrageMark.ToString();
                checkBox1.Checked = true;
                checkBox1.Enabled = false;
            }

        }

        private void toolstripmenuChooseHead_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
            tabControl1.SelectedTab = tabPageChooseHead;
            tabPageChooseHead_Enter(null, null);
        }

        private void tabPageChooseHead_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxSearchHeadId_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearchHeadId.Text != "")
            {
                btnSearchOstadId.Enabled = true;
            }
            else
                btnSearchOstadId.Enabled = false;
        }

        private void btnSearchOstadId_Click(object sender, EventArgs e)
        {

            //string path1 = @"E:\Golestan project\golestan\golestan\Files\HeadOfDepartmentBinary.txt";
            string path1 = Environment.CurrentDirectory + @"HeadOfDepartmentBinary.txt";
            Stream stream1 = null;
            try
            {
                stream1 = new FileStream(path1, FileMode.Open, FileAccess.Read);

                BinaryReader br1 = new BinaryReader(stream1, Encoding.GetEncoding("iso-8859-1"));
                IFormatter formatter = new BinaryFormatter();

                while (stream1.Position < stream1.Length)
                {
                    HeadOfDepartment temp = (HeadOfDepartment)formatter.Deserialize(stream1);

                    if (temp.Id == Convert.ToInt32(textBoxSearchHeadId.Text))
                    {
                        searchHead = temp;
                        textBoxDaneshkade.Text = temp.DepartmentName;
                    }

                }
            }
            catch
            {
                stream1 = null;
            }
            finally
            {
                if(stream1 != null)
                    stream1.Close();
            }

            if (searchHead != null)
            {
                textBoxDaneshkade.Text = searchHead.DepartmentName;
            }
            else
                MessageBox.Show("شماره پرسنلی اشتباه است");
        }

        private void btnSaveHead_Click(object sender, EventArgs e)
        {
            if (textBoxDaneshkade.Text != "")
            {
                try
                {
                    searchHead.DepartmentName = textBoxDaneshkade.Text;
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\HeadOfDepartmentBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"HeadOfDepartmentBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    formatter.Serialize(stream1, searchHead);
                    stream1.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("تغییرات با موفقیت انجام شد");
                tabControl1.Hide();
            }
        }
    }
}
