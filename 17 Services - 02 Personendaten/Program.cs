using System.Net.Http.Headers;
using System.Text.Json;

namespace _18._02___Personendaten
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            String genderService = "https://api.genderize.io";
            String ageService = "https://api.agify.io";
            String nationalityService = "https://api.nationalize.io";

            Console.Write("Geben Sie einen Namen ein: ");
            String name = Console.ReadLine();

            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mein C# Programm");
            string genderMessage = await client.GetStringAsync($"{genderService}?name={name}");
            string ageMessage = await client.GetStringAsync($"{ageService}?name={name}");
            string nationalityMessage = await client.GetStringAsync($"{nationalityService}?name={name}");

            Entity entG = JsonSerializer.Deserialize<Entity>(genderMessage);
            Entity entA = JsonSerializer.Deserialize<Entity>(ageMessage);
            Entity entN = JsonSerializer.Deserialize<Entity>(nationalityMessage);

            Entity ent = new Entity() { Name=entG.Name, Age = entA.Age, Gender = entG.Gender, Countries = entN.Countries };

            Console.WriteLine(ent);

        }

    }
}
