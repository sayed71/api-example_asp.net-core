using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Model;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        List<Student> _oStudents = new List<Student>()
        {
            new Student(){Id=1,Name="Sayed",Roll=1001},
            new Student(){Id=2,Name="Sakib",Roll=1002},
            new Student(){Id=3,Name="Reaz",Roll=1003},
            new Student(){Id=4,Name="Elias",Roll=1004},
            new Student(){Id=5,Name="Maruf",Roll=1005},
        };

        //Show all Data (Get Request)
        [HttpGet]
        public IActionResult Gets()
        {
            if(_oStudents.Count == 0)
            {
                return NotFound("No list found.");
            }

            return Ok(_oStudents);
        }

        //Show Specific Data (Post Request)
        [HttpPost("GetStudent")]
        public IActionResult Get(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if(oStudent == null)
            {
                return NotFound("No student found.");
            }

            return Ok(oStudent);
        }

        //Save Operation
        [HttpPost]
        public IActionResult Save(Student oStudent)
        {
            _oStudents.Add(oStudent);

            if (oStudent == null)
            {
                return NotFound("No student found.");
            }

            return Ok(_oStudents);
        }

        //Delete Operation
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var oStudent = _oStudents.SingleOrDefault(x => x.Id == id);
            if (oStudent == null)
            {
                return NotFound("No student found.");
            }

            _oStudents.Remove(oStudent);

            if (_oStudents.Count == 0)
            {
                return NotFound("No list found.");
            }

            return Ok(_oStudents);
        }
    }
}
