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
using Bet365Project;
using Bet365Project.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bet365Project.Controllers
{
    public class ScoccersController : ApiController
    {
        private MainDbContext db = new MainDbContext();

        // GET: api/Scoccers
        public IQueryable<Scoccer> Getscoccer()
        {
            return db.scoccer;
        }

        // GET: api/Scoccers
        public HttpResponseMessage GetScheduleSoccer()
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(db.scoccer)); ;
        }

        // GET: api/Scoccers/5
        [ResponseType(typeof(Scoccer))]
        public async Task<IHttpActionResult> GetScoccer(int id)
        {
            Scoccer scoccer;
            try
            {
                scoccer = await db.scoccer.Where(u => u.ID == id).FirstAsync();
                if (scoccer == null)
                {
                    return NotFound();
                }
                return Ok(scoccer);

            }
            catch (Exception ex)
            {

            }
            throw new Exception();
        }

        // PUT: api/Scoccers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutScoccer(int id, Scoccer scoccer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scoccer.ID)
            {
                return BadRequest();
            }

            db.Entry(scoccer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoccerExists(id))
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

        // POST: api/Scoccers
        [ResponseType(typeof(Scoccer))]
        public async Task<IHttpActionResult> PostScoccer(Scoccer scoccer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.scoccer.Add(scoccer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = scoccer.ID }, scoccer);
        }

        // DELETE: api/Scoccers/5
        [ResponseType(typeof(Scoccer))]
        public async Task<IHttpActionResult> DeleteScoccer(int id)
        {
            Scoccer scoccer = await db.scoccer.FindAsync(id);
            if (scoccer == null)
            {
                return NotFound();
            }

            db.scoccer.Remove(scoccer);
            await db.SaveChangesAsync();

            return Ok(scoccer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScoccerExists(int id)
        {
            return db.scoccer.Count(e => e.ID == id) > 0;
        }
    }
}