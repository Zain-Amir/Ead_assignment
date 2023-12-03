using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.ResponseModels
{
    public class SubjectResponseDto : ISubject
    {
        public int Id { get; set; }
        public string Name { get ; set ; }
    }
}
