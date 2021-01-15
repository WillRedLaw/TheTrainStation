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
    public class PassengersController : ApiController
    {
        private TheTrainTimetableContext db = new TheTrainTimetableContext();

        // GET: api/Passengers
        public IQueryable<Passenger> Getpassengers()
        {
            return db.passengers;
        }

        // GET: api/Passengers/5
        [ResponseType(typeof(Passenger))]
        public async Task<IHttpActionResult> GetPassenger(int id)
        {
            Passenger P = await db.passengers.FindAsync(id);
            if (P == null)
            {
                return NotFound();
            }

            PassengerDTO passengerDTO = new PassengerDTO
            {
                PassengerId = P.PassengeriD,
                PassengerName = P.PassengerName,
                PreBookedTicket = P.PreBookedTicket,
                TicketPrice = P.TicketPrice,
            };  

            return Ok(P);
        }

        // PUT: api/Passengers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPassenger(int id, Passenger passenger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != passenger.PassengeriD)
            {
                return BadRequest();
            }

            db.Entry(passenger).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerExists(id))
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

        // POST: api/Passengers
        [ResponseType(typeof(Passenger))]
        public async Task<IHttpActionResult> PostPassenger(Passenger passenger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.passengers.Add(passenger);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = passenger.PassengeriD }, passenger);
        }

        // DELETE: api/Passengers/5
        [ResponseType(typeof(Passenger))]
        public async Task<IHttpActionResult> DeletePassenger(int id)
        {
            Passenger passenger = await db.passengers.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }

            db.passengers.Remove(passenger);
            await db.SaveChangesAsync();

            return Ok(passenger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PassengerExists(int id)
        {
            return db.passengers.Count(e => e.PassengeriD == id) > 0;
        }
    }
}