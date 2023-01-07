using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsREST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private static List<Student> _studenci = new List<Student>();




        [HttpGet]
        public IActionResult GetStudents()
        {

            return Ok(_studenci);

        }

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent(Student student)
        {

            _studenci.Add(student);
            return Ok(student);

        }


        [HttpPost("{IdStudent}/DeleteStudent")]
        public IActionResult DeleteStudent(String IdStudent)
        {
            Student foundSt = null;

            foreach (Student st in _studenci){
                if (st.IdStudent == IdStudent) {
                    
                    foundSt = st;
                    _studenci.Remove(st);
                    break;
                }
            
            }

            if (foundSt == null)
            {
                return NotFound("Student with " + IdStudent + " not found.");
            }
            else
            {
                return Ok(IdStudent);
            }

        }

        [HttpGet("{IdStudent}")]
        public IActionResult GetStudent(String IdStudent)
        {
            Student foundSt = null;

            foreach (Student st in _studenci)
            {
                if (st.IdStudent == IdStudent)
                {
                    foundSt = st;
                }

            }

            if (foundSt == null)
            {
                return NotFound("Student with " + IdStudent  + " not found.");
            }
            else {
                return Ok(foundSt);
            }
        }


        [HttpPost("{IdStudent}/UpdateStudent")]
        public IActionResult UpdateStudent(String IdStudent, Student student)
        {

            Student foundSt = null;

            foreach (Student st in _studenci)
             {
                if (st.IdStudent == IdStudent)
                {

                    foundSt = st;
                    st.Imie = student.Imie;
                    st.Nazwisko = student.Nazwisko;
                    st.Email = student.Email;
                    st.Adres = student.Adres;
                    break;
                }

            }

            if (foundSt == null)
            {
                return NotFound("Student with " + IdStudent + " not found.");
            }
            else
            {
                return Ok(foundSt);
            }

        }

    }
}
