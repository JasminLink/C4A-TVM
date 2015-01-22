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

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static TVMSettings listenForUser(String flowManager, Boolean emulateScanner)
        {
            String userToken = "logout";

            if (emulateScanner)
            {
                //userToken = "sammy";
                userToken = UPOSAdapter.generateRandomTestToken();
                Console.WriteLine("UPOSAdapter.generateRandomTestToken(" + userToken + ");");
            }
            else
            {
                if (UPOSAdapter.checkForScanner())
                {
                    Console.Write("scanner detected  ");
                    IDScanner scanner = new IDScanner();
                    userToken = scanner.scan();
                    Console.WriteLine("scanned userToken " + userToken);
                    log.Info("scanned userToken" + userToken);
                    
                }
                else
                {
                    // do nothing, but better tell user/log there is no scanner
                    Console.WriteLine("NO SCANNER detected");
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

        public static void printTicket(string ticketType, string special, string destination, string price, string person, string printerType, Boolean emulatePrinter)
        {
            if (emulatePrinter)
            {
                // do nothing, but better tell web app to show pop up animation of ticket that would have been printed... return image??
            }
            else
            {
                if (checkForPrinter())
                {
                    Console.Write("printer detected  ");
                    // ToDo: move generateTicket to UPOS Adapter??  as ticket can be generated and displayed even though there is not a printer
                    Bitmap ticket = Printer.generateTicket(ticketType, special, destination, price, person, printerType);
                    Printer printer = new Printer();
                    printer.printTicket(ticket);
                    Console.WriteLine("printing " + ticketType + ", " + special + ", " + destination + ", " + price + ", " + person + ", " + printerType);
                }
                else
                {
                    // do nothing, but better tell user/log there is no printer
                    Console.WriteLine("NO PRINTER detected");
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

        public static Boolean checkIfTicketPaid(string Preis)
        {
            //ToDo: add real payment with CashUnit
            return true;
        }

        public static Boolean checkForCashUnit()
        {
            //ToDo: add real payment with CashUnit
            return false;
        }
        


    }
}
