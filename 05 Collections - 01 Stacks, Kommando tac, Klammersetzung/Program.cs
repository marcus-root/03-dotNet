namespace dotNet_05_Collections_01_Stacks_tac_Klammersetzung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Der Text Froschkönig wird als Stack angelegt und anschließend in umgekehrter Zeilenfolge ausgegeben:");
            Console.WriteLine("\nTaste drücken...");
            Console.ReadKey();
            Stack<IComparable> froschkönig = tac<IComparable>.Einlesen(@"..\..\..\Froschkönig Unix Zeilenumbrüche.txt");
            tac<IComparable>.Ausgeben(froschkönig);
            Console.WriteLine("\nTaste drücken...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Klammerprüfer:\n");
            Console.Write("Eingabe: ");
            if (klammerPrüfer<IComparable>.Prüfen(Console.ReadLine())) Console.WriteLine("klammern ok...");
            else Console.WriteLine("klammern nicht ok...\n\n\n");
        }
    }
}
