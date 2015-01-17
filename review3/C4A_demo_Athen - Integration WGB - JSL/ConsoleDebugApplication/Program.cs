using Demo_GPII_Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDebugApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            TVMSettings ts = TVM.listenForUser();
            Console.WriteLine(ts.TVMPreferences.contrastTheme);

            String ticketType = "Tageskarte";
            String special = "Fahrradmitnahme";
            String destination = "3 Zonen";
            String price = "7,20 €";
            String person = "Kinderermäßigung";

            TVM.printTicket(ticketType, special, destination, price, person);
            Console.ReadLine();

        }
    }
}
