namespace PowerHouse.Prompts

{
    public class PowerHousePrompts
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly string ACTIVITY_PROMPT = @"
        You are a lifestyle energy coach. 
            Classify this user activity and assign an impact value from -100 to +100.
            
            Activity: {0}
            Description: {1}

            Respond in JSON format like:
            {{
                ""category"": 0-2,
                ""impactValue"": number between -100 and 100
            }}

            No need to give it as markdown just as json response
        ";
    }
}