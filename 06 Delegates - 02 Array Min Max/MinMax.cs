namespace dotNet_06_Delegates_02_Array_Min_max
{
    internal static class MinMax
    {
        static public int GetLimit(VergleichsHandler vergleich, int[] array)
        {
            int index = default;
            int vergleichswert;

            // Welches Delegate wurde genutzt? Vergleichswert entscheiden
            if (vergleich.Method.Name == "IstKleiner") { vergleichswert = int.MaxValue; }
            else if (vergleich.Method.Name == "IstGrösser") { vergleichswert = 0; }
            else { throw new Exception("Es wurde eine ungültige Methode als Delegate übergeben"); }

            // Das Limit mit zugehörigem Index ermitteln
            for (int i = 0; i < array.Length; i++)
            {
                if (vergleich(array[i], vergleichswert)) { index = i; vergleichswert = array[i]; }
            }

            return index;
        }

        static public bool IstKleiner(int a, int b)
        {
            return a < b;
        }

        static public bool IstGrösser(int a, int b)
        {
            return a > b;
        }

        static public bool IstFalscheMethode(int a, int b)
        {
            return false;
        }
    }
}
