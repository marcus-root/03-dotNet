namespace dotNet_16_Tasks_05_DNS_und_HTML_Tags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String dnsDateipfad = @"..\..\..\dns.txt";
            String[] dnsStrings = File.ReadAllLines(dnsDateipfad);

            List<Website> websites = new List<Website>();
            List<Task> tHosts = new List<Task>();
            List<Task> tDownload = new List<Task>();
            List<Task> tCount = new List<Task>();

            foreach (String dns in dnsStrings)
            {
                websites.Add(new Website(dns));
            }

            foreach (Website w in websites)
            {
                tHosts.Add(Task.Factory.StartNew(w.DetermineHosts));
            }
            Task.WaitAll(tHosts.ToArray());

            foreach (Website w in websites)
            {
                tDownload.Add(Task.Factory.StartNew(w.DownloadHtml));
            }
            Task.WaitAll(tDownload.ToArray());

            foreach (Website w in websites)
            {
                tCount.Add(Task.Factory.StartNew(w.CountTags));
            }
            Task.WaitAll(tCount.ToArray());

            foreach (Website w in websites)
            {
                Console.WriteLine(w);
                Console.WriteLine();
            }
        }
    }
}
