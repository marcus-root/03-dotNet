namespace dotNet_05_Collections_03_Springertour
{
    internal class Springer
    {
        (char, int) _aktuellesFeld;
        readonly List<(char, int)> _besuchteFelder;

        public Springer((char, int) startfeld)
        {
            this._aktuellesFeld = startfeld;
            this._besuchteFelder = [startfeld];
        }

        private List<(char, int)> ErmittleMöglicheFelder((char, int) feld, List<(char, int)> besuchteFelder)
        {
            List<(char, int)> felder = [];

            if (feld.Item1 - 1 >= 'A')
            {
                if (feld.Item2 + 2 <= 8) { felder.Add(((char)(feld.Item1 - 1), feld.Item2 + 2)); }
                if (feld.Item2 - 2 >= 1) { felder.Add(((char)(feld.Item1 - 1), feld.Item2 - 2)); }
            }
            if (feld.Item1 - 2 >= 'A')
            {
                if (feld.Item2 + 1 <= 8) { felder.Add(((char)(feld.Item1 - 2), feld.Item2 + 1)); }
                if (feld.Item2 - 1 >= 1) { felder.Add(((char)(feld.Item1 - 2), feld.Item2 - 1)); }
            }
            if (feld.Item1 + 1 <= 'H')
            {
                if (feld.Item2 + 2 <= 8) { felder.Add(((char)(feld.Item1 + 1), feld.Item2 + 2)); }
                if (feld.Item2 - 2 >= 1) { felder.Add(((char)(feld.Item1 + 1), feld.Item2 - 2)); }
            }
            if (feld.Item1 + 2 <= 'H')
            {
                if (feld.Item2 + 1 <= 8) { felder.Add(((char)(feld.Item1 + 2), feld.Item2 + 1)); }
                if (feld.Item2 - 1 >= 1) { felder.Add(((char)(feld.Item1 + 2), feld.Item2 - 1)); }
            }

            List<(char, int)> geprüfteFelder = [];

            foreach ((char, int) f in felder)
            {
                if (!besuchteFelder.Contains(f)) geprüfteFelder.Add(f);
            }

            return geprüfteFelder;
        }

        private (char, int) ErmittleNächstesFeld((char, int) feld, List<(char, int)> besuchteFelder)
        {
            List<(char, int)> möglicheFelder = ErmittleMöglicheFelder(feld, besuchteFelder);
            (char, int) next = möglicheFelder[0];
            foreach ((char, int) f in möglicheFelder)
            {
                int erreichbareFelder = ErmittleMöglicheFelder(f, besuchteFelder).Count;
                if (erreichbareFelder < ErmittleMöglicheFelder(next, besuchteFelder).Count) next = f;
            }
            return next;
        }

        private void Zug((char, int) feld)
        {
            Console.SetCursorPosition(5 + (feld.Item1-65) * 5, (feld.Item2 * 2)-1);
            Console.Write($"{this._besuchteFelder.Count+1, 2}");
            this._aktuellesFeld = feld;
            this._besuchteFelder.Add(feld);
        }

        private void ZeichneBrett()
        {
            String trenner = "+----";
            for (int i = 0; i < 3; i++) { trenner += trenner; }
            trenner += "+";

            String nullzeile = "|  0 ";
            for (int i = 0; i < 3; i++) { nullzeile += nullzeile; }
            nullzeile += "|";

            for (int i = 8; i > 0; i--)
            {
                Console.WriteLine($"   {trenner}");
                Console.WriteLine($" {i} {nullzeile}");
            }
            Console.WriteLine($"   {trenner}");
            Console.WriteLine($"      A    B    C    D    E    F    G    H");
        }

        public void Lauf()
        {
            ZeichneBrett();
            Console.ForegroundColor= ConsoleColor.Green;
            Console.CursorVisible = false;
            Console.SetCursorPosition(5 + (this._aktuellesFeld.Item1 - 65) * 5, (this._aktuellesFeld.Item2 * 2) - 1);
            Console.Write($"{1,2}");
            while (this._besuchteFelder.Count < 64)
            {
                Thread.Sleep(500);
                Zug(ErmittleNächstesFeld(this._aktuellesFeld, this._besuchteFelder));
            }
            Console.SetCursorPosition(0, 20);
            Console.ResetColor();
        }
    }
}
