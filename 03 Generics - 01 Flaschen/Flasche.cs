namespace dotNet_03_Generics_01_Flaschen
{
    internal class Flasche<T> where T : Getränk
    {
        T inhalt;

        public bool IstLeer()
        {
            return object.Equals(inhalt, default(T));
        }

        public void Füllen(T getränk)
        {
            if (IstLeer())
            {
                this.inhalt = getränk;
                Console.WriteLine("Die Flasche wird gefüllt.");
            }
            else Console.WriteLine("Die Flasche ist schon voll.");
        }

        public T Leeren()
        {
            if (!IstLeer())
            {
                T rück = inhalt;
                inhalt = default;
                Console.WriteLine("Die Flasche wird geleert.");
                return rück;
            }
            else { Console.WriteLine("Die Flasche ist schon leer."); return default(T); }
        }

        public override string ToString()
        {
            if (this.IstLeer()) return "Die Flasche ist leer.";
            else return $"Die Flasche ist gefüllt mit {inhalt.GetType().Name}: {inhalt.ToString()}";
        }
    }
}


