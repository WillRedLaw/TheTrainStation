using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TheTrainTimetable.Models;

namespace TheTrainTimetable.API
{
    public class TimetablesController : ApiController
    {
        private TheTrainTimetableContext db = new TheTrainTimetableContext();

        // GET: api/Timetables
        public IQueryable<Timetable> Gettimetables()
        {


            

           

            return db.timetables;
        }

        // GET: api/Timetables/5
        [ResponseType(typeof(Timetable))]
        public async Task<IHttpActionResult> GetTimetable(int id)
        {


            return Ok();
        }

        // PUT: api/Timetables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTimetable(int id, Timetable timetable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timetable.TimetableiD)
            {
                return BadRequest();
            }

            db.Entry(timetable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimetableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Timetables
        [ResponseType(typeof(Timetable))]
        public async Task<IHttpActionResult> PostTimetable(Timetable timetable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.timetables.Add(timetable);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = timetable.TimetableiD }, timetable);
        }

        // DELETE: api/Timetables/5
        [ResponseType(typeof(Timetable))]
        public async Task<IHttpActionResult> DeleteTimetable(int id)
        {
            Timetable timetable = await db.timetables.FindAsync(id);
            if (timetable == null)
            {
                return NotFound();
            }

            db.timetables.Remove(timetable);
            await db.SaveChangesAsync();

            return Ok(timetable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimetableExists(int id)
        {
            return db.timetables.Count(e => e.TimetableiD == id) > 0;
        }
    }
}