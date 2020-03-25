using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Student
    {
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        // StudiesName i Enrollment -> pkt 4.2.3 złączenie tabel
        public string StudiesName { get; set; }
        public string Enrollment { get; set; }
    }
}