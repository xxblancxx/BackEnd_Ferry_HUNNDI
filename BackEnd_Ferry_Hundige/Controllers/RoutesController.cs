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
    public class RoutesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Routes
        public IQueryable<Route> GetRoutes()
        {
            return db.Routes;
        }

        // GET: api/Routes/5
        [ResponseType(typeof(Route))]
        public async Task<IHttpActionResult> GetRoute(int id)
        {
            Route route = await db.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }

            return Ok(route);
        }

        // PUT: api/Routes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRoute(int id, Route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != route.ID)
            {
                return BadRequest();
            }

            db.Entry(route).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RouteExists(id))
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

        // POST: api/Routes
        [ResponseType(typeof(Route))]
        public async Task<IHttpActionResult> PostRoute(Route route)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Routes.Add(route);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RouteExists(route.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = route.ID }, route);
        }

        // DELETE: api/Routes/5
        [ResponseType(typeof(Route))]
        public async Task<IHttpActionResult> DeleteRoute(int id)
        {
            Route route = await db.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }

            db.Routes.Remove(route);
            await db.SaveChangesAsync();

            return Ok(route);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RouteExists(int id)
        {
            return db.Routes.Count(e => e.ID == id) > 0;
        }
    }
}