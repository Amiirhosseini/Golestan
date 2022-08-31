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
    public partial class LessonForm : Form
    {
        List<lesson> listOfLessons=new List<lesson>();

        public LessonForm()
        {
            InitializeComponent();
            //var AllLessons = from row in lessons select row;
        }

        private void SaveBut_Click(object sender, EventArgs e)
        {
            lesson tmp=null;

            if (comboBox1.Text == "پایه")
            {
                tmp = new lesson(txtboxName.Text, Convert.ToInt32(txtboxVahed.Text), TypeOflesson.پایه);
            }
            else if (comboBox1.Text == "اصلی")
            {
                tmp = new lesson(txtboxName.Text, Convert.ToInt32(txtboxVahed.Text), TypeOflesson.اصلی);
            }
            else if (comboBox1.Text == "تخصصی")
            {
                tmp = new lesson(txtboxName.Text, Convert.ToInt32(txtboxVahed.Text), TypeOflesson.تخصصی);
            }
            else if (comboBox1.Text == "عمومی")
            {
                tmp = new lesson(txtboxName.Text, Convert.ToInt32(txtboxVahed.Text), TypeOflesson.عمومی);
            }
            else
            {
                MessageBox.Show("لطفا نوع درس را وارد کنید");
            }

            //============================================

            if(tmp!=null)
            {
                var checkedRows = this.dataGridView1.Rows.Cast<DataGridViewRow>() //for pishniaz
                      .Where(row => (bool?)row.Cells[0].Value == true)
                      .ToArray();

                for(int i=0;i<listOfLessons.Count;i++)
                {
                    for(int j=0;j<checkedRows.Length;j++)
                    {
                        if(i==checkedRows[j].Index)
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

                //string path1 = @"E:\Golestan project\golestan\golestan\Files\LessonsBinary.txt";
                string path1 = Environment.CurrentDirectory + @"LessonsBinary.txt";
                IFormatter formatter = new BinaryFormatter();
                Stream stream1 = new FileStream(path1, FileMode.Append, FileAccess.Write);
                formatter.Serialize(stream1, tmp);
                stream1.Close();

                MessageBox.Show("درس با موفقیت اضافه شد");
                listOfLessons.Clear();
                LessonForm_Load(null,null);
            }


        }

        private void LessonForm_Load(object sender, EventArgs e)
        {
            // string path1 = @"E:\Golestan project\golestan\golestan\Files\LessonsBinary.txt";
            string path1 = Environment.CurrentDirectory + @"LessonsBinary.txt";

            using (Stream stream1 = new FileStream(path1, FileMode.OpenOrCreate, FileAccess.Read))
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

            //DataGridViewCheckBoxColumn checkColumn1 = new DataGridViewCheckBoxColumn();
            //DataGridViewCheckBoxColumn checkColumn2 = new DataGridViewCheckBoxColumn();

            //dataGridView1.Columns.Add(checkColumn1);
            //dataGridView2.Columns.Add(checkColumn2);
            
        }
    }
}
