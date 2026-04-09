using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18._01___Feiertage
{
    internal class ApiResponse
    {
        public String status { get; set; }
        public String error_description { get; set; }
        public List<Feiertag> feiertage { get; set; }
    }
}
