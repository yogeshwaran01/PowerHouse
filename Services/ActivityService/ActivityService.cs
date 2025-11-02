using PowerHouse.DTOs;
using PowerHouse.Models;

namespace PowerHouse.Services
{
    public class RandomActivityService : IActivityService
    {
        public Task<Activity> GetActivityAsync(ActivityLogDto logDto)
        {
            Activity activity = new Activity();
            activity.Category = Enum.ActivityCategory.POSITIVE;
            activity.ImpactValue = 20;
            return Task.FromResult(activity);
        }
    }
}