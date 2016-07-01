using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloWebAPI.Model.BE;
using HelloWebAPI.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        public IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        /// <summary>
        /// 取得學生清單.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("List")]
        public IEnumerable<StudentEntity> GetStudents()
        {
            var result = this._studentService.GetStudents();
            return result;
        }

        /// <summary>
        /// 新增學生資料
        /// </summary>
        /// <param name="entity">學生資訊</param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateStudent")]
        public string CreateStudent([FromBody]StudentEntity entity)
        {
            this._studentService.InsertStudent(entity);
            return "Success";
        }

        /// <summary>
        /// 修改學生資料
        /// </summary>
        /// <param name="entity">學生資訊</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Edit")]
        public string EditStudent([FromBody] StudentEntity entity)
        {
            this._studentService.EditStudent(entity);

            return "Success";
        }

        /// <summary>
        /// 刪除學生資料
        /// </summary>
        /// <param name="id">學號</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete")]
        public string Delete(string id)
        {
            this._studentService.DeleteStudent(id);

            return "Success";
        }
    }
}
