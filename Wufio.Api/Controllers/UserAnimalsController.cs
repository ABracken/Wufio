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
using Wufio.Core.Models;

namespace Wufio.Api.Controllers
{
    public class UserAnimalsController : ApiController
    {
        private AuthContext db = new AuthContext();

        // GET: api/UserAnimals
        public IEnumerable<UserAnimalModel> GetUserAnimals()
        {
            return Mapper.Map<IEnumerable<UserAnimalModel>>(db.UserAnimals);
        }

        // GET: api/UserAnimals/5
        [ResponseType(typeof(UserAnimalModel))]
        public IHttpActionResult GetUserAnimal(int id)
        {
            UserAnimal dbUserAnimal = db.UserAnimals.Find(id);
            if (dbUserAnimal == null)
            {
                return NotFound();
            }

            UserAnimalModel userAnimal = Mapper.Map<UserAnimalModel>(dbUserAnimal);

            return Ok(userAnimal);
        }

        // PUT: api/UserAnimals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAnimal(int id, UserAnimalModel userAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAnimal.UserAnimalId)
            {
                return BadRequest();
            }

            var dbUserAnimal = db.UserAnimals.Find(id);

            dbUserAnimal.Update(userAnimal);

            db.Entry(userAnimal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAnimalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception("Unable to update");
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/UserAnimals
        [ResponseType(typeof(UserAnimalModel))]
        public IHttpActionResult PostUserAnimal(UserAnimalModel userAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserAnimal dbUserAnimal = new UserAnimal;

            dbUserAnimal.Update(userAnimal);

            db.UserAnimals.Add(dbUserAnimal);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("Unable to add");
            }

            return CreatedAtRoute("DefaultApi", new { id = userAnimal.UserAnimalId }, userAnimal);
        }

        // DELETE: api/UserAnimals/5
        [ResponseType(typeof(UserAnimalModel))]
        public IHttpActionResult DeleteUserAnimal(int id)
        {
            UserAnimal userAnimal = db.UserAnimals.Find(id);
            if (userAnimal == null)
            {
                return NotFound();
            }

            db.UserAnimals.Remove(userAnimal);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("Unable to delete");
            }

            return Ok(Mapper.Map<UserAnimalModel>(userAnimal));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAnimalExists(int id)
        {
            return db.UserAnimals.Count(e => e.UserAnimalId == id) > 0;
        }
    }
}