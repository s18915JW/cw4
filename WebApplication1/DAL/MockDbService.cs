using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> students;

        static MockDbService()
        {
            students = new List<Student>
            {
                new Student{IdStudent = 1, FirstName = "Jan", LastName = "Jaknowski"},
                new Student{IdStudent = 2, FirstName = "Maciej", LastName = "Maciejewski"},
                new Student{IdStudent = 3, FirstName = "Andrzej", LastName = "Andzrzejewski"},
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return students;
        }
    }
}