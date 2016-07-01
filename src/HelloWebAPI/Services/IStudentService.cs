using System.Collections.Generic;
using HelloWebAPI.Model.BE;
using HelloWebAPI.Model.Table;

namespace HelloWebAPI.Services
{
    public interface IStudentService
    {
        /// <summary>
        /// Gets the students.
        /// </summary>
        /// <returns></returns>
        List<StudentEntity> GetStudents();

        /// <summary>
        /// Inserts the student.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void InsertStudent(StudentEntity entity);

        /// <summary>
        /// Edits the student.
        /// </summary>
        /// <param name="entity">The student info</param>
        void EditStudent(StudentEntity entity);

        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteStudent(string id);
    }
}