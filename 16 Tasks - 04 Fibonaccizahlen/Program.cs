namespace dotNet_16_Tasks_04_Fibonaccizahlen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 30;
            int anzahl = 15;
            List<Task<long>> list = new List<Task<long>>();
            CancellationTokenSource cts = new CancellationTokenSource();
            Console.Write("Bitte Warten");
            Task punkteAusgabe = Task.Factory.StartNew(() => { while (true) { Console.Write("."); Task.Delay(500).Wait(); } }, cts.Token);
            for (int i = start; i < anzahl + start; i++)
            {
                int temp = i;
                list.Add(Task<long>.Factory.StartNew(() => Fib(temp)));
            }

            Task.WaitAll(list.ToArray());

            cts.Cancel();

            Console.WriteLine("\n\n");
            Console.WriteLine($"Die {anzahl} Fibonacci-Zahlen ab der {start}. Zahl:\n");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + start}: {list[i].Result,12:N0}");
            }


        }

        static long Fib(int x)
        {
            return x <= 2 ? 1 : Fib(x - 1) + Fib(x - 2);
        }
    }
}
