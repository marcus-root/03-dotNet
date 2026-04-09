namespace _16._01___Grundlagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String pfad = @"F:\Texte";
            List<Task<Text>> tasks = new List<Task<Text>>();

            foreach (String f in Directory.GetFiles(pfad,"*.txt"))
            {
                Task<Text> task = Task<Text>.Factory.StartNew(TaskMethode, f); // Task sofort starten, mit Übergabeparameter und Rückgabewert
                Task<Text> taskLambda = Task<Text>.Factory.StartNew(parameter => { return new Text(parameter.ToString()); }, f); // Mit Lambda und anonymer Methode
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            foreach (Task<Text> t in tasks)
            {
                Console.WriteLine(t.Result.GetInformation());
                Console.WriteLine();
            }

            foreach (Task<Text> t in tasks)
            {
                File.WriteAllText(Path.ChangeExtension(t.Result.Dateipfad, "freq"), t.Result.GetInformation());
            }
        }

        static Text TaskMethode(object parameter)
        {
            return new Text(parameter.ToString());
        }

    }
}
