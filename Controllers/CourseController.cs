using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ttcm_api.Models;

namespace ttcm_api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]


    // /api/courses
    
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public static List<Course> Courses = new List<Course>();

        [Authorize]// Protected, only for http requests that have JWT token in headers
        [HttpGet]
        public IActionResult GetCourses()
        {

            return Ok(Courses);
        }

        
        [HttpPost]
        public IActionResult CreateCourse([FromBody] Course c)
        {
            Courses.Add(c);
            return CreatedAtAction("CreateCourse", new { Id = c.Id} ,c);
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            var foundCourse = Courses.FirstOrDefault(c => c.Id == id);
            if(foundCourse == null)
                return NotFound("Course Not Found!");
            return Ok(foundCourse);
        }

    }
}
