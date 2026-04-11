namespace dotNet_09_Serialisierung_03_FizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String jsonFilename;
            List<Word> wörter;

            // Festlegen des json-Dateinamens
            jsonFilename = @"..\..\..\FizzBuzz.json";

            try
            {
                wörter = FizzBuzz.ReadJson(jsonFilename); // Auslesen der json-Datei
                Console.WriteLine();
                FizzBuzz.PrintWordInfo(wörter); // Informationen über die Wortliste ausgeben
                Console.WriteLine();
                FizzBuzz.Print(wörter, 100); // Ausgabe der Zahlen und der Wörter
            }
            catch (Exception e) { Console.WriteLine($"Fehler: {e.Message}"); }
        }
    }
}