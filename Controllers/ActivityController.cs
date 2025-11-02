using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerHouse.Context;
using PowerHouse.DTOs;
using PowerHouse.Models;
using PowerHouse.Services;

namespace PowerHouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController(PowerHouseDbContext context, IActivityService activityService) : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> AddActivity(int userId, ActivityLogDto dto)
        {
            User? user = await context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User Not found");
            }
        
            Activity activity = await activityService.GetActivityAsync(dto);
            activity.UserId = user.Id;
            await context.Activities.AddAsync(activity);
            await context.SaveChangesAsync();
            return Ok(activity);

        }

        [HttpGet]
        public async Task<IActionResult> GetActivities(int userID)
        {
            var today = DateTime.UtcNow.Date;
            var logs = await context.Activities.Where(x => x.UserId == userID).ToListAsync();
            
            return Ok(logs);
        }

    }
}