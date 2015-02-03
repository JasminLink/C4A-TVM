using System;


namespace C4A_demo_2
{
    public class CTicket
    {
        public String destination = "";     // where to
        public String origin = "";          // from
        public String tarif = "";          // adult or child
        public String date = "";            // date of validity
        public double price = 0.0;          // price
        public String type = "";            // single or group ticket
        public String special = "";         // special conditions such as tourist offers, week-end special

        public double basefare = 2.40;
    }

    
}
