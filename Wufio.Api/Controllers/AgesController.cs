using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Wufio.Core.Domain;
using Wufio.Core.Infastructure;
using Wufio.Core.Models;

namespace Wufio.Api.Controllers
{
    public class AgesController : ApiController
    {
        private WufioDbContext db = new WufioDbContext();

        // GET: api/Ages
        public IEnumerable<AgeModel> GetAges()
        {
            return Mapper.Map<IEnumerable<AgeModel>> (db.Ages);
        }

        // GET: api/Ages/5
        [ResponseType(typeof(AgeModel))]
        public IHttpActionResult GetAge(int id)
        {
            Age dbAge = db.Ages.Find(id);
            if (dbAge == null)
            {
                return NotFound();
            }

            AgeModel age = Mapper.Map<AgeModel>(dbAge);

            return Ok(age);
        }

        // PUT: api/Ages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAge(int id, Age age)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != age.AgeId)
            {
                return BadRequest();
            }

            db.Entry(age).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgeExists(id))
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

        // POST: api/Ages
        [ResponseType(typeof(Age))]
        public IHttpActionResult PostAge(Age age)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ages.Add(age);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = age.AgeId }, age);
        }

        // DELETE: api/Ages/5
        [ResponseType(typeof(Age))]
        public IHttpActionResult DeleteAge(int id)
        {
            Age age = db.Ages.Find(id);
            if (age == null)
            {
                return NotFound();
            }

            db.Ages.Remove(age);
            db.SaveChanges();

            return Ok(age);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgeExists(int id)
        {
            return db.Ages.Count(e => e.AgeId == id) > 0;
        }
    }
}