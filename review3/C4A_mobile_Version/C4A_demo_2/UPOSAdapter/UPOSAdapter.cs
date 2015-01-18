using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Demo_GPII_Adapter
{
    class UPOSAdapter
    {

        public static TVMSettings listenForUsers(String flowManager)
        {
            String userToken = "logout";

            IDScanner scanner = new IDScanner();
            userToken = scanner.scan();
            TVMSettings tvmSettings = GPIIAdapter.getPreferences(userToken, flowManager);

            return tvmSettings;
        } 
        
        public static void printTicket(string ticketTyp, string Start, string Ziel, string Preis, string Datum, string Person)
        {
            Bitmap ticket = Printer.generateTicket(ticketTyp, Start, Ziel, Preis, Datum, Person);
            Printer printer = new Printer();
            printer.printTicket(ticket);

        }
    }
}
