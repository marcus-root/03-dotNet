namespace dotNet_06_Delegates_02_Array_Min_max
{
    delegate bool VergleichsHandler(int x, int y);
    internal class Program
    {
        static void Main(string[] args)
        {
            int minIndex = default;
            int maxIndex = default;

            // Array mit Zufallszahlen füllen
            int[] randomArray = new int[10];
            randomArray = FillRandomArray(randomArray);

            // Minimum und Maximum Index ermitteln mit Delegates
            // Aufruf der Methode GetLimit, der ein Delegate und das Array übergeben wird
            try
            {
                minIndex = MinMax.GetLimit(MinMax.IstKleiner, randomArray);
                maxIndex = MinMax.GetLimit(MinMax.IstGrösser, randomArray);
                // MinMax.GetLimit(MinMax.IstFalscheMethode, randomArray);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            // Konsolenausgabe
            ArrayAusgeben(randomArray);
            MinMaxAusgeben(minIndex, maxIndex);
        }

        static int[] FillRandomArray(int[] a)
        {
            // Zufallsgenerator anlegen
            Random rand = new Random();
            // Array füllen
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(1, 10001);
            }
            // Array zurückgeben
            return a;
        }

        static void ArrayAusgeben(int[] array)
        {
            Console.Write("Inhalt des Random Arrays: ");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1) Console.WriteLine($"{array[i],5}");
                else Console.Write($"{array[i],5}, ");
            }
        }

        static void MinMaxAusgeben(int minIndex, int maxIndex)
        {
            Console.SetCursorPosition(7 * minIndex + 26, Console.CursorTop);
            Console.Write("  min");
            Console.SetCursorPosition(7 * maxIndex + 26, Console.CursorTop);
            Console.Write("  max");
            Console.SetCursorPosition(0, 5);
        }
    }
}
