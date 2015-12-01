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
using Wufio.Core;
using Wufio.Core.Domain;
using Wufio.Core.Infastructure;
using Wufio.Core.Models;

namespace Wufio.Api.Controllers
{
    public class AnimalTypesController : ApiController
    {
        private WufioDbContext db = new WufioDbContext();

        // GET: api/AnimalTypes
        public IEnumerable<AnimalTypeModel> GetAnimalTypes()
        {
            return Mapper.Map<IEnumerable<AnimalTypeModel>>(db.AnimalTypes);
        }

        // GET: api/AnimalTypes/5
        [ResponseType(typeof(AnimalTypeModel))]
        public IHttpActionResult GetAnimalType(int id)
        {
            AnimalType dbAnimalType = db.AnimalTypes.Find(id);
            if (dbAnimalType == null)
            {
                return NotFound();
            }

            AnimalTypeModel animalType = Mapper.Map<AnimalTypeModel>(dbAnimalType);

            return Ok(animalType);
        }

        // PUT: api/AnimalTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnimalType(int id, AnimalTypeModel animalType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animalType.AnimalTypeId)
            {
                return BadRequest();
            }

            var dbAnimalType = db.AnimalTypes.Find(id);

            dbAnimalType.Update(animalType);

            db.Entry(dbAnimalType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Unable to update animal type");
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AnimalTypes
        [ResponseType(typeof(AnimalTypeModel))]
        public IHttpActionResult PostAnimalType(AnimalTypeModel animalType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AnimalType dbAnimalType = new AnimalType();

            dbAnimalType.Update(animalType);

            db.AnimalTypes.Add(dbAnimalType);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("Unable to add animal type");
            }

            return CreatedAtRoute("DefaultApi", new { id = animalType.AnimalTypeId }, animalType);
        }

        // DELETE: api/AnimalTypes/5
        [ResponseType(typeof(AnimalTypeModel))]
        public IHttpActionResult DeleteAnimalType(int id)
        {
            AnimalType animalType = db.AnimalTypes.Find(id);
            if (animalType == null)
            {
                return NotFound();
            }

            db.AnimalTypes.Remove(animalType);


            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("Unable to delete animal type");
            }

            return Ok(Mapper.Map<AnimalTypeModel>(animalType));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnimalTypeExists(int id)
        {
            return db.AnimalTypes.Count(e => e.AnimalTypeId == id) > 0;
        }
    }
}