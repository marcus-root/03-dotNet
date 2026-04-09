namespace dotNet_01_02_Bahnhöfe_und_Züge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RailwayStation r1 = new RailwayStation("Bochum Hbf", 20);
            Console.WriteLine($"{r1}");
            Console.WriteLine();

            Random rand = new Random();

            List<Train> trains = new List<Train>();
            trains.Add(new Train("RE11", 6));
            trains.Add(new Train("RE6", 8));
            trains.Add(new Train("ICE1510", 7));
            trains.Add(new Train("Hogwarts Express", 2));
            trains.Add(new Train("Polarexpress", 3));
            trains.Add(new Train("Bummelzug", 1));


            for (int i = 0; i < 20; i++)
            {
                Train zug = trains[rand.Next(0, trains.Count)];
                try { r1.AddTrain(zug); }
                catch (RailwayStationException e) { Console.WriteLine($"Bahnhof voll, der Zug {zug.Zugnummer} ({zug.Wagons} Wagons) fährt weiter.\n"); r1.Ausfahren(); }
            }
            Console.WriteLine();

            Console.WriteLine(r1);
        }
    }
}
