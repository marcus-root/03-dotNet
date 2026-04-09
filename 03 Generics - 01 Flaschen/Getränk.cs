namespace dotNet_03_Generics_01_Flaschen
{
    internal abstract class Getränk
    {
        protected string name;

        public Getränk(string name)
        {
            this.name = name;
        }

        public abstract override String ToString();
    }
}
