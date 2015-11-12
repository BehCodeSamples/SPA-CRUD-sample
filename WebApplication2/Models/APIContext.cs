using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class APIContext
    {
        private List<Teacher> _teachers = new List<Teacher>()
        {
            new Teacher() {
                 Id = 1,
                 Name = "Пупкин Василий"
            },
            new Teacher ()
            {
                Id = 2,
                Name = "Пупкина Василиса"
            },
            new Teacher()
            {
                Id = 3,
                Name = "Сидор Сидоров"
            }
        };


        private List<Group> _groups = new List<Group>()
        {
            new Group() {
                Id = 1,
                Name = "Маляры",
                TeacherId = 2
            },
            new Group() {
                Id = 2,
                Name = "Сварщики",
                TeacherId = 3
            },
            new Group() {
                Id = 3,
                Name = "Автослесари",
                TeacherId = 1
            },
        };

        private List<Student> _students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "Фекла Толстая",
                GroupId = 1
            },
             new Student()
            {
                Id = 2,
                Name = "Ираклий Пирцхалава",
                GroupId = 3
            },
              new Student()
            {
                Id = 3,
                Name = "Иван Иванов",
                GroupId = 3
            },
               new Student()
            {
                Id = 4,
                Name = "Саша Грей",
                GroupId = 1
            },
                new Student()
            {
                Id = 5,
                Name = "Глеб Глебов",
                GroupId = 2
            },
                 new Student()
            {
                Id = 6,
                Name = "Петр Петров",
                GroupId = 2
            },

        };

        private static APIContext _apiContext = new APIContext();
        public static APIContext Instance
        {
            get
            {
                return _apiContext;
            }
        }

        public List<Group> Groups
        {
            get
            {
                return _groups;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return _teachers;
            }
        }

        public List<Student> Students
        {
            get
            {
                return _students;
            }
        }
    }
}