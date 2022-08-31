using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace golestan
{
    [Serializable]
    abstract class Ostad
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public string TeachingLesson { get; set; }
        private string password;
        private DateTime dateOfBirth;

        Dictionary<Student, double> Students = new Dictionary<Student, double>();// <student-grade>

        public Ostad(string firstName, string lastName, int id, string teachingLesson,string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            TeachingLesson = teachingLesson;
            Password = password;
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

        public void SabteNomre()
        {

        }


    }

    [Serializable]
    class OstadMadov : Ostad
    {
        public Dictionary<Student, double> ListOfStudents = new Dictionary<Student, double>();

        public OstadMadov(string firstName, string lastName, int id, string teachingLesson,string password) : base(firstName, lastName, id, teachingLesson,password)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            TeachingLesson = teachingLesson;
            Password = password;
        }

        //public void LessonInProgressShow()
        //{

        //}

    }

    enum TypeOfOstad { استادیار, دانشیار, استاد};

    [Serializable]
    class OstadheyatElmi : Ostad
    {
        public TypeOfOstad Type { get; set; }
        public bool IsRahnama { get; set; }

        public OstadheyatElmi(string firstName, string lastName, int id, string teachingLesson,string password) : base(firstName, lastName, id, teachingLesson,password)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            TeachingLesson = teachingLesson;
            //Type = type;
            Password = password;
            //IsRahnama = israhnama;
        }

    }

    [Serializable]
    class ModirGP : OstadheyatElmi
    {
        public ModirGP(string firstName, string lastName, int id, string teachingLesson,string password) : base(firstName, lastName, id, teachingLesson,password)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            TeachingLesson = teachingLesson;
            //Type = type;
            //IsRahnama = israhnama;
            Password = password;
        }

    }

    [Serializable]
    class HeadOfDepartment : OstadheyatElmi
    {
        public string DepartmentName { get; set; }

        public HeadOfDepartment(string firstName, string lastName, int id, string teachingLesson,string password) : base(firstName, lastName, id, teachingLesson,password)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            TeachingLesson = teachingLesson;
            Password = password;
            //Type = type;
            //IsRahnama = israhnama;
        }

        //public OstadMadov AddingOstadMadov(string firstName, string lastName, int id, string teachingLesson)
        //{
        //    return new OstadMadov(firstName, lastName, id, teachingLesson);
        //}

        //public OstadheyatElmi PromotingOstadMadov(OstadMadov ostad,TypeOfOstad typeToBePromote,bool israhnama1)
        //{
        //    return new OstadheyatElmi(ostad.FirstName, ostad.LastName, ostad.Id, ostad.TeachingLesson, typeToBePromote, israhnama1);
        //}
    }


}
