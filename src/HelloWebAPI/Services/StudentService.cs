using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWebAPI.Model.BE;
using HelloWebAPI.Model.Table;

namespace HelloWebAPI.Services
{
    /// <summary>
    /// StudentService
    /// </summary>
    /// <seealso cref="HelloWebAPI.Services.IStudentService" />
    public class StudentService : IStudentService
    {
        /// <summary>
        /// The _DB context
        /// </summary>
        private HelloWebAPIContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public StudentService(HelloWebAPIContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <returns></returns>
        public List<StudentEntity> GetStudents()
        {
            var result = this._dbContext.Student
                             .ToList()
                             .Select(p =>
                             {
                                 var studentEntity = new StudentEntity
                                 {
                                     Id = p.StudentId.ToString(),
                                     Name = p.StudentName,
                                     Gender = p.StudentGender
                                 };
                                 return studentEntity;
                             })
                             .ToList();
            return result;
        }

        /// <summary>
        /// Inserts the student.
        /// </summary>
        /// <param name="entity">The student info</param>
        public void InsertStudent(StudentEntity entity)
        {
            var student = new Student
            {
                StudentId = Guid.NewGuid(),
                StudentName = entity.Name,
                StudentGender = entity.Gender,
                StudentCreateDateTime = DateTime.Now
            };

            this._dbContext.Student.Add(student);
            this._dbContext.SaveChanges();
        }

        /// <summary>
        /// Edits the student.
        /// </summary>
        /// <param name="entity">The student info</param>
        public void EditStudent(StudentEntity entity)
        {
            var studentId = new Guid(entity.Id);
            var student = this._dbContext.Student.First(p => p.StudentId == studentId);

            student.StudentName = entity.Name;
            this._dbContext.SaveChanges();
        }

        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteStudent(string id)
        {
            var studentId = new Guid(id);
            var student = this._dbContext.Student.First(p => p.StudentId == studentId);

            this._dbContext.Student.Remove(student);
            this._dbContext.SaveChanges();
        }
    }
}
