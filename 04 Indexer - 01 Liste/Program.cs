namespace dotNet_04_Indexer_01_Liste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleList<String> liste = new SimpleList<String>();

            liste.Add("Hallo");
            liste.Add("Welt");

            Console.WriteLine($"Listen-Eintrag mit Index 0: {liste[0]}");
            Console.WriteLine($"Listen-Eintrag mit Index 1: {liste[1]}");

            Console.WriteLine();
            Console.WriteLine($"Ändere Listeneintrag mit Index 1 zu \"Erde\"");
            liste[1] = "Erde";

            Console.WriteLine();
            for (int i = 0; i < liste.Length(); i++)
            {
                Console.WriteLine($"Listen-Eintrag mit Index {i}: {liste[i]}");
            }

            Console.WriteLine();
            Console.WriteLine($"Anlegen eines Arrays aus der Liste und Ausgabe der Elemente:");
            String[] array = liste.ToArray();
            foreach (String item in array)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine($"Löschen des Eintrags \"Hallo\" in der Liste");
            liste.Delete("Hallo");
            Console.WriteLine($"Listen-Eintrag mit Index 0: {liste[0]}");

            Console.WriteLine() ;
            Console.WriteLine("Suche nach \"Erde\" in der Liste:");
            if (liste.Search("Erde") != null) Console.WriteLine("Erde vorhanden.");



        }
    }
}
