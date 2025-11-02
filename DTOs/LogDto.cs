namespace PowerHouse.DTOs
{
    public class ActivityLogDto
    {
        public ActivityLogDto()
        {
            ActivityName = string.Empty;
            ActivityDescription = string.Empty;
        }
        public string ActivityName { get; set;}
        public string ActivityDescription { get; set;}

    }
}
