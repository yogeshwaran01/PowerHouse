using Microsoft.Extensions.Configuration.UserSecrets;
using PowerHouse.Enum;

namespace PowerHouse.Models
{
    public class Activity
    {
        public Activity()
        {
            Name = string.Empty;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ImpactValue { get; set; }
        public ActivityCategory Category { get; set;} 

        public int UserId { get; set; }

    }
}