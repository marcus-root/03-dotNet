namespace dotNet_07_Events_02_Beobachter_am_Fluss
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fluss rhein = new Fluss("Rhein");
            Fluss donau = new Fluss("Donau");

            Stadt köln = new Stadt("Köln");
            Stadt düsseldorf = new Stadt("Düsseldorf");
            Stadt ulm = new Stadt("Ulm");

            Schiff rheingold = new Schiff("Rheingold");
            Schiff lorelei = new Schiff("Lorelei");
            Schiff xaver = new Schiff("Xaver");
            Schiff franz = new Schiff("Franz");

            Klärwerk strauß1 = new Klärwerk("Strauß 1");

            rhein.Pegeländerung += köln.Reaktion;
            rhein.Pegeländerung += düsseldorf.Reaktion;
            rhein.Pegeländerung += rheingold.Reaktion;
            rhein.Pegeländerung += lorelei.Reaktion;

            donau.Pegeländerung += ulm.Reaktion;
            donau.Pegeländerung += xaver.Reaktion;
            donau.Pegeländerung += franz.Reaktion;
            donau.Pegeländerung += strauß1.Reaktion;


            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                rhein.Wasserstand = rand.Next(100, 10001);
                Thread.Sleep(rand.Next(100, 5000));
                donau.Wasserstand = rand.Next(100, 10001);
                Thread.Sleep(rand.Next(100, 5000));
            }

        }
    }
}
