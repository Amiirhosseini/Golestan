using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace golestan
{
    [Serializable]
    class Student 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public string Branch { get; set; }
        public double AvrageMark { get; set; }
        public int VahedPassed { get; set; }
        private string password;
        private DateTime dateOfBirth;

        public Dictionary<lesson, Double> ListOfGrades = new Dictionary<lesson, Double>(); //<name-grade>
        public List<lesson> Inprogresslessons = new List<lesson>(25);

        public Student(int id,string password)
        {
            
            Id = id;
            
            Password = password;
        }

        public Student(string firstName, string lastName, int id, string branch,string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Branch = branch;
            Password = password;
        }

        public Student(string firstName, string lastName, int id, string branch, double avrageMark)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Branch = branch;
            AvrageMark = avrageMark;
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                //var input = value;
                //var hasNumber = new Regex(@"[0-9]+");
                //var hasUpperChar = new Regex(@"[A-Z]+");
                //var hasMinimum8Chars = new Regex(@".{8,}");
                //var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);

                //if (isValidated)
                //{
                    password = value;
                //}
                //else
                //    MessageBox.Show("your entered password vas not valid");
            }

        }

        //public DateTime Age
        //{
        //   // get
        //}









    }

    [Serializable]
    class GuestStudent : Student
    {
        public int ShahriePardakhtShode { get; set; }

        public GuestStudent(string firstName, string lastName, int id, string branch,string password) : base(firstName, lastName, id, branch,password)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Branch = branch;
            //AvrageMark = avrageMark;
            Password = password;
        }

        public int shahrieCalculator()
        {
            return 25000 * VahedPassed;
        }

    }












}
