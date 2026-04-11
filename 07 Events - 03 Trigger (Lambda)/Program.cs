using System.Diagnostics.Metrics;

namespace dotNet_07_Events_03_Trigger_Lambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // für die Bedingung als auch für die Aktionen jeweils Lambda-Ausdrücke
            // mit Verwendung der generischen Delegaten Func und Action
            Action aktion = () => Console.WriteLine(" | Bedingung erreicht");
            Func<int, bool> bedingung = x => x > 150;

            // Erstellen eine Counter-Objekts mit Übergabe der Bedingungs- und Aktions-Delegaten
            Counter meinCounter = new Counter(bedingung, aktion);

            // Anmelden der Methode Print an das Event Zählerstandsänderung der Klasse Counter
            meinCounter.Zählerstandsänderung += Program.Print;

            // Den Zählerstand um zufallsgenerierte Zahlen erhöhen
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                meinCounter.ZählerstandErhöhen(rand.Next(10, 51));
                Thread.Sleep(200);
            }
            meinCounter.Clear();
        }

        static void Print(object sender, CounterEventArgs e)
        {
            Console.Write($"{e}");
        }


    }
}
