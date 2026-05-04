using Newtonsoft.Json;

namespace Parabank_UI_Latest.Utilities
{
    public static class TestDataReader
    {
        public static List<T> Read<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json)
                   ?? new List<T>();
        }

        public static void Write<T>(string filePath, List<T> data)
        {
            var json = JsonConvert.SerializeObject(
                data, Formatting.Indented);

            File.WriteAllText(filePath, json);
        }
    }
}