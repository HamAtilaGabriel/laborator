using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Repositories;

namespace L02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return StudentsRepo.Students;
        }
        [HttpGet("{id}")]
        public Student GetStudent(int id)
        {
            return StudentsRepo.Students.FirstOrDefault(s => s.Id == id);
        }
        
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            StudentsRepo.Students.Add(student);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student student)
        {
            var stud = StudentsRepo.Students.FirstOrDefault(s => s.Id == id);
            if (stud != null)
            {
            stud.Id = student.Id;
            stud.Name = student.Name;
            stud.Faculty = student.Faculty;
            stud.Year = student.Year;
            }

           //
           bool check = false;
           foreach(Student st in StudentsRepo.Students)
           {
               if (st == (StudentsRepo.Students.FirstOrDefault(s => s.Id == id)))
               {
                   st.Id = stud.Id;
                   st.Name = stud.Name;
                   st.Faculty = stud.Faculty;
                   st.Year = stud.Year;
                   check = true;
               }
               if (check)
               break;
           }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            bool check = false;
            int nr = 0;
            foreach(Student st in StudentsRepo.Students)
           {
               if (st == (StudentsRepo.Students.FirstOrDefault(s => s.Id == id)))
               {
                   check = true;
               }
               if (check)
               break;
               nr++;
           }
           StudentsRepo.Students.RemoveAt(nr);
        }
    }
}
