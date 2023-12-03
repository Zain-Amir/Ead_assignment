using DL.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly StudentDbContext _dbContext;

        public SubjectController(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CreateSubject([FromBody] SubjectDbDto subjectDto)
        {
            if (subjectDto == null)
            {
                return BadRequest("Invalid subject data");
            }

            _dbContext.subjectDbDto.Add(subjectDto);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Subject Created Succesfully" });
        }

        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = _dbContext.subjectDbDto;
            return Ok(subjects);
        }

       
        [HttpPut]
        public IActionResult UpdateSubject(int id, [FromBody] SubjectDbDto subjectDto)
        {
            if (subjectDto == null || id != subjectDto.id)
            {
                return BadRequest();
            }

            var subject = _dbContext.subjectDbDto.Find(id);
            if (subject == null)
            {
                return NotFound();
            }

            subject.Name = subjectDto.Name;

            _dbContext.subjectDbDto.Update(subject);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Subject Updated Succesfully" });
        }

        [HttpDelete]
        public IActionResult DeleteSubject(int id)
        {
            var subject = _dbContext.subjectDbDto.Find(id);
            if (subject == null)
            {
                return NotFound();
            }

            _dbContext.subjectDbDto.Remove(subject);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Subject Deleted Succesfully" });
        }

        [HttpGet("{id}")]
        public IActionResult GetSubjectById(int id)
        {
            var subject = _dbContext.subjectDbDto.Find(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }


    }
}
