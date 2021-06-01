using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var password = "Emran@12345";
            
            for (int i = 0; i < password.Length; i++)
            {
                char a = password[i];
            }
            var md5Hash = CryptographyService.HashPasswordUsingMD5(password);

            var pbkdf2Hash = CryptographyService.HashPasswordUsingPBKDF2(password);

            return new string[] { "MD5 Hash: " + md5Hash, "PBKDF2 Hash: " + pbkdf2Hash };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
