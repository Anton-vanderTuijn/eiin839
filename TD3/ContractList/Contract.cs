using System;
using System.Collections.Generic;
using System.Text;

namespace ContratList
{
    public class Contract 
    {

        public string name { get; set; }
        public string commercial_name { get; set; }
        public string country_code { get; set; }
        public List<string> cities { get; set; }


        public override string ToString()
        {
            string s = "";

            s += name;
            if (commercial_name != null)
            {
                s += " - " + commercial_name;
            }
            if (country_code != null)
            {
                s += " - " + country_code + "\n";
            }
            if (cities != null)
            {
                foreach (string city in cities)
                {
                    if (city != "")
                    {
                        s += city + " ";
                    }
                }
            }

            s += "\n" + "--- --- --- --- --- --- ---";
            return s;
        }
    }
}
