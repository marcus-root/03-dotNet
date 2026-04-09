namespace dotNet_03_Generics_01_Flaschen
{
    internal class Rotwein : Getränk
    {
        public String Herkunft { get; private set; }

        public Rotwein(String name, String herkunft) : base(name)
        {
            this.Herkunft = herkunft;
        }

        public override string ToString()
        {
            return $"{this.name} aus {this.Herkunft}.";
        }
    }
}
