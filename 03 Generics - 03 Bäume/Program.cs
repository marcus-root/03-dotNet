namespace dotNet_03_Generics_03_Bäume
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBinaryTree<int> binärerBaum = new BinaryTree<int>();

            binärerBaum.Insert(50);
            binärerBaum.Insert(100);
            binärerBaum.Insert(25);
            binärerBaum.Insert(1);
            binärerBaum.Insert(10);
            binärerBaum.Insert(75);
            binärerBaum.Insert(65);
            binärerBaum.Insert(85);
            binärerBaum.Insert(61);
            binärerBaum.Insert(45);
            binärerBaum.Insert(35);
            binärerBaum.Insert(15);
            binärerBaum.Insert(10);
            Console.WriteLine("\nAlle Nodes:");
            binärerBaum.PrintInorder();
            Console.WriteLine("\nLösche die 100");
            binärerBaum.Delete(100);
            binärerBaum.PrintInorder();
            Console.WriteLine("\nLösche die 50");
            binärerBaum.Delete(50);
            binärerBaum.PrintInorder();
            Console.WriteLine("\nLösche die 85");
            binärerBaum.Delete(85);
            binärerBaum.PrintInorder();
            Console.WriteLine($"\nEnthält 100? {binärerBaum.Contains(100)}");
            Console.WriteLine($"Enthält 75? {binärerBaum.Contains(75)}\n");
            Console.WriteLine("Lösche Baum");
            binärerBaum.Clear();
            Console.WriteLine("Alle Nodes:");
            binärerBaum.PrintInorder();

        }
    }
}
