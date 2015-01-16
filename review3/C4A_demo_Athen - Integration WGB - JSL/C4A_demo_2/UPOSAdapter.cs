using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.PointOfService;

namespace Demo_GPII_Adapter
{
    class UPOSAdapter
    {

        private PosExplorer explorer;
        
        
        public static TVMSettings listenForUser(String flowManager, Boolean emulateScanner)
        {
            String userToken = "logout";

            if (emulateScanner)
            {
                //userToken = "sammy";
                userToken = UPOSAdapter.generateRandomTestToken();
            }
            else
            {
                if (UPOSAdapter.checkForScanner())
                {
                    IDScanner scanner = new IDScanner();
                    userToken = scanner.scan();
                }
                else
                {
                    // do nothing, but better tell user/log there is no scanner
                }
            }
            
            TVMSettings tvmSettings = GPIIAdapter.getPreferences(userToken, flowManager);

            return tvmSettings;
        }

        public static Boolean checkForScanner()
        {
            Boolean check = false;

            PosExplorer explorer = new PosExplorer();
            var deviceCollection = explorer.GetDevices("Scanner");
            foreach (DeviceInfo deviceInfo in deviceCollection)
            {
                if (deviceInfo.ServiceObjectName != "Honeywell3310g")
                {
                    continue;
                }
                else
                {
                    check = true;
                }
            }
            return check;
        }

        public static String generateRandomTestToken()
        {
            Random rnd = new Random();
            int u = rnd.Next(0, 5); // creates a number between 0 and 4


            //String[] userTokens = { "sammy", "lara", "jasmin", "vladimir", "logout" };
            // tokens for review 3:
            String[] userTokens = { "tvm_sammy", "tvm_lara", "tvm_jasmin", "tvm_vladimir", "logout" };

            return userTokens[u];
        }

        public static void printTicket(string ticketTyp, string Start, string Ziel, string Preis, string Datum, string Person, Boolean emulatePrinter)
        {
            if (emulatePrinter)
            {
                // do nothing, but better tell web app to show pop up animation of ticket that would have been printed... return image??
            }
            else
            {
                if (checkForPrinter())
                {
                    // ToDo: move generateTicket to UPOS Adapter??  as ticket can be generated and displayed even though there is not a printer
                    Bitmap ticket = Printer.generateTicket(ticketTyp, Start, Ziel, Preis, Datum, Person);
                    Printer printer = new Printer();
                    printer.printTicket(ticket);
                }
                else
                {
                    // do nothing, but better tell user/log there is no printer
                }
            }
        }

        public static Boolean checkForPrinter()
        {
            Boolean check = false;

            PosExplorer explorer = new PosExplorer();
            var deviceCollection = explorer.GetDevices("PosPrinter");
            foreach (DeviceInfo deviceInfo in deviceCollection)
            {
                if (deviceInfo.ServiceObjectName != "VoRiMTD300Printer")
                {
                    continue;
                }
                else
                {
                    check = true;
                }
            }
            return check;
        }
        
        
        

    }
}
