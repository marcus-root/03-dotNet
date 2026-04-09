namespace dotNet_01_01_Person_Datum
{
    internal class DayOfMonthException : Exception
    {
        public DayOfMonthException(int tag) : base($"Der Tag {tag} ist ungültig!")
        { }
    }
}
