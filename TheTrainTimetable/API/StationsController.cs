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
    public class StationsController : ApiController
    {
        private TheTrainTimetableContext db = new TheTrainTimetableContext();

        // GET: api/Stations
        public IQueryable<Station> Getstations()
        {
            var stations = from S in db.stations
                           select new StationDTO()
                           {
                               StationId = S.StationiD,
                               StationName = S.StationName,
                               NorthBound = S.NorthBound,
                               SouthBound = S.SouthBound,

                           };

            return db.stations;
        }

        // GET: api/Stations/5
        [ResponseType(typeof(Station))]
        public async Task<IHttpActionResult> GetStation(int id)
        {
            Station S = await db.stations.FindAsync(id);
            if (S == null)
            {
                return NotFound();
            }


            StationDTO stationDTO = new StationDTO
            {
                StationId = S.StationiD,
                StationName = S.StationName,
                NorthBound = S.NorthBound,
                SouthBound = S.SouthBound,

            };

            return Ok(S);
        }

        // PUT: api/Stations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStation(int id, Station station)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != station.StationiD)
            {
                return BadRequest();
            }

            db.Entry(station).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationExists(id))
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

        // POST: api/Stations
        [ResponseType(typeof(Station))]
        public async Task<IHttpActionResult> PostStation(Station station)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.stations.Add(station);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = station.StationiD }, station);
        }

        // DELETE: api/Stations/5
        [ResponseType(typeof(Station))]
        public async Task<IHttpActionResult> DeleteStation(int id)
        {
            Station station = await db.stations.FindAsync(id);
            if (station == null)
            {
                return NotFound();
            }

            db.stations.Remove(station);
            await db.SaveChangesAsync();

            return Ok(station);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StationExists(int id)
        {
            return db.stations.Count(e => e.StationiD == id) > 0;
        }
    }
}