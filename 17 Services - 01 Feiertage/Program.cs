using System.Net.Http.Headers;
using System.Text.Json;

namespace _18._01___Feiertage
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string service = "https://get.api-feiertage.de";

            List<Tuple<int, String, String>> bundesländer = new List<Tuple<int, String, String>>();
            bundesländer.Add(new Tuple<int, String, String>(1, "BW", "Baden-Württemberg"));
            bundesländer.Add(new Tuple<int, String, String>(2, "BY", "Bayern"));
            bundesländer.Add(new Tuple<int, String, String>(3, "BE", "Berlin"));
            bundesländer.Add(new Tuple<int, String, String>(4, "BB", "Brandenburg"));
            bundesländer.Add(new Tuple<int, String, String>(5, "HB", "Bremen"));
            bundesländer.Add(new Tuple<int, String, String>(6, "HH", "Hamburg"));
            bundesländer.Add(new Tuple<int, String, String>(7, "HE", "Hessen"));
            bundesländer.Add(new Tuple<int, String, String>(8, "MV", "Mecklenburg-Vorpommern"));
            bundesländer.Add(new Tuple<int, String, String>(9, "NI", "Niedersachsen"));
            bundesländer.Add(new Tuple<int, String, String>(10, "NW", "Nordrhein-Westfalen"));
            bundesländer.Add(new Tuple<int, String, String>(11, "RP", "Rheinland-Pfalz"));
            bundesländer.Add(new Tuple<int, String, String>(12, "SL", "Saarland"));
            bundesländer.Add(new Tuple<int, String, String>(13, "SN", "Sachsen"));
            bundesländer.Add(new Tuple<int, String, String>(14, "ST", "Sachsen-Anhalt"));
            bundesländer.Add(new Tuple<int, String, String>(15, "SH", "Schleswig-Holstein"));
            bundesländer.Add(new Tuple<int, String, String>(16, "TH", "Thüringen"));

            Console.Write("Jahr: ");
            if (!int.TryParse(Console.ReadLine(), out int jahr)) return;

            foreach (Tuple<int, String, String> t in bundesländer)
            {
                Console.WriteLine(t);
            }
            Console.Write("Auswahl: ");
            if (!int.TryParse(Console.ReadLine(), out int auswahl)) return;
            
            using HttpClient client = new();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Mein C# Programm");
            string message = await client.GetStringAsync($"{service}?years={jahr}&states={bundesländer[auswahl - 1].Item2.ToLower()}");

            ApiResponse response = JsonSerializer.Deserialize<ApiResponse>(message);

            if (response.status == "success")
            {
                Console.WriteLine($"Feiertage aus {bundesländer[auswahl - 1].Item3} im Jahr {jahr}");
                foreach (Feiertag f in response.feiertage)
                {
                    Console.WriteLine($"{f.Date.ToShortDateString()}  {f.Name}");
                }
            }
            else Console.WriteLine(response.error_description);

        }

    }
}
