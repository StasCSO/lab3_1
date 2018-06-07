using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDB
{
    class DataBase
    {
        List<Student> db;

        public DataBase()
        {
            db = new List<Student>();
        }

        internal List<Student> Db { get { return db; } }

        public bool AddStudent(Student student)
        {
            bool result = false;
            try
            {
                Db.Add(student);
                result = true;
            }
            catch (Exception exc)
            {
                
            }

            return result;
        }

        public string toString()
        {
            string result = "";
            
            foreach (Student item in Db)
            {
                result += item.toString() + '\n';
            }

            return result;
        }
    }
}
