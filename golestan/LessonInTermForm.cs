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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace golestan
{
    public partial class LessonInTermForm : Form
    {
        List<lesson> listOfLessons = new List<lesson>();
        public LessonInTermForm()
        {
            InitializeComponent();
        }

        private void LessonInTerm_Load(object sender, EventArgs e)
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

            dataGridView1.DataSource = listOfLessons.ToArray();
            dataGridView2.DataSource = listOfLessons.ToArray();
        }

        private void SaveBut_Click(object sender, EventArgs e)
        {
            lessonInTerm tmp = null;

            try
            {
                if (comboBox1.Text == "پایه")
                {
                    tmp = new lessonInTerm(txtboxName.Text, Convert.ToInt32(txtboxVahed.Text), TypeOflesson.پایه, textBoxClassLocation.Text, textBoxTimeOfclass.Text, textBoxExamTime.Text, Convert.ToInt32(textBoxZarfiat.Text), textBoxOstadName.Text);
                }
                else if (comboBox1.Text == "اصلی")
                {
                    tmp = new lessonInTerm(txtboxName.Text, Convert.ToInt32(txtboxVahed.Text), TypeOflesson.اصلی, textBoxClassLocation.Text, textBoxTimeOfclass.Text, textBoxExamTime.Text, Convert.ToInt32(textBoxZarfiat.Text), textBoxOstadName.Text);
                }
                else if (comboBox1.Text == "تخصصی")
                {
                    tmp = new lessonInTerm(txtboxName.Text, Convert.ToInt32(txtboxVahed.Text), TypeOflesson.تخصصی, textBoxClassLocation.Text, textBoxTimeOfclass.Text, textBoxExamTime.Text, Convert.ToInt32(textBoxZarfiat.Text), textBoxOstadName.Text);
                }
                else if (comboBox1.Text == "عمومی")
                {
                    tmp = new lessonInTerm(txtboxName.Text, Convert.ToInt32(txtboxVahed.Text), TypeOflesson.عمومی, textBoxClassLocation.Text, textBoxTimeOfclass.Text, textBoxExamTime.Text, Convert.ToInt32(textBoxZarfiat.Text), textBoxOstadName.Text);
                }
                else
                {
                    MessageBox.Show("لطفا نوع درس را وارد کنید");
                }
            }
            catch
            {
                MessageBox.Show("لطفا همه ی مشخصات را وارد کنید");
                tmp = null;
            }
            //============================================

            if (tmp != null)
            {
                var checkedRows = this.dataGridView1.Rows.Cast<DataGridViewRow>() //for pishniaz
                      .Where(row => (bool?)row.Cells[0].Value == true)
                      .ToArray();

                for (int i = 0; i < listOfLessons.Count; i++)
                {
                    for (int j = 0; j < checkedRows.Length; j++)
                    {
                        if (i == checkedRows[j].Index)
                        {
                            tmp.Pishniaz.Add(listOfLessons[i]);
                        }
                    }
                }

                var checkedRows2 = this.dataGridView2.Rows.Cast<DataGridViewRow>() //for hamniaz
                      .Where(row => (bool?)row.Cells[0].Value == true)
                      .ToArray();

                for (int i = 0; i < listOfLessons.Count; i++)
                {
                    for (int j = 0; j < checkedRows2.Length; j++)
                    {
                        if (i == checkedRows2[j].Index)
                        {
                            tmp.Hamniaz.Add(listOfLessons[i]);
                        }
                    }
                }

                //string path1 = @"E:\Golestan project\golestan\golestan\Files\LessonsInTermBinary.txt";
                string path1 = Environment.CurrentDirectory + @"LessonsInTermBinary.txt";
                IFormatter formatter = new BinaryFormatter();
                Stream stream1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
                formatter.Serialize(stream1, tmp);
                stream1.Close();

                MessageBox.Show("درس با موفقیت اضافه شد");
                listOfLessons.Clear();
                LessonInTerm_Load(null, null);
            }
        }   }
}
