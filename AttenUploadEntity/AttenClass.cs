using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttenUploadEntity
{
    public class AttenClass
    {

        public string empid { get; set; }
        public string idcardno { get; set; }
        public string intime { get; set; }
        public string outtime { get; set; }
        public string offintime { get; set; }
        public string offouttime { get; set; }
        public string lnchintime { get; set; }
        public string lnchouttime { get; set; }
        public double addhour { get; set; }

        public AttenClass()
        {
        }

    }
}
