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
    public class GroupController : ApiController
    {
        APIContext _context = APIContext.Instance;

        // GET: api/Groups
        public IQueryable<Group> GetGroups()
        {
            var groupsList = _context.Groups;
            groupsList.ForEach(x => x.TeacherName = _context.Teachers.FirstOrDefault(i => i.Id == x.TeacherId)?.Name);
            return groupsList.AsQueryable();
        }

        // GET: api/Groups/5
        [ResponseType(typeof(Group))]
        public async Task<IHttpActionResult> GetGroup(int id)
        {
            var group = _context.Groups.FirstOrDefault(item => item.Id == id);

            if (group == null)
                return NotFound();

            return Ok(group);
        }

        // POST: api/Group
        [ResponseType(typeof(Group))]
        public async Task<IHttpActionResult> PostGroup(Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            group.Id = IdGenerator.Instanse.GetId<Group>();
            _context.Groups.Add(group);

            return CreatedAtRoute("DefaultApi", new { id = group.Id }, group);
        }

        // PUT: api/Groups/5
        public async Task<IHttpActionResult> PutGroup(int id, Group group)
        {
            var groupFromPersist = _context.Groups.FirstOrDefault(item => item.Id == id);

            if (groupFromPersist == null)
                return NotFound();

            groupFromPersist.Name = group.Name;
            groupFromPersist.TeacherId = group.TeacherId;

            return Ok();
        }

        // DELETE: api/Group/5
        public async Task<IHttpActionResult> DeleteGroup(int id)
        {
            var groupFromPersist = _context.Groups.FirstOrDefault(item => item.Id == id);

            if (groupFromPersist == null)
                return NotFound();

            _context.Groups.Remove(groupFromPersist);

            return Ok();
        }
    }
}
