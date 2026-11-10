using CispOData.Data;
using CispOData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace CispOData.Controllers
{
    public class SubjectsController : ODataController
    {
        private readonly StudentContext _db;

        public SubjectsController(StudentContext db) => _db = db;

        // GET /odata/Subjects
        [EnableQuery]
        public IQueryable<Subjects> Get() => _db.Subjects;

        // GET /odata/Subjects(1)
        [EnableQuery]
        public SingleResult<Subjects> Get(int key) =>
            SingleResult.Create(_db.Subjects.Where(x => x.Id == key));

        // POST /odata/Subjects
        public IActionResult Post([FromBody] Subjects item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _db.Subjects.Add(item);
            _db.SaveChanges();
            return Created(item);
        }

        // PUT /odata/Subjects(1)
        public IActionResult Put(int key, [FromBody] Subjects item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_db.Subjects.Any(x => x.Id == key)) return NotFound();

            item.Id = key;
            _db.Subjects.Update(item);
            _db.SaveChanges();
            return Updated(item);
        }

        // DELETE /odata/Subjects(1)
        public IActionResult Delete(int key)
        {
            var item = _db.Subjects.Find(key);
            if (item == null) return NotFound();

            _db.Subjects.Remove(item);
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
