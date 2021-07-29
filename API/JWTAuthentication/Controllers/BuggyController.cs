using JWTAuthentication.Models;
using JWTAuthentication.Persistance.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JWTAuthentication.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DBContext _context;

        public BuggyController(DBContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.AppUsers.Find(-1);

            if (thing == null) return NotFound();

            return Ok(thing);
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            try
            {
                var thing = _context.AppUsers.Find(-1);

                var thingToReturn = thing.ToString();

                return Ok(thingToReturn);
            }
            catch (System.Exception)
            {

                return StatusCode(500, "Computer say no!");
            }
            
        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}
