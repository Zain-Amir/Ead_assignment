using DL.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _dbContext;

        public StudentController(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentDbData studentData)
        {
            if (studentData == null)
            {
                return BadRequest("Invalid student data");
            }

            // You might want to add validation logic here

            _dbContext.studentDbDto.Add(studentData);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Student Created Succesfully" });
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _dbContext.studentDbDto;
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _dbContext.studentDbDto.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentDbData studentData)
        {
            if (studentData == null || id != studentData.Id)
            {
                return BadRequest();
            }

            var student = _dbContext.studentDbDto.Find(id);
            if (student == null)
            {
                return NotFound();
            }


            student.Name = studentData.Name;
            student.PhoneNumber = studentData.PhoneNumber;
            student.RollNumber = studentData.RollNumber;

            _dbContext.studentDbDto.Update(student);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Student Updated " , student });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _dbContext.studentDbDto.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            _dbContext.studentDbDto.Remove(student);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Student Deleted Succesfully" });
        }

        [HttpGet("{studentId}/subjects")]
        public IActionResult GetSubjectsByStudentId(int studentId)
        {
            var subjects = _dbContext.studentSubjectDbDto
                .Where(a => a.SID == studentId)
                .Select(a => a.SubjectDbDto)
                .ToList();

            if (!subjects.Any())
            {
                return NotFound("No subjects found for the student");
            }

            return Ok(subjects);
        }

        



    }
}
