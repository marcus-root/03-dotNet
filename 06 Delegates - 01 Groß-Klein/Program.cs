namespace dotNet_05_Delegates_01_Groß_Klein
{
    delegate void CharacterHandler(String text);
    internal class Program
    {
        static void Main(string[] args)
        {
            CharacterHandler ausgabe = Character.UpperCase;
            ausgabe += Character.LowerCase;
            ausgabe += Character.UpperLower;

            Delegate[] ausgabeListe = ausgabe.GetInvocationList();

            ausgabe += delegate (String text)
            {
                String ausgabe = "";
                foreach (char c in text)
                { ausgabe += $"{c} "; }
                Console.WriteLine(ausgabe);
            };

            ausgabe("Hallo Welt");
            Console.WriteLine();

            foreach (Delegate d in ausgabeListe)
            {
                Console.WriteLine(d.Method);
            }

        }
    }
}
