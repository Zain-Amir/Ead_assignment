using DL.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiStudentGPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectAssignmentController : ControllerBase
    {
        private readonly StudentDbContext _dbContext;

        public StudentSubjectAssignmentController(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AssignSubjectToStudent([FromBody] Student_Subject_DbDto assignmentDto)
        {
            if (assignmentDto == null)
            {
                return BadRequest("Invalid assignment data");
            }
            var student = _dbContext.studentDbDto.Find(assignmentDto.SID);
            var subject = _dbContext.subjectDbDto.Find(assignmentDto.SubjectId);

            if (student == null || subject == null)
            {
                return NotFound("Student or subject not found");
            }
            var assignment = new Student_Subject_DbDto
            {
                studentDbDto = student,
                SubjectDbDto = subject,
                SID = assignmentDto.SID,
                SubjectId = assignmentDto.SubjectId
            };

            _dbContext.studentSubjectDbDto.Add(assignment);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Assignment Created Successfully" });
        }

        [HttpPut("{assignmentId}")]
        public IActionResult UpdateAssignment(int assignmentId, [FromBody] Student_Subject_DbDto assignmentDto)
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

            assignment.SID = assignmentDto.SID;
            assignment.SubjectId = assignmentDto.SubjectId;

            _dbContext.studentSubjectDbDto.Update(assignment);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Assignment Updated Successfully" });
        }

        [HttpDelete("{assignmentId}")]
        public IActionResult DeleteAssignment(int assignmentId)
        {
            var assignment = _dbContext.studentSubjectDbDto.Find(assignmentId);
            if (assignment == null)
            {
                return NotFound("Assignment not found");
            }

            _dbContext.studentSubjectDbDto.Remove(assignment);
            _dbContext.SaveChanges();

            return Ok(new { Message = "Assignment Deleted Successfully" });
        }


    }
}
