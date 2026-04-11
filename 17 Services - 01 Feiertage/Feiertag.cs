using System.Text.Json.Serialization;

namespace dotNet_17_Services_01_Feiertage
{
    internal class Feiertag
    {
        public DateTime Date { get; private set; }
        public String date
        {
            set
            {
                Date = DateTime.Parse(value);
            }
        }

        [JsonPropertyName("fname")]
        public String Name { get; set; }
    }
}
