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
    public class ItemCategoriesController : ApiController
    {
        private QAFB_DBEntities db = new QAFB_DBEntities();

        // GET: api/ItemCategories
        public IQueryable<ItemCategory> GetItemCategories()
        {
            return db.ItemCategories;
        }

        // GET: api/ItemCategories/5
        [ResponseType(typeof(ItemCategory))]
        public async Task<IHttpActionResult> GetItemCategory(int id)
        {
            ItemCategory itemCategory = await db.ItemCategories.FindAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            return Ok(itemCategory);
        }

        // PUT: api/ItemCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutItemCategory(int id, ItemCategory itemCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemCategory.Id)
            {
                return BadRequest();
            }

            db.Entry(itemCategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemCategoryExists(id))
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

        // POST: api/ItemCategories
        [ResponseType(typeof(ItemCategory))]
        public async Task<IHttpActionResult> PostItemCategory(ItemCategory itemCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemCategories.Add(itemCategory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = itemCategory.Id }, itemCategory);
        }

        // DELETE: api/ItemCategories/5
        [ResponseType(typeof(ItemCategory))]
        public async Task<IHttpActionResult> DeleteItemCategory(int id)
        {
            ItemCategory itemCategory = await db.ItemCategories.FindAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            db.ItemCategories.Remove(itemCategory);
            await db.SaveChangesAsync();

            return Ok(itemCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemCategoryExists(int id)
        {
            return db.ItemCategories.Count(e => e.Id == id) > 0;
        }
    }
}