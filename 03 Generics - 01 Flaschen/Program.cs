namespace dotNet_03_Generics_01_Flaschen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- Flasche 1 --");
            Flasche<Getränk> flasche1 = new Flasche<Getränk>();
            Console.WriteLine(flasche1);
            Console.WriteLine();

            flasche1.Füllen(new Bier("Radler", "Moritz Fiege Brauerei"));
            Console.WriteLine();
            Console.WriteLine(flasche1);
            Console.WriteLine();

            flasche1.Leeren();
            Console.WriteLine();
            Console.WriteLine(flasche1);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("-- Flasche 2 --");
            Flasche<Getränk> flasche2 = new Flasche<Getränk>();
            Console.WriteLine(flasche2);
            Console.WriteLine();

            flasche2.Füllen(new Rotwein("Burgunder", "Frankreich"));
            Console.WriteLine();
            Console.WriteLine(flasche2);
            Console.WriteLine();

            flasche2.Leeren();
            Console.WriteLine();
            Console.WriteLine(flasche2);


            //Flasche<Badreiniger> flasche3 = new Flasche<Badreiniger>();
        }
    }
}
