namespace dotNet_17_Services_01_Feiertage
{
    internal class ApiResponse
    {
        public String status { get; set; }
        public String error_description { get; set; }
        public String additional_note { get; set; }
        public List<Feiertag> feiertage { get; set; }
    }
}
