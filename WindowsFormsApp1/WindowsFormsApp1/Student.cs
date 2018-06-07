using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDB
{
    
    class Student
    {
        String name, secondName, surName;
        DateTime birthday;
        short gender = 1;
        short course = 1;
        String department = "CSI";

        public string Name { get { return name; } set { name = value; } }
        public string SecondName { get { return secondName; } set { secondName = value; } }
        public string SurName { get { return surName; } set { surName = value; } }
        public DateTime Birthday { get { return birthday; } set { birthday = value; } }
        public short Gender { get { return gender; } set { gender = value; } }
        public short Course { get { return course; } set { course = value; } }
        public string Department { get { return department; } set { department = value; } }

        public Student()
        {

        }

        public Student(string name, string secondName, string surName, DateTime birthday, short gender, short course, string department)
        {
            this.name = name;
            this.secondName = secondName;
            this.surName = surName;
            this.birthday = birthday;
            this.gender = gender;
            this.course = course;
            this.department = department;
        }

        public string toString()
        {
            return this.name + " " + this.secondName + " " + this.surName + " " + this.birthday.ToString();
        }
    }
}
