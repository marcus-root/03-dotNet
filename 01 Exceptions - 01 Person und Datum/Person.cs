namespace dotNet_01_01_Person_Datum
{
    internal class Person
    {
        public String Name { get; set; }
        public String Vorname { get; set; }
        int _alter;
        public int Alter
        {
            get { return _alter; }
            set
            {
                if (value >= 0) _alter = value;
                else throw new Exception("Kein negatives Alter erlaubt!");
            }
        }
    }
}
