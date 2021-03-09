using System;
using System.Collections.Generic;
using System.Text;

namespace ContratList
{
    public class Station 
    {

        public int number { get; set; }
        public string contractName { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public Position position { get; set; }



        public override string ToString()
        {
            string s = "";

            s += number;
            if (contractName != null)
            {
                s += " - " + contractName;
            }
            if (name != null)
            {
                s += " - " + name;
            }

            s += "\n" + "--- --- --- --- --- --- ---";
            return s;
        }

        public string ToStringDetails()
        {
            string s = "";

            s += number;
            if (contractName != null)
            {
                s += " - " + contractName;
            }
            if (name != null)
            {
                s += " - " + name + "\n";
            }
            if (status != null)
            {
                s += status;
            }
            if (address != null)
            {
                s += " - " + address;
            }

            s += "\n" + "--- --- --- --- --- --- ---";
            return s;
        }
    }
}
