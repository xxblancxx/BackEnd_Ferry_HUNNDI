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
    public class FerriesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Ferries
        public IQueryable<Ferry> GetFerries()
        {
            return db.Ferries;
        }

        // GET: api/Ferries/5
        [ResponseType(typeof(Ferry))]
        public async Task<IHttpActionResult> GetFerry(int id)
        {
            Ferry ferry = await db.Ferries.FindAsync(id);
            if (ferry == null)
            {
                return NotFound();
            }

            return Ok(ferry);
        }

        // PUT: api/Ferries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFerry(int id, Ferry ferry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ferry.ID)
            {
                return BadRequest();
            }

            db.Entry(ferry).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FerryExists(id))
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

        // POST: api/Ferries
        [ResponseType(typeof(Ferry))]
        public async Task<IHttpActionResult> PostFerry(Ferry ferry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ferries.Add(ferry);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FerryExists(ferry.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ferry.ID }, ferry);
        }

        // DELETE: api/Ferries/5
        [ResponseType(typeof(Ferry))]
        public async Task<IHttpActionResult> DeleteFerry(int id)
        {
            Ferry ferry = await db.Ferries.FindAsync(id);
            if (ferry == null)
            {
                return NotFound();
            }

            db.Ferries.Remove(ferry);
            await db.SaveChangesAsync();

            return Ok(ferry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FerryExists(int id)
        {
            return db.Ferries.Count(e => e.ID == id) > 0;
        }
    }
}