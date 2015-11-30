using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Wufio.Core;
using Wufio.Core.Domain;
using Wufio.Core.Models;

namespace Wufio.Api.Controllers
{
    public class RescuesController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET: api/Rescues
        public IEnumerable<RescueModel> GetRescues()
        {
            return Mapper.Map<IEnumerable<RescueModel>>(db.Rescues);
        }

        // GET: api/Rescues/5
        [ResponseType(typeof(RescueModel))]
        public IHttpActionResult GetRescue(int id)
        {
            Rescue dbRescue = db.Rescues.Find(id);
            if (dbRescue == null)
            {
                return NotFound();
            }

            RescueModel rescue = Mapper.Map<RescueModel>(dbRescue);

            return Ok(rescue);
        }

        // PUT: api/Rescues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRescue(int id, RescueModel rescue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rescue.RescueId)
            {
                return BadRequest();
            }

            var dbRescue = db.Rescues.Find(id);

            dbRescue.Update(rescue);

            db.Entry(rescue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RescueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Unable to update rescue");
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Rescues
        [ResponseType(typeof(RescueModel))]
        public IHttpActionResult PostRescue(RescueModel rescue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Rescue dbRescue = new Rescue();

            dbRescue.Update(rescue);

            db.Rescues.Add(dbRescue);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("Unable to add rescue");
            }

            return CreatedAtRoute("DefaultApi", new { id = rescue.RescueId }, rescue);
        }

        // DELETE: api/Rescues/5
        [ResponseType(typeof(RescueModel))]
        public IHttpActionResult DeleteRescue(int id)
        {
            Rescue rescue = db.Rescues.Find(id);
            if (rescue == null)
            {
                return NotFound();
            }

            db.Rescues.Remove(rescue);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("Unable to delete rescue");
            }

            return Ok(Mapper.Map<RescueModel>(rescue));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RescueExists(int id)
        {
            return db.Rescues.Count(e => e.RescueId == id) > 0;
        }
    }
}