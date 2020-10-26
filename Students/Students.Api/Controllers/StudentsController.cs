using Microsoft.AspNetCore.Mvc;
using Students.Data;
using Students.Models;

namespace Students.Api.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // nu e recomandat
        //[HttpGet("")]
        //public string TestGet()
        //{
        //    return "primul string";
        //}

        // e recomandat (nu trebuie sa intoarcem obiect care nu e de tipul HttpResult)
        //[HttpGet("")]
        //public IActionResult TestGetV2()
        //{
        //     return this.Ok("primul string");
        //}

            // intoarce toata lista 
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var manager = new StudentManager();

            var students = manager.GetAll();

            return this.Ok(students);
        }

            // intoarce element din list dupa id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var manager = new StudentManager();

            var student = manager.GetById(id);

            if (student == null)
            {
                return this.NotFound();
            }

            return this.Ok(student);
        }

            // creeaza un nou element in lista
        [HttpPost("")]
        public IActionResult CreateStudent(Student student)
        {
            var manager = new StudentManager();

            manager.Add(student);

            return this.Created($"api/students/{student.Id.ToString()}", student);
        }

            // delete element dupa id
        [HttpDelete("{id}")]
        public IActionResult CreateStudent(int id)
        {
            var manager = new StudentManager();

            manager.Delete(id);

            return this.Ok();
        }

            // face update la element dupa id cu noul model
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student model)
        {
            var manager = new StudentManager();

            manager.Update(id, model);

            return this.Ok();
        }
    }
}