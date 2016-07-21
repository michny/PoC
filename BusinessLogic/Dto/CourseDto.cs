using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        
        public string Name { get; set; }

        //public virtual ICollection<StudentDto> Students { get; set; }
    }
}
