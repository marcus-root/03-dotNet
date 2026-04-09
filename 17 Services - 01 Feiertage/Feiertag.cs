using System.Text.Json.Serialization;

namespace _18._01___Feiertage
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
