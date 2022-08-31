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

    public partial class OstadMenu : Form
    {
        OstadMadov ostadEnterd1=null;
        OstadheyatElmi ostadEnterd2=null;
        HeadOfDepartment ostadEnterd3=null;
        ModirGP ostadEnterd4=null;


        Student SearchStudent = null;
        GuestStudent SearchGuestStudent = null;

        public OstadMenu(Object os1)
        {
            InitializeComponent();
            string namelabel="";
            ToolStripMenuItemAddOstadmadov.Enabled = false;

            if (os1 is HeadOfDepartment)
            {
                ostadEnterd3 = (HeadOfDepartment)os1;
                namelabel = ostadEnterd3.FirstName + " " + ostadEnterd3.LastName;
                ToolStripMenuItemAddOstadmadov.Enabled = true;
            }
            else if(os1 is ModirGP)
            {
                ostadEnterd4 = (ModirGP)os1;
                namelabel = ostadEnterd4.FirstName + " " + ostadEnterd4.LastName;
                ToolStripMenuItemAmaarLessons.Enabled = true;
                toolstripmenuItemAddLesson.Enabled = true;
            }
            else if(os1 is OstadheyatElmi)
            {
                ostadEnterd2 = (OstadheyatElmi)os1;
                if (ostadEnterd2.IsRahnama)
                {
                    ToolStripMenuItem t1 = new ToolStripMenuItem();
                    t1.Text = "استاد راهنما";
                    menuStrip1.Items.Add(t1);
                }
                namelabel = ostadEnterd2.FirstName + " " + ostadEnterd2.LastName;

            }
            else if(os1 is OstadMadov)
            {
                ostadEnterd1 = (OstadMadov)os1;
                namelabel = ostadEnterd1.FirstName + " " + ostadEnterd1.LastName;
            }
            lblSayHi.Text += " وقت بخیر " + namelabel;

            if (!(os1 is ModirGP))
                tabPageAmaarLesson.Dispose();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.ShowDialog();
            this.Close();
        }

        private void OstadMenu_Load(object sender, EventArgs e)
        {
            persianCal();
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 800;
            timer.Start();
            tabControl1.Hide();
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

        private void ToolStripMenuItemLessonInprogress_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
            // tabPage2.Focus();
            tabControl1.SelectedTab = tabPage1;
            tabPage1_Enter(null, null);
        }

        private void ToolStripMenuItemChangePass_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
           // tabPage2.Focus();
            tabControl1.SelectedTab = tabPage2;

        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            //if(ostadEnterd1!=null)
            //{
            //    txtboxFirstName.Text = ostadEnterd1.FirstName;
            //    txtboxLastName.Text = ostadEnterd1.LastName;
            //    txtboxId.Text = ostadEnterd1.Id.ToString();
            //    txtBoxPassword.Text = ostadEnterd1.Password;
            //}
            //if (ostadEnterd1 != null)
            //{
            //    txtboxFirstName.Text = ostadEnterd1.FirstName;
            //    txtboxLastName.Text = ostadEnterd1.LastName;
            //    txtboxId.Text = ostadEnterd1.Id.ToString();
            //    txtBoxPassword.Text = ostadEnterd1.Password;
            //}
            //if (ostadEnterd1 != null)
            //{
            //    txtboxFirstName.Text = ostadEnterd1.FirstName;
            //    txtboxLastName.Text = ostadEnterd1.LastName;
            //    txtboxId.Text = ostadEnterd1.Id.ToString();
            //    txtBoxPassword.Text = ostadEnterd1.Password;
            //}
            //if (ostadEnterd1 != null)
            //{
            //    txtboxFirstName.Text = ostadEnterd1.FirstName;
            //    txtboxLastName.Text = ostadEnterd1.LastName;
            //    txtboxId.Text = ostadEnterd1.Id.ToString();
            //    txtBoxPassword.Text = ostadEnterd1.Password;
            //}
            //if (ostadEnterd1 != null)
            //{
            //    txtboxFirstName.Text = ostadEnterd1.FirstName;
            //    txtboxLastName.Text = ostadEnterd1.LastName;
            //    txtboxId.Text = ostadEnterd1.Id.ToString();
            //    txtBoxPassword.Text = ostadEnterd1.Password;
            //}

            List<Ostad> ostads = new List<Ostad>(); //use polymorphism
            ostads.Add(ostadEnterd1);
            ostads.Add(ostadEnterd2);
            ostads.Add(ostadEnterd3);
            ostads.Add(ostadEnterd4);

            foreach(var ostad in ostads)
            {
                if (ostad != null)
                {
                    txtboxFirstName.Text = ostad.FirstName;
                    txtboxLastName.Text = ostad.LastName;
                    txtboxId.Text = ostad.Id.ToString();
                    txtBoxPassword.Text = ostad.Password;
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
                List<Ostad> ostads = new List<Ostad>(); //use polymorphism
                ostads.Add(ostadEnterd1);
                ostads.Add(ostadEnterd2);
                ostads.Add(ostadEnterd3);
                ostads.Add(ostadEnterd4);
                int counter = 0;

                foreach (var ostad in ostads)
                {
                    if (ostad != null)
                    {
                        ostad.Password = txtboxPassNew.Text;
                        break;
                    }
                    counter++;
                }
                
                
                if (ostads[counter] is HeadOfDepartment)
                {
                    HeadOfDepartment s1 =(HeadOfDepartment)ostads[counter];
                    string type = comboBox1.Text;

                    switch(type)
                    {
                        case "استادیار":
                            s1.Type = TypeOfOstad.استادیار;
                            break;
                        case "دانشیار":
                            s1.Type = TypeOfOstad.دانشیار;
                            break;
                        case "استاد":
                            s1.Type = TypeOfOstad.استاد;
                            break;
                        default:
                            MessageBox.Show("لطفا درجه استاد را وارد کنید");
                            break;
                    }

                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\HeadOfDepartmentBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"HeadOfDepartmentBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();
                }
                else if(ostads[counter] is ModirGP)
                {
                    ModirGP s1 = (ModirGP)ostads[counter];
                    string type = comboBox1.Text;

                    switch (type)
                    {
                        case "استادیار":
                            s1.Type = TypeOfOstad.استادیار;
                            break;
                        case "دانشیار":
                            s1.Type = TypeOfOstad.دانشیار;
                            break;
                        case "استاد":
                            s1.Type = TypeOfOstad.استاد;
                            break;
                        default:
                            MessageBox.Show("لطفا درجه استاد را وارد کنید");
                            break;
                    }
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\ModirGPBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"ModirGPBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();
                }
                else if(ostads[counter] is OstadheyatElmi)
                {
                    OstadheyatElmi s1 = (OstadheyatElmi)ostads[counter];
                    string type = comboBox1.Text;

                    switch (type)
                    {
                        case "استادیار":
                            s1.Type = TypeOfOstad.استادیار;
                            break;
                        case "دانشیار":
                            s1.Type = TypeOfOstad.دانشیار;
                            break;
                        case "استاد":
                            s1.Type = TypeOfOstad.استاد;
                            break;
                        default:
                            MessageBox.Show("لطفا درجه استاد را وارد کنید");
                            break;
                    }
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\OstadHeyatElmiBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"OstadHeyatElmiBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();
                }
                else if(ostads[counter] is OstadMadov)
                {
                    OstadMadov s1 = (OstadMadov)ostads[counter];
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\OstadMadovBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"OstadMadovBinary.txt";
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    formatter.Serialize(stream1, s1);
                    stream1.Close();
                }

                tabControl1.Hide();
            }
            else
                MessageBox.Show("رمز شما باید شامل حداقل یک حرف بزرگ و عدد باشد");


        }

        private void btnAddLesson_Click(object sender, EventArgs e)
        {
            LessonInTermForm x1 = new LessonInTermForm();
            this.Enabled = false;
            x1.ShowDialog();
            this.Enabled = true;
            tabPage1_Enter(null, null);
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            var tmpList = new List<lessonInTerm>();
            //string path1 = @"E:\Golestan project\golestan\golestan\Files\LessonsInTermBinary.txt";
            string path1 = Environment.CurrentDirectory + @"LessonsInTermBinary.txt";
            using (Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter deserializer = new BinaryFormatter();

                while (stream1.Position < stream1.Length)
                {
                    lessonInTerm temp = (lessonInTerm)deserializer.Deserialize(stream1);
                    tmpList.Add(temp);
                }
            }

            dataGridView1.DataSource = tmpList.ToArray();
        }

        private void ToolStripMenuItemAddOstadmadov_Click(object sender, EventArgs e)
        {
            SingUpOStadForm z1 = new SingUpOStadForm(true);
            z1.ShowDialog();
        }

        private void ToolStripMenuSabtNomre_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
            tabControl1.SelectedTab = tabPageSabteNomre;
            groupBoxInfo.Hide();
            tabPageSabteNomre_Enter(null, null);
        }

        private void tabPageSabteNomre_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearchId_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSearchId_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSearchId_TextChanged_1(object sender, EventArgs e)
        {
            if (textBoxSearchId.Text != "")
            {
                btnSearchId.Enabled = true;
            }
            else
                btnSearchId.Enabled = false;
        }

        private void btnSearchId_Click_1(object sender, EventArgs e)
        {


            // string path1 = @"E:\Golestan project\golestan\golestan\Files\StudentsBinary.txt";
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

                    if (temp.Id == Convert.ToInt32(textBoxSearchId.Text))
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


                    if (temp.Id == Convert.ToInt32(textBoxSearchId.Text))
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
                if (stream2 != null)
                    stream2.Close();
            }

            if (SearchStudent != null)
            {
                groupBoxInfo.Show();
                textBoxStudentFirstName.Text = SearchStudent.FirstName;
                textBoxStudentLastName.Text = SearchStudent.LastName;
                txtBoxBranch.Text = SearchStudent.Branch;
                txtboxStudentId.Text = SearchStudent.Id.ToString();
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
            }
            if (SearchGuestStudent != null)
            {
                groupBoxInfo.Show();
                textBoxStudentFirstName.Text = SearchGuestStudent.FirstName;
                textBoxStudentLastName.Text = SearchGuestStudent.LastName;
                txtBoxBranch.Text = SearchGuestStudent.Branch;
                txtboxStudentId.Text = SearchGuestStudent.Id.ToString();
                checkBox1.Checked = true;
                checkBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Ostad> ostads = new List<Ostad>(); //use polymorphism
            ostads.Add(ostadEnterd1);
            ostads.Add(ostadEnterd2);
            ostads.Add(ostadEnterd3);
            ostads.Add(ostadEnterd4);

            if (textboxNomre.Text != "")
            {
                if(SearchStudent!=null)
                {
                    foreach(var ostad in ostads)
                    {
                        if(ostad!=null)
                        {
                            SearchStudent.ListOfGrades.Add(new lesson(ostad.TeachingLesson), Convert.ToDouble(textboxNomre.Text));
                        }
                    }
                    
                }
                if(SearchGuestStudent!=null)
                {
                    foreach (var ostad in ostads)
                    {
                        if (ostad != null)
                        {
                            SearchGuestStudent.ListOfGrades.Add(new lesson(ostad.TeachingLesson), Convert.ToDouble(textboxNomre.Text));
                        }
                    }
                }

                //string path1 = @"E:\Golestan project\golestan\golestan\Files\StudentsBinary.txt";
                string path1 = Environment.CurrentDirectory + @"StudentsBinary.txt";
                IFormatter formatter = new BinaryFormatter();
                Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                formatter.Serialize(stream1, SearchStudent);
                stream1.Close();

                //string path2 = @"E:\Golestan project\golestan\golestan\Files\GuestStudentsBinary.txt";
                string path2 = Environment.CurrentDirectory + @"GuestStudentsBinary.txt";
                IFormatter formatter2 = new BinaryFormatter();
                Stream stream2 = new FileStream(path2, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                formatter.Serialize(stream2, SearchGuestStudent);
                stream2.Close();

                MessageBox.Show("تغییرات با موفقیت انجام شد");
                tabControl1.Hide();
            }
            else
                MessageBox.Show("لطفا نمره اخذ شده را وارد کنید");
        }

        private void toolstripmenuItemAddLesson_Click(object sender, EventArgs e)
        {
            LessonForm l1 = new LessonForm();
            l1.ShowDialog();
        }
    }
}
