using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR13.Classes
{
    public class STUDENT
    {
        //Поля
        private string fio;
        private string group;
        private int math;
        private int physics;
        private int chemistry;
        private int english;
        private int russian;

        //Свойства
        public string Fio { get { return fio; } set { fio = value; } }
        public string Group { get { return group; } set { group = value; } }
        public int Math { get { return math; } set { math = value; } }
        public int Physics { get { return physics; } set { physics = value; } }
        public int Chemistry { get { return chemistry; } set { chemistry = value; } }
        public int English { get { return english; } set { english = value; } }
        public int Russian { get { return russian; } set { russian = value; } }
        //Конструкторы
        public STUDENT()//конструктор по умолчанию
        {
            fio = "";
            group = "";
            math = 0;
            physics = 0;
            chemistry = 0;
            english = 0;
            russian = 0;           
        }
        public STUDENT(string fio, string group, int math, int physics, int chemistry, int english, int russian)//конструктор с параметром
        {
            Fio = fio;
            Group = group;
            Math = math;
            Physics = physics;
            Chemistry = chemistry;
            English = english;
            Russian = russian;
        }
    }
}
