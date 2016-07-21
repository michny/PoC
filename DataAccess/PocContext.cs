using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PocContext : DbContext
    {
        #region DBSets
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        #endregion
    }
}
