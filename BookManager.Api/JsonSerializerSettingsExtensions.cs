using Newtonsoft.Json.Converters;

namespace BookManager.Api
{
    public static class JsonSerializerSettingsExtensions
    {
        public static void AddCustomJsonSerializerSettings(this Newtonsoft.Json.JsonSerializerSettings settings)
        {
            settings.Converters.Add(new StringEnumConverter());
        }
    }
}
