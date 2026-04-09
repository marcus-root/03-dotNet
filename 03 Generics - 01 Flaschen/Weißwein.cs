namespace dotNet_03_Generics_01_Flaschen
{
    internal class Weißwein : Getränk
    {
        public String Herkunft { get; private set; }

        public Weißwein(String name, String herkunft) : base(name)
        {
            this.Herkunft = herkunft;
        }

        public override string ToString()
        {
            return $"{this.name} aus {this.Herkunft}.";
        }
    }
}
