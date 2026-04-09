namespace _16._02___Kreiszahl_Pi___Git
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTasks = 4;
            List<Task<double>> tasks = new List<Task<double>>();

            for (int i = 1; i <= numberOfTasks; i++)
            {
                tasks.Add(Task<double>.Factory.StartNew(() => PI_Berechnung(i, numberOfTasks)));
            }

            Task.WaitAll(tasks.ToArray());

            double result = 0;
            foreach (Task<double> task in tasks)
            {
                result+=task.Result;
            }
            Console.WriteLine($"Math.PI: {Math.PI}");
            Console.WriteLine($"Approx : {result}");

        }

        // https://github.com/inkoe/pi_berechnung/blob/main/Pi_Berechnung/Pi_Berechnung/Program.cs
        private static double PI_Berechnung(int startwert, int schrittweite)
        {
            const double durchlaeufe = 1_000_000_000;
            double x, y = 1.0 / durchlaeufe;
            double summe = 0;
            double pi;

            for (double i = startwert; i <= durchlaeufe; i += schrittweite)
            {
                x = y * (i - 0.5);
                summe += 4.0 / (1 + x * x);
            }

            pi = y * summe;

            return pi;
        }
    }
}
