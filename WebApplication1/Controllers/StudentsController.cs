using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{  
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService dbService;

        public StudentsController(IDbService service)
        {
            dbService = service;
        }

        [HttpGet("mock")]
        public IActionResult GetStudentsMock()
        {
            return Ok(dbService.GetStudents());
        }

        [HttpGet]
        public string GetStudents()
        {
            return "Jankowski, Maciejewski, Andrzejewski";
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
                return Ok("Jankowski");
            else if (id == 2)
                return Ok("Maciejewski");
            else if (id == 3)
                return Ok("Andrzejewski");
            return NotFound("Nie znaleziono studenta");
        }

        [HttpGet("query")]
        public string GetStudents(string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski \nSortowanie={orderBy}";
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id)
        {
            return Ok("Aktualizacja dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Usuwanie ukończone");
        }

    }
}