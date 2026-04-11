namespace dotNet_03_Generics_02_Liste_und_Menge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleList<IComparable> liste = new SimpleList<IComparable>();

            liste.AddItem(10);
            liste.AddItem("Hallo");
            liste.AddItem('Ä');
            liste.AddItem(100.00);

            Console.WriteLine($"{liste}\n");


            Set<String> set1 = new Set<String>();
            Set<String> set2 = new Set<String>();

            set1.AddItem("Ich bin nur in Set 1");
            set1.AddItem("Ich bin in beiden Sets");
            Console.WriteLine($"{set1}\n");

            set2.AddItem("Ich bin nur in Set 2");
            set2.AddItem("Ich bin in beiden Sets");
            Console.WriteLine($"{set2}\n");

            Console.WriteLine($"Set 1 und Set 2 vereinigt:\n{set1.Join(set2)}\n");
            Console.WriteLine($"Schnittmenge Set 1 und Set 2:\n{set1.Schnittmenge(set2)}\n");
        }
    }
}
