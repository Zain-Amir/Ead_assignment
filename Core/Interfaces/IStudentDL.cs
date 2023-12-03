using Core.Models.RequestModels;
using Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStudentDL
    {
        public StudentResponseDto SaveStudent(StudentRequestDto studentRequestDto);
        public StudentDetailSubjectResponseDto GetStudent(int id);    
        public IEnumerable<StudentResponseDto> GetStudentsAsync();
    }
}
