namespace dotNet_03_Generics_01_Flaschen
{
    internal class Bier : Getränk
    {
        public String Brauerei { get; private set; }

        public Bier(String name, String brauerei) : base(name)
        {
            this.Brauerei = brauerei;
        }

        public override string ToString()
        {
            return $"{this.name} von der Brauerei {this.Brauerei}.";
        }
    }
}
