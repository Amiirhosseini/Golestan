using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace golestan
{
    [Serializable]
    class lesson
    {
        public string Name { get; set; }
        public int Vahed { get; set; }
        public TypeOflesson Type { set; get; }

        public List<lesson> Pishniaz = new List<lesson>();
        public List<lesson> Hamniaz = new List<lesson>();

        public lesson(string name,int vahed,TypeOflesson type)
        {
            Name = name;
            Vahed = vahed;
            Type = type;
        }

        public lesson(string name)
        {
            Name = name;
        }

    }

    enum TypeOflesson{پایه,اصلی,تخصصی,عمومی};

    [Serializable]
    class lessonInTerm : lesson
    {
        public string LocationOfClass { get; set; }
        public string TimeOfWeek { get; set; }
        public string TimeOfExam { get; set; }
        public int Zarfiat { get; set; }
        public string TeachingOstad { get; set; }


        public lessonInTerm(string name, int vahed, TypeOflesson type, string locationofclass, string timeofWeek, string timeofExam, int zarfiat, string teachingOstad) : base(name, vahed, type)
        {
            Name = name;
            Vahed = vahed;
            Type = type;
            LocationOfClass = locationofclass;
            TimeOfExam = timeofExam;
            TimeOfWeek = timeofWeek;
            Zarfiat = zarfiat;
            TeachingOstad = teachingOstad;
        }

    }

}
