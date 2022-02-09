using System;
using System.Linq;
using System.Collections.Generic;


namespace LINQ
{
    
    public class StudentInfo
    {
        public int StudentID {get; set;}

        public string? Name {get; set;}

        public string? CityName {get; set;}
            
    }

    public class SportList
    {
        public int StudentID {get ; set;}

        public string? sportName {get; set;}
    }

    public class Department 
    {
        public int StudentID {get ; set ;}

        public string? DepartmentName {get ; set;}

    }

    public class Lists
    {
        IList<StudentInfo> studentList = new List<StudentInfo>() { 
            new StudentInfo() { StudentID = 1, Name = "John", CityName ="Pune" },
            new StudentInfo() { StudentID = 2, Name = "Moin", CityName = "Mumbai"},
            new StudentInfo() { StudentID = 3, Name = "Bill", CityName = "Jaipur" },
            new StudentInfo() { StudentID = 4, Name = "Ram" , CityName = "Kashmir" },
            new StudentInfo() { StudentID = 5, Name = "Ron" , CityName = "Aurangabad"} 
        };

        IList<SportList> sportList = new List<SportList>() { 
            new SportList() { StudentID = 1, sportName = "Cricket" },
            new SportList() { StudentID = 2, sportName = "Football"},
            new SportList() { StudentID = 3, sportName = "Badminton" },
            new SportList() { StudentID = 6, sportName = "kabaddi"  },
            new SportList() { StudentID = 7, sportName = "Cricket" } 
            //Shubham jangid
        };

        IList<Department> departmentList = new List<Department>() { 
            new Department() { StudentID = 10, DepartmentName = "Computer" },
            new Department() { StudentID = 2, DepartmentName = "Mechanical"},
            new Department() { StudentID = 3, DepartmentName = "Computer" },
            new Department() { StudentID = 40, DepartmentName = "IT"  },
            new Department() { StudentID = 50, DepartmentName = "Computer" } 
        };

       


        public void go()
        {


            var innerJoin = from s in studentList
                            join st in sportList
                            on s.StudentID equals st.StudentID
                            select new 
                            {
                                Name = s.Name,
                                sportName = st.sportName
                            };
            

            var outerjoin = studentList.Join(
                            departmentList,
                            std => std.StudentID,
                            Dep => Dep.StudentID,
                            (std , Dep) => new
                            {
                                StudentName = std.Name,
                                Depar = Dep.DepartmentName
                            }
            );

            var average = studentList.Average(x => x.StudentID);
            var sum = studentList.Sum(x => x.StudentID);
            foreach(var pep in innerJoin)
            {
                Console.WriteLine($"{pep.Name} - {pep.sportName}");
            }

            foreach(var rep in outerjoin)
            {
                Console.WriteLine($"{rep.StudentName} - {rep.Depar}");
            }
            Console.WriteLine($"The average of Id in Student List is - {average}");
            Console.WriteLine($"The sum of Id in StudentList id - {sum}");


            IList<int> strList = new List<int>() {1,2,3,4,5,6};

            var commaSeperatedString = strList.Aggregate((s1, s2) => s1 + s2);

            Console.WriteLine(commaSeperatedString);
        }
    }

   
   
       
   
    
}

 