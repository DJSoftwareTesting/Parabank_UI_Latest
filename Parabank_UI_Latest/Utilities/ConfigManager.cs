using Microsoft.Extensions.Configuration;

namespace Parabank_UI.Utilities
{
    public class ConfigManager
    {
        private static IConfiguration config;
        public static bool IsHeadless = false;

        static ConfigManager()
        {
            string basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string path = Path.Combine(basePath, "appSettings.json");
            config = new ConfigurationBuilder().AddJsonFile(path, optional: false, reloadOnChange: true).Build();
        }

        public static string Get(string key)
        {
            return config[key];
        }
    }
}
    