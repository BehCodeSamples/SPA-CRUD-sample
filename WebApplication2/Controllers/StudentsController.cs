using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentsController : ApiController
    {
        APIContext _context = APIContext.Instance;

        // GET: api/Students
        public IQueryable<Student> GetStudents()
        {
            return _context.Students.AsQueryable();
        }

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> GetStudent(int id)
        {
            var Student = _context.Students.FirstOrDefault(item => item.Id == id);

            if (Student == null)
                return NotFound();

            return Ok(Student);
        }

        // POST: api/Student
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> PostStudent(Student Student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Students.Add(Student);

            return CreatedAtRoute("DefaultApi", new { id = Student.Id }, Student);
        }

        // PUT: api/Students/5
        public async Task<IHttpActionResult> PutStudent(int id, Student Student)
        {
            var StudentFromPersist = _context.Students.FirstOrDefault(item => item.Id == id);

            if (StudentFromPersist == null)
                return NotFound();

            StudentFromPersist.Name = Student.Name;
            StudentFromPersist.GroupId = Student.GroupId;

            return Ok();
        }

        // DELETE: api/Student/5
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            var StudentFromPersist = _context.Students.FirstOrDefault(item => item.Id == id);

            if (StudentFromPersist == null)
                return NotFound();

            _context.Students.Remove(StudentFromPersist);

            return Ok();
        }
    }
}
