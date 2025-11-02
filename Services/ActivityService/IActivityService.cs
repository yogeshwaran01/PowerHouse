using PowerHouse.DTOs;
using PowerHouse.Models;

namespace PowerHouse.Services
{
    public interface IActivityService
    {
        Task<Activity> GetActivityAsync(ActivityLogDto logDto);
        
    }
}

