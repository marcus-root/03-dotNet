using System.Text.Json.Serialization;

namespace dotNet_17_Services_02_Personendaten
{
    internal class Entity
    {
        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("gender")]
        public String Gender { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("country")]
        public List<Country> Countries { get; set; }

        public override string ToString()
        {
            String rück = $"{Name} | {Gender} | {Age} | ";
            foreach (Country country in Countries)
            {
                rück += $"{country.country_id}, ";
            }
            return rück.Substring(0, rück.Length - 2);
        }
    }
}
