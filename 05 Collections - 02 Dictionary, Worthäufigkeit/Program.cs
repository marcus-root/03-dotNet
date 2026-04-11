namespace dotNet_05_Collections_02_Dictionary_Worthäufigkeit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Datei einlesen und in einen String speichern
            FileStream fs = new FileStream(@"..\..\..\Froschkönig Unix Zeilenumbrüche.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            String text = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            // Aus dem String ein Dictionary erstellen mit der Worthäufigkeit
            Dictionary<String, int> dict = Wortzähler<String, int>.Count(text);
            // Das Dictionary der Wörter nach Vorkommen sortiert ausgeben
            Wortzähler<String, int>.PrintInOrder(dict);

            
        }
    }
}
