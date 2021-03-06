﻿using CNCDataManager.APIs.Models;
using CNCDataManager.APIs.Internals;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace CNCDataManager.APIs.Controllers
{
    //[ApiAuthorize]
    [EnableCors(origins: "http://localhost:9000", headers: "*", methods: "*")]
    public class FlexiblePinCoupsController : ApiController
    {
        private CNCMachineData db = new CNCMachineData();

        // GET: api/FlexiblePinCoups
        [AllowAnonymous]
        public IQueryable<FlexiblePinCoup> GetFlexiblePinCouplings()
        {
            return db.FlexiblePinCouplings;
        }

        // GET: api/FlexiblePinCoups/5
        [AllowAnonymous]
        [ResponseType(typeof(FlexiblePinCoup))]
        public async Task<IHttpActionResult> GetFlexiblePinCoup(string id)
        {
            FlexiblePinCoup flexiblePinCoup = await db.FlexiblePinCouplings.FindAsync(id);
            if (flexiblePinCoup == null)
            {
                return NotFound();
            }

            return Ok(flexiblePinCoup);
        }

        // PUT: api/FlexiblePinCoups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFlexiblePinCoup(string id, FlexiblePinCoup flexiblePinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flexiblePinCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(flexiblePinCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlexiblePinCoupExists(id))
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

        // POST: api/FlexiblePinCoups
        [ResponseType(typeof(FlexiblePinCoup))]
        public async Task<IHttpActionResult> PostFlexiblePinCoup(FlexiblePinCoup flexiblePinCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FlexiblePinCouplings.Add(flexiblePinCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlexiblePinCoupExists(flexiblePinCoup.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = flexiblePinCoup.TypeID }, flexiblePinCoup);
        }

        // DELETE: api/FlexiblePinCoups/5
        [ResponseType(typeof(FlexiblePinCoup))]
        public async Task<IHttpActionResult> DeleteFlexiblePinCoup(string id)
        {
            FlexiblePinCoup flexiblePinCoup = await db.FlexiblePinCouplings.FindAsync(id);
            if (flexiblePinCoup == null)
            {
                return NotFound();
            }

            db.FlexiblePinCouplings.Remove(flexiblePinCoup);
            await db.SaveChangesAsync();

            return Ok(flexiblePinCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlexiblePinCoupExists(string id)
        {
            return db.FlexiblePinCouplings.Count(e => e.TypeID == id) > 0;
        }
    }
}