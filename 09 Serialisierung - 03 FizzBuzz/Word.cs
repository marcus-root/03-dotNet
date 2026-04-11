namespace dotNet_09_Serialisierung_03_FizzBuzz
{
    internal class Word
    {
        public String Output { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"Zahlen die durch {Value} teilbar sind werden durch das Wort {Output} ersetzt.";
        }
    }
}