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
using QAFoodBank.MobileAPI.Models;

namespace QAFoodBank.MobileAPI.Controllers
{
    public class ItemPrioritiesController : ApiController
    {
        private QAFB_DBEntities db = new QAFB_DBEntities();

        // GET: api/ItemPriorities
        public IQueryable<ItemPriority> GetItemPriorities()
        {
            return db.ItemPriorities;   
        }

        // GET: api/ItemPriorities/5
        [ResponseType(typeof(ItemPriority))]
        public async Task<IHttpActionResult> GetItemPriority(int id)
        {
            ItemPriority itemPriority = await db.ItemPriorities.FindAsync(id);
            if (itemPriority == null)
            {
                return NotFound();
            }

            return Ok(itemPriority);
        }

        // PUT: api/ItemPriorities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutItemPriority(int id, ItemPriority itemPriority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemPriority.Id)
            {
                return BadRequest();
            }

            db.Entry(itemPriority).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPriorityExists(id))
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

        // POST: api/ItemPriorities
        [ResponseType(typeof(ItemPriority))]
        public async Task<IHttpActionResult> PostItemPriority(ItemPriority itemPriority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemPriorities.Add(itemPriority);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = itemPriority.Id }, itemPriority);
        }

        // DELETE: api/ItemPriorities/5
        [ResponseType(typeof(ItemPriority))]
        public async Task<IHttpActionResult> DeleteItemPriority(int id)
        {
            ItemPriority itemPriority = await db.ItemPriorities.FindAsync(id);
            if (itemPriority == null)
            {
                return NotFound();
            }

            db.ItemPriorities.Remove(itemPriority);
            await db.SaveChangesAsync();

            return Ok(itemPriority);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemPriorityExists(int id)
        {
            return db.ItemPriorities.Count(e => e.Id == id) > 0;
        }
    }
}