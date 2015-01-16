using System;

namespace Demo_GPII_Adapter {

    public class TVM
    {

        static String flowManager = TVMSettings.url_to_emulated_FlowManager;
        //static String flowManager = TVMSettings.url_to_local_cloudbased_FlowManager;
        //static String flowManager = TVMSettings.url_online_FlowManager;

        //static Boolean scanner = TVMSettings.emulateScanner;
        static Boolean scanner = TVMSettings.doNotEmulateScanner;

        static Boolean printer = TVMSettings.emulatePrinter;
        //static Boolean printer = TVMSettings.doNotemulatePrinter;

        public TVM()
        {
        }

        public static TVMSettings listenForUser()
        {
            TVMSettings ts = UPOSAdapter.listenForUser(flowManager, scanner);
            return ts;
        }

        public Boolean checkIfTicketPaid(string Preis)
        {
            UPOSAdapter.checkIfTicketPaid(Preis);
            //ToDo: give back if ticket was printed successfullyreturn true;
            return true;
        }

        public static Boolean printTicket(string ticketTyp, string Start, string Ziel, string Preis, string Datum, string Person)
        {

            UPOSAdapter.printTicket(ticketTyp, Start, Ziel, Preis, Datum, Person, printer);

            //ToDo: give back if ticket was printed successfully
            return true;

        }
    }

}

