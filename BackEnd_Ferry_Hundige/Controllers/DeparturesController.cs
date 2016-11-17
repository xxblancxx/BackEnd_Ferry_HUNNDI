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
using BackEnd_Ferry_Hundige;

namespace BackEnd_Ferry_Hundige.Controllers
{
    public class DeparturesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Departures
        public IQueryable<Departure> GetDepartures()
        {
            return db.Departures;
        }

        // GET: api/Departures/5
        [ResponseType(typeof(Departure))]
        public async Task<IHttpActionResult> GetDeparture(int id)
        {
            Departure departure = await db.Departures.FindAsync(id);
            if (departure == null)
            {
                return NotFound();
            }

            return Ok(departure);
        }

        // PUT: api/Departures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDeparture(int id, Departure departure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departure.ID)
            {
                return BadRequest();
            }

            db.Entry(departure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartureExists(id))
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

        // POST: api/Departures
        [ResponseType(typeof(Departure))]
        public async Task<IHttpActionResult> PostDeparture(Departure departure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departures.Add(departure);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepartureExists(departure.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = departure.ID }, departure);
        }

        // DELETE: api/Departures/5
        [ResponseType(typeof(Departure))]
        public async Task<IHttpActionResult> DeleteDeparture(int id)
        {
            Departure departure = await db.Departures.FindAsync(id);
            if (departure == null)
            {
                return NotFound();
            }

            db.Departures.Remove(departure);
            await db.SaveChangesAsync();

            return Ok(departure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartureExists(int id)
        {
            return db.Departures.Count(e => e.ID == id) > 0;
        }
    }
}