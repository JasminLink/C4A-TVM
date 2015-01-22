using System;

namespace Demo_GPII_Adapter {

    public class TVM
    {

        static String flowManager = TVMSettings.url_to_emulated_FlowManager;
        //static String flowManager = TVMSettings.url_to_local_cloudbased_FlowManager;
        //static String flowManager = TVMSettings.url_online_FlowManager;

        static Boolean emulateScanner = true;
        //static Boolean emulateScanner = false;

        static Boolean emulatePrinter = true;
        //static Boolean emulatePrinter = false;

        static String printerType = TVMSettings.mobilePrinter;
        //static String printerType = TVMSettings.built_in_printer;

        public TVM()
        {
        }

        public static TVMSettings listenForUser()
        {
            Console.WriteLine("TVM.listenForUser( FM: " + flowManager + ", emulate" + emulateScanner);
            TVMSettings ts = UPOSAdapter.listenForUser(flowManager, emulateScanner);
            return ts;
        }

        public Boolean checkIfTicketPaid(string Preis)
        {
            UPOSAdapter.checkIfTicketPaid(Preis);
            //ToDo: give back if ticket was printed successfullyreturn true;
            return true;
        }

        public static Boolean printTicket(string ticketType, string special, string destination, string price, string person)
        {

            Console.WriteLine("TVM.printTicket( emulatePrinter" + emulatePrinter);
            UPOSAdapter.printTicket(ticketType, special, destination, price, person, printerType, emulatePrinter);

            //ToDo: give back if ticket was printed successfully
            return true;

        }
    }

}

