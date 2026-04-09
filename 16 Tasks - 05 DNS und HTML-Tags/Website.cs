using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _16._05___DNS_und_HTML_Tags
{
    internal class Website
    {
        String _dns;
        IPHostEntry _host;
        String _html;
        SortedDictionary<String, int> _tags;

        public Website(String dns) 
        {
            _dns = dns;
            _tags = new SortedDictionary<String, int>();
        }

        public String GetIPAdresses()
        {
            int anzahlAdressen = _host.AddressList.Count();
            String adressen = "";
            for (int i=0; i<anzahlAdressen; i++)
            {
                adressen += $"{_host.AddressList[i].ToString()} ";
            }
            return adressen;
        }

        public String GetTags()
        {
            String rück = "";
            foreach (String tag in _tags.Keys)
            { 
                rück += $"{tag} {_tags[tag]}, ";
            }
            return rück;
        }

        public void CountTags()
        {
            MatchCollection matches = Regex.Matches(_html, @"<[\/][^>]+>"); // Finde schließende Tags
            foreach (Match m in matches)
            {
                String tag = m.Value.Replace("/", "").Replace("<", "").Replace(">", "");
                if (_tags.ContainsKey(tag)) _tags[tag]++;
                else _tags.Add(tag, 1);
            }
        }

        public void DetermineHosts()
        {
            _host = Dns.GetHostEntry(_dns);
        }

        public void DownloadHtml()
        {
            WebClient client = new WebClient();
            try { _html = client.DownloadString($"http://{_dns}"); }
            catch (Exception e) {_html = "<donwloadError>o no</donwloadError>"; }
        }

        public override string ToString()
        {
            return $"{_dns}\n{GetIPAdresses()}\n{GetTags()}";
        }
    }
}
