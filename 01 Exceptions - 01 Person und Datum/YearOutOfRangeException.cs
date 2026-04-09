namespace dotNet_01_01_Person_Datum
{
    internal class YearOutOfRangeException : Exception
    {
        public YearOutOfRangeException(int jahr) : base($"Das Jahr {jahr} ist ungültig!")
        {
        }
    }
}
