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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace golestan
{
    public partial class StudentMenu : Form
    {
        Student studentEntered=null;
        GuestStudent guestStudentEntered=null;
        List<lesson> listOfLessons = new List<lesson>();

        public StudentMenu(Object s1)
        {
            InitializeComponent();
            ToolStripMenuItemShahrie.Enabled = false;

            if (s1 is GuestStudent)
            {
                ToolStripMenuItemShahrie.Enabled = true;
                guestStudentEntered = (GuestStudent)s1;
                lblSayHi.Text += " وقت بخیر " + guestStudentEntered.FirstName + " " + guestStudentEntered.LastName;
            }
            else if (s1 is Student)
            {
                studentEntered = (Student)s1;
                tabPageShahrie.Dispose();
                lblSayHi.Text += " وقت بخیر " + studentEntered.FirstName + " " + studentEntered.LastName;
            }


            DataGridViewTextBoxColumn d1 = new DataGridViewTextBoxColumn();
            d1.Name = "نمره";
            dataGridView1.Columns.Add(d1);

        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.ShowDialog();
            this.Close();
        }

        private void StudentMenu_Load(object sender, EventArgs e)
        {
            persianCal();
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 800;
            timer.Start();
            tabControl1.Hide();
            tabPageShahrie.Hide();
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



        private void ToolStripStudnetInfo_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
            tabControl1.SelectedTab = tabPage1;
            tabPage1_Enter(null, null);
        }

        private void SaveBut_Click(object sender, EventArgs e)
        {
            //string path3 = @"E:\Golestan project\golestan\golestan\Files\LessonsBinary.txt";
            string path3 = Environment.CurrentDirectory + @"LessonsBinary.txt";

            using (Stream stream1 = new FileStream(path3, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter deserializer = new BinaryFormatter();

                while (stream1.Position < stream1.Length)
                {
                    lesson temp = (lesson)deserializer.Deserialize(stream1);
                    listOfLessons.Add(temp);
                }
            }

            if (studentEntered != null)
            {
                Student s1 = new Student(txtboxFirstName.Text, txtboxLastName.Text, Convert.ToInt32(txtboxId.Text), txtBoxBranch.Text, txtBoxPassword.Text);
                s1.AvrageMark = Convert.ToDouble(txtBoxAvrgeMark.Text);
                s1.VahedPassed = Convert.ToInt32(txtBoxVahed.Text);

                var checkedRows = this.dataGridView1.Rows.Cast<DataGridViewRow>() //for darsa
                      .Where(row => (bool?)row.Cells[0].Value == true)
                      .ToArray();

                for (int i = 0; i < listOfLessons.Count; i++)
                {
                    for (int j = 0; j < checkedRows.Length; j++)
                    {
                        if (i == checkedRows[j].Index)
                        {
                            s1.ListOfGrades.Add(listOfLessons[i], Convert.ToDouble(checkedRows[j].Cells[1].Value));
                        }
                    }
                }

                
                studentEntered = s1;
                //string path1 = @"E:\Golestan project\golestan\golestan\Files\StudentsBinary.txt";
                string path1 = Environment.CurrentDirectory + @"StudentsBinary.txt";
                IFormatter formatter = new BinaryFormatter();
                Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                formatter.Serialize(stream1, s1);
                stream1.Close();
            }
            else //for guest student
            {
                GuestStudent s1 = new GuestStudent(txtboxFirstName.Text, txtboxLastName.Text, Convert.ToInt32(txtboxId.Text), txtBoxBranch.Text, txtBoxPassword.Text);

                var checkedRows = this.dataGridView1.Rows.Cast<DataGridViewRow>() //for darsa
                      .Where(row => (bool?)row.Cells[0].Value == true)
                      .ToArray();

                for (int i = 0; i < listOfLessons.Count; i++)
                {
                    for (int j = 0; j < checkedRows.Length; j++)
                    {
                        if (i == checkedRows[j].Index)
                        {
                            s1.ListOfGrades.Add(listOfLessons[i], Convert.ToDouble(checkedRows[j].Cells[1].Value));
                        }
                    }
                }

                s1.AvrageMark = Convert.ToDouble(txtBoxAvrgeMark.Text);
                s1.VahedPassed = Convert.ToInt32(txtBoxVahed.Text);
                guestStudentEntered = s1;
                //string path1 = @"E:\Golestan project\golestan\golestan\Files\GuestStudentsBinary.txt";
                string path1 = Environment.CurrentDirectory + @"GuestStudentsBinary.txt";
                IFormatter formatter = new BinaryFormatter();
                Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                formatter.Serialize(stream1, s1);
                stream1.Close();
            }

            MessageBox.Show("تغییرات با موفقیت انجام شد");
            tabControl1.Hide();
        }

        private void btnAddLesson_Click(object sender, EventArgs e)
        {
            var l1 = new LessonForm();
            l1.ShowDialog();
            if (l1.ShowDialog() == DialogResult.Cancel)
                ToolStripStudnetInfo_Click(null, null);
        }

        private void ToolStripMenuItemSeeInfo_Click(object sender, EventArgs e)
        {
           
            //if (studentEntered != null)
            //{
            //    tabControl1.Show();
            //    tabControl1.SelectedTab = tabPage2;
            //    txtboxName2.Text = studentEntered.FirstName;
            //    txtboxLastName2.Text = studentEntered.LastName;
            //    textBoxAvrageMark2.Text = studentEntered.AvrageMark.ToString();
            //    textBoxBranch2.Text = studentEntered.Branch;
            //    textBoxId2.Text = studentEntered.Id.ToString();
            //    textBoxVahedpassed2.Text = studentEntered.VahedPassed.ToString();

            //    dataGridView2.DataSource = studentEntered.ListOfGrades.Keys.ToArray();
            //    //dataGridView2.Columns.Add("nomre", "نمره");



            //    //var lessons = from row in studentEntered.ListOfGrades select new { lesson = row.Key, grade = row.Value };
            //    //dataGridView1.DataSource = lessons.ToArray();
            //}
            //else
            //{
            //    tabControl1.Show();
            //    tabControl1.SelectedTab = tabPage1;
            //    txtboxFirstName.Text = guestStudentEntered.FirstName;
            //    txtboxLastName.Text = guestStudentEntered.LastName;
            //    txtboxId.Text = guestStudentEntered.Id.ToString();
            //    txtBoxBranch.Text = guestStudentEntered.Branch;
            //    txtBoxAvrgeMark.Text = guestStudentEntered.AvrageMark.ToString();
            //    txtBoxPassword.Text = guestStudentEntered.Password;
            //    txtBoxVahed.Text = guestStudentEntered.VahedPassed.ToString();
            //}

        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            listOfLessons.Clear();
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

            dataGridView1.DataSource = listOfLessons.ToArray();
            dataGridView1.Columns[0].HeaderText = "انتخاب";
            dataGridView1.Columns[2].HeaderText = "نام درس";
            dataGridView1.Columns[3].HeaderText = "تعداد واحد";
            dataGridView1.Columns[4].HeaderText = "نوع درس";

            if (studentEntered != null)
            {
                tabControl1.Show();
                tabControl1.SelectedTab = tabPage1;
                txtboxFirstName.Text = studentEntered.FirstName;
                txtboxLastName.Text = studentEntered.LastName;
                txtboxId.Text = studentEntered.Id.ToString();
                txtBoxBranch.Text = studentEntered.Branch;
                txtBoxAvrgeMark.Text = studentEntered.AvrageMark.ToString();
                txtBoxPassword.Text = studentEntered.Password;
                txtBoxVahed.Text = studentEntered.VahedPassed.ToString();

                foreach(var lesson in listOfLessons)
                {
                    foreach(var studentLesson in studentEntered.ListOfGrades)
                    {
                        if(lesson.Name==studentLesson.Key.Name)
                        {
                            dataGridView1.Rows[listOfLessons.FindIndex(a => a.Name == lesson.Name)].Cells[0].Value = true;
                            dataGridView1.Rows[listOfLessons.FindIndex(a => a.Name == lesson.Name)].Cells[1].Value = studentLesson.Value.ToString();
                        }
                    }
                }

                //var lessons = from row in studentEntered.ListOfGrades select new { lesson = row.Key, grade = row.Value };
                //dataGridView1.DataSource = lessons.ToArray();
            }
            else
            {
                tabControl1.Show();
                tabControl1.SelectedTab = tabPage1;
                txtboxFirstName.Text = guestStudentEntered.FirstName;
                txtboxLastName.Text = guestStudentEntered.LastName;
                txtboxId.Text = guestStudentEntered.Id.ToString();
                txtBoxBranch.Text = guestStudentEntered.Branch;
                txtBoxAvrgeMark.Text = guestStudentEntered.AvrageMark.ToString();
                txtBoxPassword.Text = guestStudentEntered.Password;
                txtBoxVahed.Text = guestStudentEntered.VahedPassed.ToString();

                foreach (var lesson in listOfLessons)
                {
                    foreach (var studentLesson in guestStudentEntered.ListOfGrades)
                    {
                        if (lesson.Name == studentLesson.Key.Name)
                        {
                            dataGridView1.Rows[listOfLessons.FindIndex(a => a.Name == lesson.Name)].Cells[0].Value = true;
                            dataGridView1.Rows[listOfLessons.FindIndex(a => a.Name == lesson.Name)].Cells[1].Value = studentLesson.Value.ToString();
                        }
                    }
                }
            }
            listOfLessons.Clear();
        
    }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            ToolStripMenuItemSeeInfo_Click(null, null);
        }

        private void ToolStripMenuItemShahrie_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
            tabControl1.SelectedTab = tabPageShahrie;
            tabPageShahrie_Enter(null, null);
        }

        private void tabPageShahrie_Enter(object sender, EventArgs e)
        {
            textBoxShahrie1.Text = guestStudentEntered.shahrieCalculator().ToString();
            textBoxShahrie2.Text = guestStudentEntered.ShahriePardakhtShode.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxShahrie2.Text) <= Convert.ToInt32(textBoxShahrie1.Text))
            {
                guestStudentEntered.ShahriePardakhtShode = Convert.ToInt32(textBoxShahrie2.Text);
                //string path1 = @"E:\Golestan project\golestan\golestan\Files\GuestStudentsBinary.txt";
                string path1 = Environment.CurrentDirectory + @"GuestStudentsBinary.txt";

                IFormatter formatter = new BinaryFormatter();
                Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                formatter.Serialize(stream1,guestStudentEntered);
                stream1.Close();
                MessageBox.Show("تغییرات با موفقیت انجام شد");
                tabControl1.Hide();
            }
            else
                MessageBox.Show("مقدار پرداخت شده نباید بیش از مقدار اصلی باشد");
            
        }

        private void ToolStripGozaresh110_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
            tabControl1.SelectedTab = tabPageGozaresh110;
            tabPageGozaresh110_Enter(null, null);
        }

        private void tabPageGozaresh110_Enter(object sender, EventArgs e)
        {
            var tmpList = new List<lessonInTerm>();
            //string path1 = @"E:\Golestan project\golestan\golestan\Files\LessonsInTermBinary.txt";
            string path1 = Environment.CurrentDirectory + @"LessonsInTermBinary.txt";
            using (Stream stream1 = new FileStream(path1, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter deserializer = new BinaryFormatter();

                while (stream1.Position < stream1.Length)
                {
                    lessonInTerm temp = (lessonInTerm)deserializer.Deserialize(stream1);
                    tmpList.Add(temp);
                }
            }

            dataGridGozaresh110.DataSource = tmpList.ToArray();
        }

        private void ToolStripMenuItemSabteNamMoqadamati_Click(object sender, EventArgs e)
        {
            tabControl1.Show();
            tabControl1.SelectedTab = tabPageSabteNamMoqadamati;
            tabPageSabteNamMoqadamati_Enter(null, null);
        }

        private void tabPageSabteNamMoqadamati_Enter(object sender, EventArgs e)
        {
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

            dataGridViewShowLesson.DataSource = listOfLessons.ToArray();
            listOfLessons.Clear();
        }

        private void btnAddSabteNamMoqadamati_Click(object sender, EventArgs e)
        {
            //var checkedRows = this.dataGridViewShowLesson.Rows.Cast<DataGridViewRow>() 
            //         .Where(row => (bool?)row.Cells[0].Value == true).ToArray();
            //dataGridViewSabteNamMoqadamati.AutoGenerateColumns = false;

            //dataGridViewSabteNamMoqadamati.Rows.AddRange(checkedRows);

            var checkedRows = this.dataGridViewShowLesson.Rows.Cast<DataGridViewRow>()
                     .Where(row => (bool?)row.Cells[0].Value == true).ToArray();

            int sum = 0;
            
            foreach(var row in checkedRows)
            {
                sum += Convert.ToInt32(row.Cells[2].Value);
            }

            textBoxTedadVahedElamShode.Text = sum.ToString();
            textBoxTedadVahedElamShode.Enabled = false;
        }

        private void btnTaeidNahaei_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(textBoxTedadVahedElamShode.Text)>25)
            {
                MessageBox.Show("تعداد واحد انتخاب شده از حد مجاز بیشتر است");
            }
            else
            {
                //if(studentEntered!=null)
                //{
                //    var checkedRows = this.dataGridViewShowLesson.Rows.Cast<DataGridViewRow>() //for darsa
                //          .Where(row => (bool?)row.Cells[0].Value == true)
                //          .ToArray();

                //    for (int i = 0; i < listOfLessons.Count; i++)
                //    {
                //        for (int j = 0; j < checkedRows.Length; j++)
                //        {
                //            if (i == checkedRows[j].Index)
                //            {
                //                studentEntered.Inprogresslessons.Add()
                //            }
                //        }
                //    }

                //    string path1 = @"E:\Golestan project\golestan\golestan\Files\StudentsBinary.txt";
                //    IFormatter formatter = new BinaryFormatter();
                //    Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //    formatter.Serialize(stream1,studentEntered);
                //    stream1.Close();
                //}
                //if(guestStudentEntered!=null)
                //{

                //}
            }
        }
    }
}
