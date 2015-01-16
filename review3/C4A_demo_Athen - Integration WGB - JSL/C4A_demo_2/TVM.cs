using System;

namespace Demo_GPII_Adapter {

    public class TVM
    {

        static String flowManager = TVMSettings.url_to_emulated_FlowManager;
        //static String flowManager = TVMSettings.url_to_local_cloudbased_FlowManager;
        //static String flowManager = TVMSettings.url_online_FlowManager;

        static Boolean scanner = TVMSettings.emulateScanner;
        //static Boolean scanner = TVMSettings.doNotEmulateScanner;

        public TVM()
        {
        }

        public static TVMSettings listenForUser()
        {
            TVMSettings ts = UPOSAdapter.listenForUser(flowManager, scanner);
            return ts;
        }


        public static Boolean printTicket(string ticketTyp, string Start, string Ziel, string Preis, string Datum, string Person)
        {

            UPOSAdapter.printTicket(ticketTyp, Start, Ziel, Preis, Datum, Person, true);

            return true;

        }
        public Boolean pay()
        {
            return true;
        }

    }

}

