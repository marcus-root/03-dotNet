namespace dotNet_06_Delegates_03_Logger
{
    delegate void LogHandler(String text);
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.SetPath(@"..\..\..\log.txt"); // Den Pfad setzen

            LogHandler logmethode = Logger.ToFile; // speichern der ToFile-Methode in einem Delegate
            logmethode += Program.ToConsoleUpper; // delegate eine Methode der Klasse Program hinzufügen
            logmethode += delegate (String text) // delegate eine anonyme Methode hinzufügen
            {
                Console.WriteLine(text.ToUpper());
            };

            try
            {
                Logger.Log(logmethode, "Hallo Welt"); // Loggen
                Logger.Log(logmethode, "Die Sonne scheint");
                Logger.Log(logmethode, "Das ist schön");
                Logger.Log(logmethode, "Ich habe hunger");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }

        static void ToConsoleUpper(String text)
        {
            Console.WriteLine(text);
        }
    }
}
