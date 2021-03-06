﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private const string ConString = "Data Source=db-mssql;Initial Catalog=s18915;Integrated Security=True";

        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = new List<Student>();

            using (var con = new SqlConnection(ConString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = 
                    "select IndexNumber, FirstName, LastName, BirthDate, Name, Semester from student " +
                    "inner join Enrollment on Enrollment.IdEnrollment = Student.IdEnrollment " +
                    "inner join Studies on Studies.IdStudy = Enrollment.IdStudy;";

                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                   list.Add(new Student
                    {
                        IndexNumber = dr["IndexNumber"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        BirthDate = Convert.ToDateTime(dr["BirthDate"]),
                        StudiesName = dr["Name"].ToString(),
                        Semester = Convert.ToInt32(dr["Semester"])
                    });
                }
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(string id)
        {
            using (var con = new SqlConnection(ConString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = 
                    "select IndexNumber, FirstName, LastName, BirthDate, Semester, Name from enrollment " +
                    "join Studies on Studies.IdStudy = Enrollment.IdEnrollment " +
                    "join Student on Student.IdEnrollment = Enrollment.IdEnrollment " +
                    "where IndexNumber = @index";

                com.Parameters.AddWithValue("index", id);

                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student
                    {
                        IndexNumber = dr["IndexNumber"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        BirthDate = Convert.ToDateTime(dr["BirthDate"]),
                        Semester = Convert.ToInt32(dr["Semester"]),
                        StudiesName = dr["Name"].ToString()
                    };
                    return Ok(st);
                }
            }
            return NotFound("Nie znaleziono studenta");
        }
    }
}