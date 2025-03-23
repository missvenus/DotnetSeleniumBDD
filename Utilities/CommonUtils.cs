using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace SeleniumBDDAuto.Utilities;

public static class CommonUtils
{
    public static Dictionary<string, string> GetSignCredentials(string scenarioName="loginTest")
    {
        Dictionary<string, string> creds = new Dictionary<string, string>();
        string? path = GetCurrentDirectory();
        var jsonObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(path! + "/Fixtures/users.json"),
            new JsonSerializerSettings());
        creds.Add("email",jsonObject![scenarioName]!["email"]!.ToString());
        creds.Add("password",jsonObject![scenarioName]!["password"]!.ToString());

        return creds;
    }
    
    public static string GetCurrentDirectory()

    {
        var env = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(env)?.Parent?.Parent?.ToString();
        Console.WriteLine(projectDirectory);

        return projectDirectory;
    }
}