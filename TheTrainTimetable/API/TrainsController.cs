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
    public class TrainsController : ApiController
    {
        private TheTrainTimetableContext db = new TheTrainTimetableContext();

        // GET: api/Trains
        public IQueryable<Train> Gettrains()
        {
            var trains = from T in db.trains
                         select new TrainDTO()
                         {
                             TrainId = T.TrainiD,
                             TrainName = T.TrainName,
                             TrainCapcity = T.TrainCapcity,
                             IsTrainRunningToday = T.TrainRunningToday,

                         };
            return db.trains;
        }

        // GET: api/Trains/5
        [ResponseType(typeof(Train))]
        public async Task<IHttpActionResult> GetTrain(int id)
        {
            Train T = await db.trains.FindAsync(id);
            if (T == null)
            {
                return NotFound();
            }

            TrainDTO trainDTO = new TrainDTO
            {
                TrainId = T.TrainiD,
                TrainName = T.TrainName,
                TrainCapcity = T.TrainCapcity,
                IsTrainRunningToday = T.TrainRunningToday,
            };

            return Ok(T);
        }

        // PUT: api/Trains/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTrain(int id, Train train)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != train.TrainiD)
            {
                return BadRequest();
            }

            db.Entry(train).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainExists(id))
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

        // POST: api/Trains
        [ResponseType(typeof(Train))]
        public async Task<IHttpActionResult> PostTrain(Train train)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.trains.Add(train);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = train.TrainiD }, train);
        }

        // DELETE: api/Trains/5
        [ResponseType(typeof(Train))]
        public async Task<IHttpActionResult> DeleteTrain(int id)
        {
            Train train = await db.trains.FindAsync(id);
            if (train == null)
            {
                return NotFound();
            }

            db.trains.Remove(train);
            await db.SaveChangesAsync();

            return Ok(train);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrainExists(int id)
        {
            return db.trains.Count(e => e.TrainiD == id) > 0;
        }
    }
}