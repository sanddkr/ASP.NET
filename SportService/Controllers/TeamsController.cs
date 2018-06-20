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
    public class TeamsController : ApiController
    {
        private SportServiceContext db = new SportServiceContext();

        // GET: api/Teams
        //public IQueryable<Team> GetTeams()
        //{
        //    return db.Teams;
        //}
        public IQueryable<TeamDTO> GetTeams()
        {
            var teams = from t in db.Teams
                           select new TeamDTO()
                           {
                               type_of_sport = t.type_of_sport,
                               coach_name = t.coach_name,
                               season = t.season,
                               fee = t.fee
                           };

            return teams;
        }

        // GET: api/Teams/5
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> GetTeam(string id)
        {
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        //// GET: api/Teams/5
        //public IQueryable<AthleteDetailDTO> GetAthletes(string id)
        //{
        //    var athletes = from a in db.Athletes
        //                   where a.type_of_sport.Equals( id)
        //                   select new AthleteDetailDTO()
        //                   {
        //                       student_number = a.student_number,
        //                       student_name = a.student_firstname + " " + a.student_lastname,
        //                       height = a.height,
        //                       type_of_sport = a.type_of_sport
        //                   };

        //    return athletes;
        //}

        // PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTeam(string id, Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.type_of_sport)
            {
                return BadRequest();
            }

            db.Entry(team).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
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

        // POST: api/Teams
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> PostTeam(Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Teams.Add(team);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeamExists(team.type_of_sport))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = team.type_of_sport }, team);
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(Team))]
        public async Task<IHttpActionResult> DeleteTeam(string id)
        {
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            await db.SaveChangesAsync();

            return Ok(team);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamExists(string id)
        {
            return db.Teams.Count(e => e.type_of_sport == id) > 0;
        }
    }
}