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
    public class TicketTypesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/TicketTypes
        public IQueryable<TicketType> GetTicketTypes()
        {
            return db.TicketTypes;
        }

        // GET: api/TicketTypes/5
        [ResponseType(typeof(TicketType))]
        public async Task<IHttpActionResult> GetTicketType(int id)
        {
            TicketType ticketType = await db.TicketTypes.FindAsync(id);
            if (ticketType == null)
            {
                return NotFound();
            }

            return Ok(ticketType);
        }

        // PUT: api/TicketTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTicketType(int id, TicketType ticketType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketType.ID)
            {
                return BadRequest();
            }

            db.Entry(ticketType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketTypeExists(id))
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

        // POST: api/TicketTypes
        [ResponseType(typeof(TicketType))]
        public async Task<IHttpActionResult> PostTicketType(TicketType ticketType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TicketTypes.Add(ticketType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TicketTypeExists(ticketType.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ticketType.ID }, ticketType);
        }

        // DELETE: api/TicketTypes/5
        [ResponseType(typeof(TicketType))]
        public async Task<IHttpActionResult> DeleteTicketType(int id)
        {
            TicketType ticketType = await db.TicketTypes.FindAsync(id);
            if (ticketType == null)
            {
                return NotFound();
            }

            db.TicketTypes.Remove(ticketType);
            await db.SaveChangesAsync();

            return Ok(ticketType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketTypeExists(int id)
        {
            return db.TicketTypes.Count(e => e.ID == id) > 0;
        }
    }
}