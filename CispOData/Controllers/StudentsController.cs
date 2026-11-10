using CispOData.Data;
using CispOData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace CispOData.Controllers
{
    public class StudentsController : ODataController
    {
        private readonly StudentContext _db;

        public StudentsController(StudentContext db) => _db = db;

        // GET /odata/Students
        [EnableQuery]
        public IQueryable<Students> Get() => _db.Students;

        // GET /odata/Students(1)
        [EnableQuery]
        public SingleResult<Students> Get(int key) =>
            SingleResult.Create(_db.Students.Where(x => x.Id == key));

        // POST /odata/Students
        public IActionResult Post([FromBody] Students item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _db.Students.Add(item);
            _db.SaveChanges();
            return Created(item);
        }

        // PUT /odata/Students(1)
        public IActionResult Put(int key, [FromBody] Students item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_db.Students.Any(x => x.Id == key)) return NotFound();

            item.Id = key;
            _db.Students.Update(item);
            _db.SaveChanges();
            return Updated(item);
        }

        // DELETE /odata/Students(1)
        public IActionResult Delete(int key)
        {
            var item = _db.Students.Find(key);
            if (item == null) return NotFound();

            _db.Students.Remove(item);
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Не можна видалити: на цей запис посилаються інші таблиці");
            }
            return NoContent();
        }
    }
}
