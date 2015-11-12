using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TeacherController : ApiController
    {
        APIContext _context = APIContext.Instance;

        // GET: api/Teachers
        public IQueryable<Teacher> GetTeachers()
        {
            return _context.Teachers.AsQueryable();
        }

        // GET: api/Teachers/5
        [ResponseType(typeof(Teacher))]
        public async Task<IHttpActionResult> GetTeacher(int id)
        {
            var Teacher = _context.Teachers.FirstOrDefault(item => item.Id == id);

            if (Teacher == null)
                return NotFound();

            return Ok(Teacher);
        }

        // POST: api/Teacher
        [ResponseType(typeof(Teacher))]
        public async Task<IHttpActionResult> PostTeacher(Teacher Teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Teachers.Add(Teacher);

            return CreatedAtRoute("DefaultApi", new { id = Teacher.Id }, Teacher);
        }

        // PUT: api/Teachers/5
        public async Task<IHttpActionResult> PutTeacher(int id, Teacher Teacher)
        {
            var TeacherFromPersist = _context.Teachers.FirstOrDefault(item => item.Id == id);

            if (TeacherFromPersist == null)
                return NotFound();

            TeacherFromPersist.Name = Teacher.Name;

            return Ok();
        }

        // DELETE: api/Teacher/5
        public async Task<IHttpActionResult> DeleteTeacher(int id)
        {
            var TeacherFromPersist = _context.Teachers.FirstOrDefault(item => item.Id == id);

            if (TeacherFromPersist == null)
                return NotFound();

            _context.Teachers.Remove(TeacherFromPersist);

            return Ok();
        }
    }
}

