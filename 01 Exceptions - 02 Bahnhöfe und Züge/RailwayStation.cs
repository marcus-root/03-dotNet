namespace dotNet_01_02_Bahnhöfe_und_Züge
{
    internal class RailwayStation
    {
        string _name;
        List<Train> _züge;
        int _maxWagons;
        int Wagons { get; set; }

        public RailwayStation(string name, int maxWagons)
        {
            _name = name;
            _züge = new List<Train>();
            _maxWagons = maxWagons;
            Wagons = 0;
        }

        public void AddTrain(Train zug)
        {

            if (zug.Wagons + GesamtWagons() <= _maxWagons)
            {
                _züge.Add(zug);
                Console.WriteLine($"{zug}\nDer Zug {zug.Zugnummer} fährt in den Bahnhof ein! {_züge.Count} Züge, {GesamtWagons()} Wagons im Bahnhof.\n");
            }
            else throw new RailwayStationException($"train {zug.Zugnummer} can't be added!");
        }

        public Train Ausfahren()
        {
            if (_züge.Count > 0)
            {
                Train rück = _züge.First();
                _züge.Remove(_züge.First());
                Console.WriteLine($"Der Zug {_züge.First().Zugnummer} fährt aus! {_züge.Count} Züge, {GesamtWagons()} Wagons im Bahnhof.\n");
                return rück;
            }
            else throw new RailwayStationException("no train in railwaystation");
        }

        public override string ToString()
        {
            return $"-- {_name} --\nZüge: {_züge.Count}\nWagons: {GesamtWagons()} / {_maxWagons}";
        }

        private int GesamtWagons()
        {
            int wagons = 0;
            foreach (Train t in _züge)
            {
                wagons += t.Wagons;
            }
            return wagons;
        }
    }
}

