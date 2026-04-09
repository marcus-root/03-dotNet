namespace dotNet_01_02_Bahnhöfe_und_Züge
{
    internal class Train
    {
        public String Zugnummer { get; }
        public int Wagons { get; }

        public Train(string zugnummer, int wagons)
        {
            Zugnummer = zugnummer;
            Wagons = wagons;
        }

        public override string ToString()
        {
            String wagon = "[   ]";
            String wagons = "";
            for (int i = 0; i < Wagons; i++)
            {
                wagons += wagon + " - ";
            }
            return $"{wagons}";
        }
    }
}
