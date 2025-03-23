using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace SeleniumBDDAuto.Utilities;

public static class CommonUtils
{
    public static Dictionary<string, string> GetSignCredentials(string scenarioName="loginTest")
    {
        Dictionary<string, string> creds = new Dictionary<string, string>();
        string email = Environment.GetEnvironmentVariable("AMAZON_EMAIL") ?? throw new ArgumentNullException("AMAZON_EMAIL not found");;
        string password = Environment.GetEnvironmentVariable("AMAZON_PASSWORD") ?? throw new ArgumentNullException("AMAZON_PASSWORD not found");;
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            throw new Exception("Missing credentials in GitHub Secrets.");
        }

        creds.Add("email",email);
        creds.Add("password",password);
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