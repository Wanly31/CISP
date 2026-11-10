using CispOData.Data;
using CispOData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace CispOData.Controllers
{
    public class TeachersController : ODataController
    {
        private readonly StudentContext _db;

        public TeachersController(StudentContext db) => _db = db;

        // GET /odata/Teachers
        [EnableQuery]
        public IQueryable<Teachers> Get() => _db.Teachers;

        // GET /odata/Teachers(1)
        [EnableQuery]
        public SingleResult<Teachers> Get(int key) =>
            SingleResult.Create(_db.Teachers.Where(x => x.Id == key));

        // POST /odata/Teachers
        public IActionResult Post([FromBody] Teachers item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _db.Teachers.Add(item);
            _db.SaveChanges();
            return Created(item);
        }

        // PUT /odata/Teachers(1)
        public IActionResult Put(int key, [FromBody] Teachers item)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_db.Teachers.Any(x => x.Id == key)) return NotFound();

            item.Id = key;
            _db.Teachers.Update(item);
            _db.SaveChanges();
            return Updated(item);
        }

        // DELETE /odata/Teachers(1)
        public IActionResult Delete(int key)
        {
            var item = _db.Teachers.Find(key);
            if (item == null) return NotFound();

            _db.Teachers.Remove(item);
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
