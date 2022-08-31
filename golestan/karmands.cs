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
    class KarmandAmoozesh
    {
        public int Id { get; set; }
        private string password;

        public KarmandAmoozesh(int id,string password)
        {
            Id = id;
            Password=password;
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

    }

    [Serializable]
    class KarmandAmoozeshDaneshkade : KarmandAmoozesh
    {
        public KarmandAmoozeshDaneshkade(int id, string password) : base(id, password)
        {
            Id = id;
            Password = password;
        }
    }

    [Serializable]
    class KarmandAmoozeshKol : KarmandAmoozesh
    {
        public KarmandAmoozeshKol(int id, string password) : base(id, password)
        {
            Id = id;
            Password = password;
        }
    }
}
