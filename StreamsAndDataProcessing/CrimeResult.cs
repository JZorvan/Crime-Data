using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamsAndDataProcessing
{
    public class CrimeResult
    {
        public DateTime TimeOfIncident { get; set; }
        public string Address { get; set; }
        public int District { get; set; }
        public string Beat { get; set; }
        public int Grid { get; set; }
        public string Description { get; set; }
        public int NCIC_Code { get; set; }

    }
}
