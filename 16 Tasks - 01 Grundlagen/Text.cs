using System.Text.RegularExpressions;

namespace dotNet_16_Tasks_01_Grundlagen
{
    internal class Text
    {
        public String Dateipfad { get; private set; }
        public String TextContent { get; private set; }
        SortedDictionary<char, int> _buchstaben;

        public Text(String dateipfad)
        {
            Dateipfad = dateipfad;
            TextContent = File.ReadAllText(Dateipfad);
            _buchstaben = new SortedDictionary<char, int>();
            FillDictionary();
        }

        private void InkrementBuchstabe(char c)
        {
            if (_buchstaben.ContainsKey(c)) _buchstaben[c]++;
            else _buchstaben.Add(c, 1);
        }

        public String GetInformation()
        {
            String rück = "";
            rück += $"Der Text {Dateipfad} enthält folgende Buchstaben:\n";
            foreach (char c in _buchstaben.Keys)
            {
                rück += $" Buchstabe: {c} Vorkommen: {_buchstaben[c]}\n";
            }
            return rück;
        }

        private void FillDictionary()
        {
            foreach (char c in TextContent)
            {
                if (Regex.IsMatch(c.ToString(), @"^\w$")) InkrementBuchstabe(c);
            }
        }

    }
}
