using DL.DbModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly StudentDbContext _dbContext;

        public MarksController(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult RecordMarks([FromBody] Student_Subject_DbDto assignmentDto)
        {
            if (assignmentDto == null)
            {
                return BadRequest("Invalid assignment data");
            }

            var assignment = _dbContext.studentSubjectDbDto
                .FirstOrDefault(a => a.SID == assignmentDto.SID && a.SubjectId == assignmentDto.SubjectId);

            if (assignment == null)
            {
                return NotFound("Assignment not found");
            }

          
            assignment.Marks = assignmentDto.Marks;

            _dbContext.studentSubjectDbDto.Update(assignment);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Marks Recorded Successfully" });
        }

        [HttpPut("{assignmentId}")]
        public IActionResult UpdateMarks(int assignmentId, [FromBody] Student_Subject_DbDto assignmentDto)
        {
            if (assignmentDto == null || assignmentId != assignmentDto.Id)
            {
                return BadRequest("Invalid assignment data");
            }

            var assignment = _dbContext.studentSubjectDbDto.Find(assignmentId);
            if (assignment == null)
            {
                return NotFound("Assignment not found");
            }
            assignment.Marks = assignmentDto.Marks;

            _dbContext.studentSubjectDbDto.Update(assignment);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Marks Updated Successfully" });
        }

        [HttpDelete("{assignmentId}")]
        public IActionResult DeleteMarks(int assignmentId)
        {
            var assignment = _dbContext.studentSubjectDbDto.Find(assignmentId);
            if (assignment == null)
            {
                return NotFound("Assignment not found");
            }

            assignment.Marks = 0;

            _dbContext.studentSubjectDbDto.Update(assignment);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Marks Deleted Successfully" });
        }

        [HttpGet("{studentId}/subjects/{subjectId}/marks")]
        public IActionResult GetMarksForSubject(int studentId, int subjectId)
        {
            var assignment = _dbContext.studentSubjectDbDto
                .FirstOrDefault(a => a.SID == studentId && a.SubjectId == subjectId);

            if (assignment == null)
            {
                return NotFound("Marks not found for the specified student and subject");
            }

            return Ok(new { Marks = assignment.Marks });
        }

        [HttpGet("students/{studentId}/marks")]
        public IActionResult GetAllMarksForStudent(int studentId)
        {
            var marks = _dbContext.studentSubjectDbDto
                .Where(a => a.SID == studentId)
                .Select(a => new
                {
                    SubjectName = a.SubjectDbDto.Name,
                    Marks = a.Marks
                })
                .ToList();

            if (!marks.Any())
            {
                return NotFound("No marks found for the specified student");
            }

            return Ok(marks);
        }

        [HttpGet("students/{studentId}/gpa")]
        public IActionResult GetGpaForStudent(int studentId)
        {
            var assignments = _dbContext.studentSubjectDbDto
                .Where(a => a.SID == studentId)
                .ToList();

            if (!assignments.Any())
            {
                return NotFound("No assignments found for the specified student");
            }

            
            Dictionary<int, double> gpaScale = new Dictionary<int, double>
            {
                { 90, 4.0 },
                { 80, 3.5 },
                { 70, 3.0 },
                { 60, 2.5 },
                { 50, 2.0 },
                { 0, 0.0 } 
            };

            double totalGpa = 0.0;
            int totalSubjects = 0;

            foreach (var assignment in assignments)
            {
             
                double subjectGpa = gpaScale
                    .Where(entry => assignment.Marks >= entry.Key)
                    .OrderByDescending(entry => entry.Key)
                    .Select(entry => entry.Value)
                    .FirstOrDefault();

                totalGpa += subjectGpa;
                totalSubjects++;
            }
            double averageGpa = totalSubjects > 0 ? totalGpa / totalSubjects : 0.0;

            return Ok(new { GPA = averageGpa });
        }
    }
}
