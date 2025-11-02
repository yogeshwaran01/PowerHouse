
using Mscc.GenerativeAI;
using PowerHouse.DTOs;
using PowerHouse.Enum;
using PowerHouse.Models;
using PowerHouse.Prompts;
using System.Text.Json;

namespace PowerHouse.Services
{
    public class GeminiActivityService : IActivityService
    {
        private readonly GoogleAI _geminiClient;

        public GeminiActivityService(IConfiguration configuration)
        {
            _geminiClient = new GoogleAI(configuration["Gemini:ApiKey"]);
        }

        public async Task<Activity> GetActivityAsync(ActivityLogDto logDto)
        {
            string prompt = string.Format(PowerHousePrompts.ACTIVITY_PROMPT, logDto.ActivityName, logDto.ActivityDescription);

            var model = _geminiClient.GenerativeModel(model: Model.GeminiPro);
            var response = await model.GenerateContent(prompt);

            var content = response?.Text;
            content = content?.Replace("```", string.Empty);
            content = content?.Replace("json", string.Empty);

            if (string.IsNullOrEmpty(content))
            {
                return new Activity();
            }

            var json = JsonDocument.Parse(content);
            int category = json.RootElement.GetProperty("category").GetInt32();
            int impactValue = json.RootElement.GetProperty("impactValue").GetInt32();

            Activity activity = new Activity
            {
                ImpactValue = impactValue,
                Category = (ActivityCategory)category,
                Name = logDto.ActivityName
            };

            return activity;
        }
    }
}
