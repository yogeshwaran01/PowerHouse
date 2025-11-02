
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerHouse.Context;
using PowerHouse.Models;

namespace PowerHouse.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController(PowerHouseDbContext context) : ControllerBase
    {
        private readonly PowerHouseDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("User", new { id= user.Id }, user);
        }
    }
}