using Blog.Data;
using Blog.Entities;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    // Multiple databases
    // We just need to know in which database we'll connect
    // the connection string can be stored in a "central database", but be aware to encrypt it well
    // Or it can be stored in the Connection String section in Azure (or other cloud provider), so it will be automatically changed when deployed
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly AppDataContext _context;

        public LoginController(AppDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {            
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (user is null) return NotFound();

            if (!PasswordHasher.Verify(user.PasswordHash, model.PasswordHash))
                return BadRequest(new { Message = "User or password invalid" });
                        
            var token = TokenService.GenerateToken(user);
            return new
            {
                user = user.Email,
                token
            };            
        }
    }
}
