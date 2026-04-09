namespace _17._01___Pi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Begin Main");
            AsynchronerTest();
            Console.WriteLine("5. Ende Main");
            Console.ReadKey();
        }

        static async void AsynchronerTest()
        {
            Console.WriteLine("\t2. Methode wurde aufgerufen");
            Console.WriteLine("\t3. Starte AufgabenMethode");
            await Task.Run(() => AufgabenMethode());
            Console.WriteLine("\t7. Methode ist fertig");
        }
        static void AufgabenMethode()
        {
            Console.WriteLine("\t\t4. Aufgabe läuft");
            Task.Delay(1000);
            Console.WriteLine("\t\t6. Aufgabe ist fertig");
        }
    }
}
