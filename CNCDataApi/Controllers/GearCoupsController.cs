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
using CNCDataApi.Models;

namespace CNCDataApi.Controllers
{
    public class GearCoupsController : ApiController
    {
        private CNCMachineComponentData db = new CNCMachineComponentData();

        // GET: api/GearCoups
        public IQueryable<GearCoup> GetGearCoupling()
        {
            return db.GearCoupling;
        }

        // GET: api/GearCoups/5
        [ResponseType(typeof(GearCoup))]
        public async Task<IHttpActionResult> GetGearCoup(string id)
        {
            GearCoup gearCoup = await db.GearCoupling.FindAsync(id);
            if (gearCoup == null)
            {
                return NotFound();
            }

            return Ok(gearCoup);
        }

        // PUT: api/GearCoups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGearCoup(string id, GearCoup gearCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gearCoup.TypeID)
            {
                return BadRequest();
            }

            db.Entry(gearCoup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GearCoupExists(id))
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

        // POST: api/GearCoups
        [ResponseType(typeof(GearCoup))]
        public async Task<IHttpActionResult> PostGearCoup(GearCoup gearCoup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GearCoupling.Add(gearCoup);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GearCoupExists(gearCoup.TypeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gearCoup.TypeID }, gearCoup);
        }

        // DELETE: api/GearCoups/5
        [ResponseType(typeof(GearCoup))]
        public async Task<IHttpActionResult> DeleteGearCoup(string id)
        {
            GearCoup gearCoup = await db.GearCoupling.FindAsync(id);
            if (gearCoup == null)
            {
                return NotFound();
            }

            db.GearCoupling.Remove(gearCoup);
            await db.SaveChangesAsync();

            return Ok(gearCoup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GearCoupExists(string id)
        {
            return db.GearCoupling.Count(e => e.TypeID == id) > 0;
        }
    }
}