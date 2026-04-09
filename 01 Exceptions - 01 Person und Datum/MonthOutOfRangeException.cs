namespace dotNet_01_01_Person_Datum
{
    internal class MonthOutOfRangeException : Exception
    {
        public MonthOutOfRangeException(int monat) : base($"Der Monat {monat} ist ungültig!")
        {
        }
    }
}
