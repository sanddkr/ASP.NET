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
using SportService.Models;

namespace SportService.Controllers
{
    public class AthletesController : ApiController
    {
        private SportServiceContext db = new SportServiceContext();

        // GET: api/Athletes
        //public IQueryable<Athlete> GetAthletes()
        //{
        //    return db.Athletes 
        //            .Include(t => t.team);// new code:
        //}

        // GET api/Athletes
        public IQueryable<AthleteDTO> GetAthletes()
        {
            var athletes = from a in db.Athletes
                        select new AthleteDTO()
                        {
                            student_number = a.student_number,
                            student_firstname = a.student_firstname,
                            student_lastname = a.student_lastname
                        };

            return athletes;
        }

        // GET api/AthletesByTeam/5
        public IQueryable<AthleteDetailDTO> GetAthletesByTeam(string team)
        {
            var athletes = from a in db.Athletes
                           where a.type_of_sport.Equals(team)
                           select new AthleteDetailDTO()
                           {
                               student_number = a.student_number,
                               student_name = a.student_firstname + " " + a.student_lastname,
                               height = a.height,
                               birthday = a.birthday,
                               type_of_sport = a.type_of_sport
                           };

            return athletes;
        }

        // GET: api/Athletes/5
        [ResponseType(typeof(AthleteDetailDTO))]
        public async Task<IHttpActionResult> GetAthlete(string id)
        {
            //Athlete athlete = await db.Athletes.FindAsync(id);
            //if (athlete == null)
            //{
            //    return NotFound();
            //}

            //return Ok(athlete);

            var athlete = await db.Athletes.Include(a => a.team).Select(a =>
                new AthleteDetailDTO()
                {
                    student_number = a.student_number,
                    student_name = a.student_firstname + " " + a.student_lastname,
                    birthday =  a.birthday,
                    type_of_sport = a.team.type_of_sport,
                    height = a.height
                }).SingleOrDefaultAsync(a => a.student_number == id);
            if (athlete == null)
            {
                return NotFound();
            }

            return Ok(athlete);
        }

        // PUT: api/Athletes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAthlete(string id, Athlete athlete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != athlete.student_number)
            {
                return BadRequest();
            }

            db.Entry(athlete).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AthleteExists(id))
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

        // POST: api/Athletes
        [ResponseType(typeof(Athlete))]
        public async Task<IHttpActionResult> PostAthlete(Athlete athlete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Athletes.Add(athlete);

            try
            {
                await db.SaveChangesAsync();
                // New code:
                // Load team name
                db.Entry(athlete).Reference(x => x.team).Load();

                var dto = new AthleteDTO()
                {
                    student_number = athlete.student_number,
                    student_firstname = athlete.student_firstname,
                    student_lastname = athlete.student_lastname
                };

            }
            catch (DbUpdateException)
            {
                if (AthleteExists(athlete.student_number))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = athlete.student_number }, athlete);
        }

        // DELETE: api/Athletes/5
        [ResponseType(typeof(Athlete))]
        public async Task<IHttpActionResult> DeleteAthlete(string id)
        {
            Athlete athlete = await db.Athletes.FindAsync(id);
            if (athlete == null)
            {
                return NotFound();
            }

            db.Athletes.Remove(athlete);
            await db.SaveChangesAsync();

            return Ok(athlete);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AthleteExists(string id)
        {
            return db.Athletes.Count(e => e.student_number == id) > 0;
        }
    }
}