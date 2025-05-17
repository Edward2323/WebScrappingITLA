using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebScrappingITLA.Services
{
    public class CredentialManager
    {
        private const string FilePath = "credentials.json";

        public static (string Username, string Password) LoadCredentials()
        {
            var exeDir = AppContext.BaseDirectory;
            var jsonPath = Path.Combine(exeDir, "credentials.json");

            var json = File.ReadAllText(jsonPath);
            var data = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            return (data["username"], data["password"]);
        }

        public static void SaveCredentials(string username, string password)
        {
            var data = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(FilePath, json);
        }
    }
}
