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
using Wufio.Core.Infastructure;
using Wufio.Core.Models;

namespace Wufio.Api.Controllers
{
    public class AnimalsController : ApiController
    {
        private WufioDbContext db = new WufioDbContext();

        // GET: api/Animals
        public IEnumerable<AnimalModel> GetAnimals()
        {
            return Mapper.Map<IEnumerable<AnimalModel>>(db.Animals);
        }

        // GET: api/Animals/5
        [ResponseType(typeof(AnimalModel))]
        public IHttpActionResult GetAnimal(int id)
        {
            Animal dbAnimal = db.Animals.Find(id);
            if (dbAnimal == null)
            {
                return NotFound();
            }

            AnimalModel animal = Mapper.Map<AnimalModel>(dbAnimal);

            return Ok(animal);
        }

        // PUT: api/Animals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnimal(int id, AnimalModel animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animal.AnimalId)
            {
                return BadRequest();
            }
            var dbAnimal = db.Animals.Find(id);

            dbAnimal.Update(animal);

            db.Entry(dbAnimal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Unable to update animal");
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Animals
        [ResponseType(typeof(AnimalModel))]
        public IHttpActionResult PostAnimal(AnimalModel animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Animal dbAnimal = new Animal();

            dbAnimal.Update(animal);

            db.Animals.Add(dbAnimal);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("Unable to add animal");
            }

            return CreatedAtRoute("DefaultApi", new { id = animal.AnimalId }, animal);
        }

        // DELETE: api/Animals/5
        [ResponseType(typeof(AnimalModel))]
        public IHttpActionResult DeleteAnimal(int id)
        {
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }

            db.Animals.Remove(animal);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("Unable to delete animal");
            }

            return Ok(Mapper.Map<AnimalModel>(animal));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnimalExists(int id)
        {
            return db.Animals.Count(e => e.AnimalId == id) > 0;
        }
    }
}