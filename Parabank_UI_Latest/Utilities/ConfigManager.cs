using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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


        public static string Browser => config["Browser"];
        public static string BaseUrl => config["Application:BaseUrl"];
        public static string Username => config["Credentials:Username"];
        public static string Password => config["Credentials:Password"];
        public static int ExplicitWait => int.Parse(config["Timeouts:ExplicitWait"]);


        public static void UpdateCredentials(string username, string password)
        {
            string basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string path = Path.Combine(basePath, "appSettings.json");
            var json = File.ReadAllText(path);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            jsonObj["Credentials"]["Username"] = username;
            jsonObj["Credentials"]["Password"] = password;
            File.WriteAllText(path, JsonConvert.SerializeObject(jsonObj, Formatting.Indented));
        }
    }
}
    