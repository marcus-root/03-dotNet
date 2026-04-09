namespace dotNet_01_01_Person_Datum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- Anlegen von Personen --");

            String eName = "Max";
            int eAlter = 30;
            Console.WriteLine($"Versuche Person anzulegen | Name: {eName} | Alter: {eAlter}");
            Person erlaubt = new Person();
            try
            {
                erlaubt.Name = eName;
                erlaubt.Alter = eAlter;
                Console.WriteLine($"Person angelegt | Name: {erlaubt.Name} | Alter:{erlaubt.Alter}");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            String vName = "Erika";
            int vAlter = -1;
            Console.WriteLine($"Versuche Person anzulegen | Name: {vName} | Alter: {vAlter}");
            Person verboten = new Person();
            try
            {
                verboten.Name = vName;
                verboten.Alter = vAlter;
                Console.WriteLine($"Person angelegt | Name: {verboten.Name} | Alter:{verboten.Alter}");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }


            Console.WriteLine("\n\n-- Anlegen eines Datums --");

            SimpleDate datum = new SimpleDate();
            Console.WriteLine("Zuweisung eines ungültigen Datums:");
            try
            {
                try { datum.Year = 2027; }
                catch (Exception e) { Console.WriteLine(e.Message); throw; }
                try { datum.Month = 2; }
                catch (Exception e) { Console.WriteLine(e.Message); throw; }
                try { datum.Day = 29; }
                catch (Exception e) { Console.WriteLine(e.Message); throw; }
                Console.WriteLine(datum);
            }
            catch (Exception e) { Console.WriteLine("Datum Fehlerhaft, Zuweisung abgebrochen"); }

            Console.WriteLine("Zuweisung eines gültigen Datums:");
            try
            {
                datum.Year = 2028; //2028 ist ein Schaltjahr
                datum.Month = 02;
                datum.Day = 29;
                Console.WriteLine($"Das Datum:{datum}");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
