using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerHouse.Context;
using PowerHouse.DTOs;
using PowerHouse.Models;

namespace PowerHouse.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(PowerHouseDbContext context) : ControllerBase
    {
        private readonly PowerHouseDbContext _context = context;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Email already registered.");

            User user = new()
            {
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Name = dto.Name
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user.Id);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials.");

            return Ok(new { message = "Login success", userId = user.Id });
        }

    }
}