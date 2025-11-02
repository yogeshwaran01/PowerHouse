using OpenAI;
using OpenAI.Chat;
using PowerHouse.DTOs;
using PowerHouse.Enum;
using PowerHouse.Models;
using PowerHouse.Prompts;

namespace PowerHouse.Services
{
    public class AIActivityService : IActivityService

    {

        private readonly OpenAIClient aIClient;
        public AIActivityService(IConfiguration configuration)
        {
            aIClient = new OpenAIClient(configuration["OpenAI:ApiKey"]);

        }

        public async Task<Activity> GetActivityAsync(ActivityLogDto logDto)
        {
            string prompt = string.Format(PowerHousePrompts.ACTIVITY_PROMPT, logDto.ActivityName, logDto.ActivityDescription);

            var chat = aIClient.GetChatClient("o4-mini");
            ChatCompletion chatCompletion = await chat.CompleteChatAsync(prompt);


            var response = chatCompletion?.Content?.First()?.Text;
            if (response == null) { return new Activity(); }
            var json = System.Text.Json.JsonDocument.Parse(response);

            int category = json.RootElement.GetProperty("category").GetInt32();
            int impactValue = json.RootElement.GetProperty("impactValue").GetInt32();

            Activity activity = new Activity();
            activity.ImpactValue = impactValue;
            activity.Category = (ActivityCategory)category;
            activity.Name = logDto.ActivityName;
            return activity;






        }

    }
}