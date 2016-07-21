using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        
        public string StudentName { get; set; }

        //public ICollection<CourseDto> Courses { get; set; }
    }
}
