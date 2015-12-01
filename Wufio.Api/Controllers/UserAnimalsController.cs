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
    public class UserAnimalsController : ApiController
    {
        private WufioDbContext db = new WufioDbContext();

        
        // POST: api/UserAnimals
        [ResponseType(typeof(UserAnimalModel))]
        public IHttpActionResult PostUserAnimal(UserAnimalModel userAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserAnimal dbUserAnimal = new UserAnimal();

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

            return CreatedAtRoute("DefaultApi", new { userId = userAnimal.WufioUserId, animalId = userAnimal.AnimalId }, userAnimal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAnimalExists(string userId, int animalId)
        {
            return db.UserAnimals.Any(ua => ua.WufioUserId == userId && ua.AnimalId == animalId);
        }
    }
}