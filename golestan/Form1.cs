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
using ValidationComponents;

namespace golestan
{
    
    public partial class Form1 : Form
    {

        StudentMenu s1;
        OstadMenu os1;
        KarmandMenu k1;

        public Form1()
        {
            InitializeComponent();
            loadCaptchaImage();
            persianCal();
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 800;
            timer.Start();
        }

        private int number = 0;

        private void loadCaptchaImage()
        {
            Random r1 = new Random();
            number = r1.Next(100, 1000);
            var image = new Bitmap(this.picBoxCaptcha.Width, this.picBoxCaptcha.Height);
            var font = new Font("TimesNewRoman", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(number.ToString(), font, Brushes.Green, new Point(0, 0));
            picBoxCaptcha.Image = image;
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButtonStudent.Select();
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

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components) && Convert.ToInt32(txtboxCaptcha.Text)==number)
            {

                if (radioButtonStudent.Checked)
                {
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\StudentsBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"StudentsBinary.txt";
                    Stream stream1=null;
                    try
                    {
                         stream1 = new FileStream(path1, FileMode.Open, FileAccess.Read);

                        BinaryReader br1 = new BinaryReader(stream1, Encoding.GetEncoding("iso-8859-1"));
                        IFormatter formatter = new BinaryFormatter();

                        while (stream1.Position < stream1.Length)
                        {
                            Student temp = (Student)formatter.Deserialize(stream1);

                            if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                            {
                                
                                s1 = new StudentMenu((Student)temp);
                                this.Hide();
                                s1.ShowDialog();
                                this.Close();
                            }

                        }
                    }
                    catch
                    {
                        stream1 = null;
                    }
                    finally
                    {
                        if (stream1 != null)
                            stream1.Close();
                    }



                    //-----------------------------------------
                    //string path2 = @"E:\Golestan project\golestan\golestan\Files\GuestStudentsBinary.txt";
                    string path2 = Environment.CurrentDirectory + @"GuestStudentsBinary.txt";
                    Stream stream2=null;
                    try
                    {
                        stream2 = new FileStream(path2, FileMode.Open, FileAccess.Read);

                        BinaryReader br2 = new BinaryReader(stream2, Encoding.GetEncoding("iso-8859-1"));
                        IFormatter formatter2 = new BinaryFormatter();

                        while (stream2.Position < stream2.Length)
                        {
                            GuestStudent temp = (GuestStudent)formatter2.Deserialize(stream2);

                            if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                            {
                                stream2.Close();
                                s1 = new StudentMenu((GuestStudent)temp);
                                this.Hide();
                                s1.ShowDialog();
                                this.Close();
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

                    if (stream1 == null && stream2 == null)
                        MessageBox.Show("دانشجویی موجود نمیباشد");

                }


                else if (radioButtonOstad.Checked)
                {
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\OstadHeyatElmiBinary.txt";
                    //string path2 = @"E:\Golestan project\golestan\golestan\Files\HeadOfDepartmentBinary.txt";
                    //string path3 = @"E:\Golestan project\golestan\golestan\Files\OstadMadovBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"OstadHeyatElmiBinary.txt";
                    string path2 = Environment.CurrentDirectory + @"HeadOfDepartmentBinary.txt";
                    string path3 = Environment.CurrentDirectory + @"OstadMadovBinary.txt";

                    Stream stream1 = null;
                    try
                    {
                        stream1 = new FileStream(path3, FileMode.Open, FileAccess.Read);

                        BinaryReader br1 = new BinaryReader(stream1, Encoding.GetEncoding("iso-8859-1"));
                        IFormatter formatter = new BinaryFormatter();

                        while (stream1.Position < stream1.Length) //ostad madov finder
                        {
                            OstadMadov temp = (OstadMadov)formatter.Deserialize(stream1);

                            if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                            {
                                stream1.Close();
                                os1 = new OstadMenu((OstadMadov)temp);
                                this.Hide();
                                os1.ShowDialog();
                                this.Close();
                            }

                        }
                    }
                    catch
                    {
                        stream1 = null;
                    }
                    finally
                    {
                        if(stream1!=null)
                            stream1.Dispose();
                    }

                    Stream stream2 = null;
                    try
                    {
                         stream2 = new FileStream(path1, FileMode.Open, FileAccess.Read);

                        BinaryReader br2 = new BinaryReader(stream2, Encoding.GetEncoding("iso-8859-1"));
                        IFormatter formatter2 = new BinaryFormatter();

                        while (stream2.Position < stream2.Length) //ostad heyatelmi finder
                        {
                            OstadheyatElmi temp = (OstadheyatElmi)formatter2.Deserialize(stream2);

                            if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                            {
                                stream2.Close();
                                os1 = new OstadMenu((OstadheyatElmi)temp);
                                this.Hide();
                                os1.ShowDialog();
                                this.Close();
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
                            stream2.Dispose();
                    }

                    Stream stream3 = null;
                    try
                    {
                        stream3 = new FileStream(path2, FileMode.Open, FileAccess.Read);

                        BinaryReader br3 = new BinaryReader(stream3, Encoding.GetEncoding("iso-8859-1"));
                        IFormatter formatter3 = new BinaryFormatter();

                        while (stream3.Position < stream3.Length) //head finder
                        {
                            HeadOfDepartment temp = (HeadOfDepartment)formatter3.Deserialize(stream3);

                            if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                            {
                                stream3.Close();
                                os1 = new OstadMenu((HeadOfDepartment)temp);
                                this.Hide();
                                os1.ShowDialog();
                                this.Close();
                            }

                        }
                    }
                    catch
                    {
                        stream3 = null;
                    }
                    finally
                    {
                        if (stream3 != null)
                            stream3.Dispose();
                    }


                    //string path4 = @"E:\Golestan project\golestan\golestan\Files\ModirGPBinary.txt";
                    string path4 = Environment.CurrentDirectory + @"ModirGPBinary.txt";

                    Stream stream4 = null;
                    try
                    {
                        stream4 = new FileStream(path4, FileMode.Open, FileAccess.Read);

                        BinaryReader br4 = new BinaryReader(stream4, Encoding.GetEncoding("iso-8859-1"));
                        IFormatter formatter4 = new BinaryFormatter();

                        while (stream4.Position < stream4.Length) //modirGP finder
                        {
                            ModirGP temp = (ModirGP)formatter4.Deserialize(stream4);

                            if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                            {
                                stream4.Close();
                                os1 = new OstadMenu((ModirGP)temp);
                                this.Hide();
                                os1.ShowDialog();
                                this.Close();
                            }

                        }
                    }
                    catch
                    {
                        stream4 = null;
                    }
                    finally
                    {
                        if (stream4 != null)
                            stream4.Dispose();
                    }


                    //if (stream1 == null && stream2 == null && stream3 == null && stream4 == null)
                        MessageBox.Show("استادی موجود نمیباشد");


                }
                else if (radioButtonKarmand.Checked)
                {
                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\KarmandBinary.txt";

                    //Stream stream1 = new FileStream(path1, FileMode.Open, FileAccess.Read);

                    //BinaryReader br1 = new BinaryReader(stream1, Encoding.GetEncoding("iso-8859-1"));
                    //IFormatter formatter = new BinaryFormatter();

                    //while (stream1.Position < stream1.Length)
                    //{
                    //    KarmandAmoozesh temp = (KarmandAmoozesh)formatter.Deserialize(stream1);
                    //    KarmandAmoozeshDaneshkade temp2=null;
                    //    KarmandAmoozeshKol temp3=null;

                    //    if (formatter.Deserialize(stream1) is KarmandAmoozeshDaneshkade)
                    //    {
                    //        temp2 = (KarmandAmoozeshDaneshkade)formatter.Deserialize(stream1);
                    //    }
                    //    if (formatter.Deserialize(stream1) is KarmandAmoozeshKol)
                    //    {
                    //        temp3 = (KarmandAmoozeshKol)formatter.Deserialize(stream1);
                    //    }



                    //    if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                    //    {
                    //        stream1.Close();
                    //        k1 = new KarmandMenu((KarmandAmoozesh)temp);
                    //        this.Hide();
                    //        k1.ShowDialog();
                    //        this.Close();
                    //    }
                    //    else if (temp2.Id == Convert.ToInt32(txtboxUsername.Text) && temp2.Password == txtboxPassword.Text)
                    //    {
                    //        stream1.Close();
                    //        k1 = new KarmandMenu((KarmandAmoozeshDaneshkade)temp2);
                    //        this.Hide();
                    //        k1.ShowDialog();
                    //        this.Close();
                    //    }
                    //    else if (temp3.Id == Convert.ToInt32(txtboxUsername.Text) && temp3.Password == txtboxPassword.Text)
                    //    {
                    //        stream1.Close();
                    //        k1 = new KarmandMenu((KarmandAmoozeshKol)temp3);
                    //        this.Hide();
                    //        k1.ShowDialog();
                    //        this.Close();
                    //    }

                    //}

                    //while (stream1.Position < stream1.Length)
                    //{
                    //    KarmandAmoozesh temp = (KarmandAmoozesh)formatter.Deserialize(stream1);

                    //    if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                    //    {
                    //        stream1.Close();
                    //        k1 = new KarmandMenu((KarmandAmoozesh)temp);
                    //        this.Hide();
                    //        k1.ShowDialog();
                    //        this.Close();
                    //    }

                    //}

                    //stream1.Position = 0;

                    //while (stream1.Position < stream1.Length)
                    //{
                    //    KarmandAmoozeshDaneshkade temp;

                    //if (!(formatter.Deserialize(stream1) is KarmandAmoozeshKol))
                    //    {
                    //        temp = (KarmandAmoozeshDaneshkade)formatter.Deserialize(stream1);


                    //        if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                    //        {
                    //            stream1.Close();
                    //            k1 = new KarmandMenu((KarmandAmoozeshDaneshkade)temp);
                    //            this.Hide();
                    //            k1.ShowDialog();
                    //            this.Close();
                    //        }
                    //    }

                    //}

                    //stream1.Position = 0;

                    //while (stream1.Position < stream1.Length)
                    //{
                    //    KarmandAmoozeshKol temp = (KarmandAmoozeshKol)formatter.Deserialize(stream1);

                    //    if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                    //    {
                    //        stream1.Close();
                    //        k1 = new KarmandMenu((KarmandAmoozeshKol)temp);
                    //        this.Hide();
                    //        k1.ShowDialog();
                    //        this.Close();
                    //    }

                    //}

                    //string path1 = @"E:\Golestan project\golestan\golestan\Files\KarmandAmoozeshBinary.txt";
                    //string path2 = @"E:\Golestan project\golestan\golestan\Files\KarmandAmoozeshKolBinary.txt";
                    //string path3 = @"E:\Golestan project\golestan\golestan\Files\KarmandAmoozeshDaneshkadeBinary.txt";
                    string path1 = Environment.CurrentDirectory + @"KarmandAmoozeshBinary.txt";
                    string path2 = Environment.CurrentDirectory + @"KarmandAmoozeshKolBinary.txt";
                    string path3 = Environment.CurrentDirectory + @"KarmandAmoozeshDaneshkadeBinary.txt";

                    Stream stream1=null;
                    try
                    {
                        stream1 = new FileStream(path1, FileMode.Open, FileAccess.Read);
                        BinaryReader br1 = new BinaryReader(stream1, Encoding.GetEncoding("iso-8859-1"));
                        IFormatter formatter = new BinaryFormatter();

                        while (stream1.Position < stream1.Length) //addi finder
                        {
                            KarmandAmoozesh temp = (KarmandAmoozesh)formatter.Deserialize(stream1);

                            if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                            {
                                stream1.Close();
                                k1 = new KarmandMenu((KarmandAmoozesh)temp);
                                this.Hide();
                                k1.ShowDialog();
                                this.Close();
                            }

                        }
                    }
                    catch
                    {
                        stream1 = null;
                    }
                    finally
                    {
                        if (stream1 != null)
                            stream1.Dispose();
                    }
                    
                    Stream stream2=null;
                    try
                    {
                        stream2 = new FileStream(path3, FileMode.Open, FileAccess.Read);
                        BinaryReader br2 = new BinaryReader(stream2, Encoding.GetEncoding("iso-8859-1"));
                        IFormatter formatter2 = new BinaryFormatter();

                        while (stream2.Position < stream2.Length) //karmanddaneshkade finder
                        {
                            KarmandAmoozeshDaneshkade temp = (KarmandAmoozeshDaneshkade)formatter2.Deserialize(stream2);

                            if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                            {
                                stream2.Close();
                                k1 = new KarmandMenu((KarmandAmoozeshDaneshkade)temp);
                                this.Hide();
                                k1.ShowDialog();
                                this.Close();
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
                            stream2.Dispose();
                    }
                    

                    Stream stream3=null;
                    try
                    {
                         stream3 = new FileStream(path2, FileMode.Open, FileAccess.Read);

                        BinaryReader br3 = new BinaryReader(stream3, Encoding.GetEncoding("iso-8859-1"));
                        IFormatter formatter3 = new BinaryFormatter();

                        while (stream3.Position < stream3.Length) //head finder
                        {
                            KarmandAmoozeshKol temp = (KarmandAmoozeshKol)formatter3.Deserialize(stream3);

                            if (temp.Id == Convert.ToInt32(txtboxUsername.Text) && temp.Password == txtboxPassword.Text)
                            {
                                stream3.Close();
                                k1 = new KarmandMenu((KarmandAmoozeshKol)temp);
                                this.Hide();
                                k1.ShowDialog();
                                this.Close();
                            }

                        }
                    }
                    catch
                    {
                        stream3 = null;
                    }
                    finally
                    {
                        if (stream3 != null)
                            stream3.Dispose();
                    }




                    MessageBox.Show("لطفا دوباره امتحان کنید");

                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("میخواهید خارج شوید", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "دانشجو")
            {
                SingUpStudentForm student1 = new SingUpStudentForm();
                this.Hide();
                student1.ShowDialog();
                this.Close();

            }
            else if (comboBox1.Text == "استاد")
            {
                SingUpOStadForm ostad1 = new SingUpOStadForm();
                this.Hide();
                ostad1.ShowDialog();
                this.Close();
            }
            else if (comboBox1.Text == "کارمند آموزش")
            {
                SIngUpKarmandzForm karmand1 = new SIngUpKarmandzForm();
                this.Hide();
                karmand1.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("لطفا انتخاب کنید");

        }

        private void label5_Click(object sender, EventArgs e)
        {
            loadCaptchaImage();
        }
    }
}
