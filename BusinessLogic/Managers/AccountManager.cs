using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Interfaces;
using DataAccess;
using Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Managers
{
    public class AccountManager : IAccountManager
    {
        private readonly IMapper _mapper;
        public AccountManager()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDto>();
                cfg.CreateMap<StudentDto, Student>();
                cfg.CreateMap<Course, CourseDto>();
                cfg.CreateMap<CourseDto, Course>();
            });

            _mapper = config.CreateMapper();

            //using (var db = new PocContext())
            //{
            //    db.Courses.Add(new Course
            //    {
            //        Name = "Test1",
            //        Students = new List<Student>
            //        {
            //            new Student
            //            {
            //                StudentName = "Hans"
            //            },
            //            new Student
            //            {
            //                StudentName = "John"
            //            }
            //        }
            //    });
        }

        public void Stuff()
        {
            using (var db = new PocContext())
            {
                var firstStudent = db.Students.First();
                var mappedStudent = _mapper.Map<StudentDto>(firstStudent);

                var mappedBackStudent = _mapper.Map<Student>(mappedStudent);

                db.Courses.Add(new Course
                {
                    Name = "NewCourse",
                    Students = new List<Student>()
                    {
                        mappedBackStudent
                    }
                });
                db.SaveChanges();
            }
        }
    }
}
