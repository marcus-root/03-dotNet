using System.Text.RegularExpressions;

namespace dotNet_02_Regex_01_Froschkönig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"..\..\..\Froschkönig Unix Zeilenumbrüche.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            String? zeile;
            int zeilen = 0;

            List<String> regex = new List<String>();
            regex.Add(@"\b[äöüÄÖÜ]\b");
            regex.Add(@"\b[Dd]er\b");
            regex.Add(@"^[A-ZÜÖÜ]");
            regex.Add(@"(Frosch)|(Froschkönig)");
            regex.Add(@"\.$");
            regex.Add(@"ß\b");
            regex.Add(@"^$");
            regex.Add(@"^\w{3}\W.*$");
            regex.Add(@"\b[Dd](er|ie|as)\b");

            List<String> beschreibung = new List<String>();
            beschreibung.Add("Alle Zeilen mit einem Umlaut (große und kleine Umlaute)");
            beschreibung.Add("Alle Zeilen in denen das Wort „der“ alleine steht");
            beschreibung.Add("Alle Zeilen die mit einem großen Buchstaben beginnen");
            beschreibung.Add("Alle Zeilen, in denen das Wort Frosch oder Froschkönig vorkommt");
            beschreibung.Add("Alle Zeilen mit einem . (Punkt) am Ende der Zeile");
            beschreibung.Add("Alle Zeilen in den ein Wort mit ß am Ende des Wortes steht");
            beschreibung.Add("Die Anzahl der leeren Zeilen im Dokument");
            beschreibung.Add("Alle Zeilen bei denen am Anfang der Zeile ein Wort mit genau 3 Buchstaben steht");
            beschreibung.Add("Alle Zeilen die einen bestimmten Artikel enthalten");

            for (int i = 0; i < regex.Count; i++)
            {
                fs.Seek(0, 0); // Anfang der Datei
                while (!sr.EndOfStream)
                {
                    zeile = sr.ReadLine();
                    if (Regex.IsMatch(zeile, regex[i])) { zeilen++; }
                }
                Console.WriteLine($"{beschreibung[i]}: {zeilen}\n");
                fs.Seek(0, 0);
                while (!sr.EndOfStream)
                {
                    zeile = sr.ReadLine();
                    if (Regex.IsMatch(zeile, regex[i])) { Console.WriteLine(zeile); }
                }
                zeilen = 0;
                Console.WriteLine("\nTaste drücken...");
                Console.ReadKey();
                Console.Clear();
            }

            fs.Close();
            sr.Close();
        }
    }
}
