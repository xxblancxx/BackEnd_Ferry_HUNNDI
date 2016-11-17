﻿using System;
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
    public class PricesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Prices
        public IQueryable<Price> GetPrices()
        {
            return db.Prices;
        }

        // GET: api/Prices/5
        [ResponseType(typeof(Price))]
        public async Task<IHttpActionResult> GetPrice(int id)
        {
            Price price = await db.Prices.FindAsync(id);
            if (price == null)
            {
                return NotFound();
            }

            return Ok(price);
        }

        // PUT: api/Prices/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrice(int id, Price price)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != price.ID)
            {
                return BadRequest();
            }

            db.Entry(price).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceExists(id))
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

        // POST: api/Prices
        [ResponseType(typeof(Price))]
        public async Task<IHttpActionResult> PostPrice(Price price)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prices.Add(price);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PriceExists(price.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = price.ID }, price);
        }

        // DELETE: api/Prices/5
        [ResponseType(typeof(Price))]
        public async Task<IHttpActionResult> DeletePrice(int id)
        {
            Price price = await db.Prices.FindAsync(id);
            if (price == null)
            {
                return NotFound();
            }

            db.Prices.Remove(price);
            await db.SaveChangesAsync();

            return Ok(price);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PriceExists(int id)
        {
            return db.Prices.Count(e => e.ID == id) > 0;
        }
    }
}