using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

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


        public void reset()
        {
         destination = "";     // where to
         origin = "";          // from
         tarif = "";          // adult or child
         date = "";            // date of validity
         price = 0.0;          // price
         type = "";            // single or group ticket
         special = "";         // special conditions such as tourist offers, week-end special
        }
    }



    
}
