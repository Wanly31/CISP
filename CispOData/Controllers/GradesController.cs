using CispOData.Data;
using CispOData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace CispOData.Controllers
{
    public class GradesController : ODataController
    {
        private readonly StudentContext _db;

        public GradesController(StudentContext db) => _db = db;

        // GET /odata/Grades
        [EnableQuery]
        public IQueryable<Grades> Get() => _db.Grades;

        // GET /odata/Grades(1)
        [EnableQuery]
        public SingleResult<Grades> Get(int key) =>
            SingleResult.Create(_db.Grades.Where(x => x.Id == key));

        // POST /odata/Grades
        public IActionResult Post([FromBody] Grades item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _db.Grades.Add(item);
            _db.SaveChanges();
            return Created(item);
        }

        // PUT /odata/Grades(1)
        public IActionResult Put(int key, [FromBody] Grades item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_db.Grades.Any(x => x.Id == key)) return NotFound();

            item.Id = key;
            _db.Grades.Update(item);
            _db.SaveChanges();
            return Updated(item);
        }

        // DELETE /odata/Grades(1)
        public IActionResult Delete(int key)
        {
            var item = _db.Grades.Find(key);
            if (item == null) return NotFound();

            _db.Grades.Remove(item);
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
