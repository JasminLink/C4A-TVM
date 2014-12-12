using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_GPII_Adapter
{
    class CommandLine
    {
        static void Main(string[] args)
        {
            String flowManager = TVMSettings.url_to_local_cloudbased_FlowManager;
            String[] userTokens = {"logout", "sammy", "lara", "jasmin", "vladimir"};

            for (int i = 0; i < userTokens.Length; i++)
            {
                 //Console.WriteLine(GPIIAdapter.getPreferencesJSON(userTokens[i], flowManager));
                GPIIAdapter.listenForUsers(flowManager);

            }

            
             

            Console.Read();

        }
    }
}
