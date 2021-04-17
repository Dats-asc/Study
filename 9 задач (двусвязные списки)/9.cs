using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Двусвязный_список_9_задач
{
    class Student
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public string Birthday { get; set; }
        public int Course { get; set; }
        public int GroupNumber { get; set; }
        public int Subject1 { get; set; }
        public int Subject2 { get; set; }
        public int Subject3 { get; set; }
        public int Subject4 { get; set; }
        public int Subject5 { get; set; }
    }

    class Students
    {
        public LinkedList<Student> students;

        public Students(LinkedList<Student> students)
        {
            this.students = students;
        }

        public void CourseSort()
        {
            LinkedList<Student> newList = new LinkedList<Student>();
            for (int i = 1; i <= 4; i++)
            {
                foreach(Student student in students)
                {
                    if (student.Course == i)
                    {
                        newList.AddLast(student);
                    }
                }
            }

            students = newList;
            newList = new LinkedList<Student>();

            for (int i = 1; i <= 4; i++)
            {
                for 
            }


        }


    }
}
