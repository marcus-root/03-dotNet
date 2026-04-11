namespace dotNet_05_Delegates_01_Groß_Klein
{
    internal static class Character
    {
        public static void UpperCase(String text)
        {
            Console.WriteLine(text.ToUpper());
        }

        public static void LowerCase(String text)
        {
            Console.WriteLine(text.ToLower());
        }

        public static void UpperLower(String text)
        {
            Console.WriteLine(text);
        }
    }
}
