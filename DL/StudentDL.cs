using Core.Interfaces;
using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using DL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class StudentDL : IStudentDL
    {
        StudentDbContext _stContext;

        public StudentDL(StudentDbContext stContext)
        {
            _stContext = stContext;
        }

        public StudentDetailSubjectResponseDto GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public  IEnumerable<StudentDbDto> GetStudents()
        {
            return _stContext.studentDbDto.AsEnumerable();
        }

        public IEnumerable<StudentResponseDto> GetStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public StudentResponseDto SaveStudent(StudentRequestDto studentRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
