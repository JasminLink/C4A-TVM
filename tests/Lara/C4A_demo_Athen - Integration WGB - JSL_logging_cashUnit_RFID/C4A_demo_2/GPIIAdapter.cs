using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Demo_GPII_Adapter
{
    class GPIIAdapter
    {



        public static String getPreferencesJSON(String userToken, String url_to_flowmanager)
        {
            Console.WriteLine("userToken " + userToken);
            TVMSettings ts = getPreferences(userToken, url_to_flowmanager); 
            print_and_default_TVMSettings(ts);
            Console.ReadLine();
            return JsonConvert.SerializeObject(ts);
        }

        
        public static TVMSettings getPreferences(String userToken, String url_to_flowmanager)
        {
            TVMSettings tvmSettings = new TVMSettings(TVMSettings.getDefaultPreferences());
            Console.WriteLine("userToken " + userToken);
            
            if (url_to_flowmanager == TVMSettings.url_to_online_FlowManager)
            {
                userToken = GPIIAdapter.transform_to_review3_tvmTokens(userToken);
                tvmSettings = queryFlowManager(userToken, TVMSettings.url_to_online_FlowManager);
            }
            else if (url_to_flowmanager == TVMSettings.url_to_local_cloudbased_FlowManager)
            {
                userToken = GPIIAdapter.transform_to_review3_tvmTokens(userToken);
                tvmSettings = queryFlowManager(userToken, TVMSettings.url_to_local_cloudbased_FlowManager);
            }
            else
            {
                tvmSettings = emulatePreferencesServer(userToken);
            }

            tvmSettings = print_and_default_TVMSettings(tvmSettings);
            return tvmSettings;
        }


        // This method is made only for not having to remake the bar codes on the cards for the review 3
        // NP sets are called tvm_xxx while the cards show token xxx
        public static String transform_to_review3_tvmTokens(String scannedToken)
        {

            
            if (scannedToken.Contains("sammy"))
            {
                return "tvm_sammy";
            }
            else if (scannedToken.Contains("lara"))
            {
                return "tvm_lara";
            }
            else if (scannedToken.Contains("jasmin"))
            {
                return "tvm_valdimir"; ;
            }
            else if (scannedToken.Contains("vladimir"))
            {
                return "tvm_valdimir";
            }
            else
            {
                return "logout";
            }
        }


        private static TVMSettings queryFlowManager(String userToken, String url_to_flowmanager)
        {
            /*
             * // Build url
            String command = "/settings"; //FlowManager takes commands login, logout, save, update and settings requests
            //String command = "%2Fsettings"; //FlowManager takes commands login, logout, save, update and settings requests
            //String device_info = "/%7B%22OS%22:%7B%22id%22:%22" + TVMSettings.GPII_OS_id + "%22%7D,%22solutions%22:%5B%7B%22id%22:%22" + TVMSettings.GPII_solution_id + "%22%7D%5D%7D";
            //String device_info = "/%2F%257B%2522OS%2522%3A%257B%2522id%2522%3A%2522" + TVMSettings.GPII_OS_id + "%2522%257D%2C%2522solutions%2522%3A%255B%257B%2522id%2522%3A%2522" + TVMSettings.GPII_solution_id + "%2522%257D%255D%257D";
            String device_info = "/%7B%22OS%22:%7B%22id%22:%22web%22%7D,%22solutions%22:%5B%7B%22id%22:%22de.fraunhofer.iao.C4A-TVM%22%7D%5D%7D";
            */

            String url_to_query = "";
            String command = "/settings"; //FlowManager takes commands login, logout, save, update and settings requests
            String device_info = "/%7B%22OS%22:%7B%22id%22:%22" + TVMSettings.GPII_OS_id + "%22%7D,%22solutions%22:%5B%7B%22id%22:%22" + TVMSettings.GPII_solution_id + "%22%7D%5D%7D";
            //String device_info = "/%7B%22OS%22:%7B%22id%22:%22linux%22%7D,%22solutions%22:%5B%7B%22id%22:%22org.gnome.desktop.a11y.magnifier%22%7D%5D%7D";
            
            Console.WriteLine("url_to_flowmanager " + url_to_flowmanager);
            Console.WriteLine("userToken " + userToken);
            Console.WriteLine("command " + command);
            Console.WriteLine("device_info " + device_info);
            
            Console.WriteLine("url_to_query " + url_to_query);

            //url_to_query = url_to_flowmanager + userToken + command + device_info;
            url_to_query = url_to_flowmanager + userToken + command + device_info;
            //url_to_query = "http://127.0.0.1:8081/sammy/settings/%7B%22OS%22:%7B%22id%22:%22web%22%7D,%22solutions%22:%5B%7B%22id%22:%22de.fraunhofer.iao.C4A-TVM%22%7D%5D%7D";
            //url_to_query = "http://127.0.0.1:8081/sammy/settings/%7B%22OS%22:%7B%22id%22:%22linux%22%7D,%22solutions%22:[%7B%22id%22:%22org.gnome.desktop.a11y.magnifier%22%7D]%7D";
            Console.WriteLine("url_to_query " + url_to_query);

            String JSONsettings = makeRequest(url_to_query);
            Console.WriteLine("JSONsettings " + JSONsettings);

            TVMSettings tvmSettings = new TVMSettings(TVMSettings.getDefaultPreferences());

            if (JSONsettings == "{}")
            {
                //do nothing = use default settings
            }
            else if (JSONsettings.Contains("Request Failed"))
            {
                //not found,  also do nothing special
                Console.WriteLine("UserToken not found - " + JSONsettings);
            }else{
                try
                {
                    tvmSettings = JsonConvert.DeserializeObject<TVMSettings>(JSONsettings);
                }
                catch (JsonReaderException e)
                {
                    if (e.Source != null)
                        Console.WriteLine("JsonReaderException source: {0}" + e.Source);
                
                }
            }

            
            return tvmSettings;
        }

        private static string makeRequest(String reqUrl)
        {
            Console.WriteLine("makeRequestreqUrl: " + reqUrl);
                
            String r = "Request Failed";
            try
            {
                WebRequest request = WebRequest.Create(reqUrl);
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine("HttpWebResponse.StatusDescription: " + ((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
                r = responseFromServer.ToString();
            }

            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("WebRequestException source: {0}" + e.Source);

            }
            
            return r;
        }

        private static TVMSettings emulatePreferencesServer(String userToken)
        {

            TVMPreferences tvmPreferences = new TVMPreferences();


            if (userToken.Contains("sammy"))
            {
                tvmPreferences = new TVMPreferences
                {
                    //user token added for debuggin 
                    userToken = "sammy",

                    contrastTheme = "yellow-black",
                    fontSize = "big",
                    fontFace = "Comic Sans",
                    buttonSize = "big",
                    timeOut = "long",
                    language = "de"
                };
            } 
            else if (userToken.Contains("lara"))
            {
                tvmPreferences = new TVMPreferences
                {
                    //user token added for debuggin 
                    userToken = "lara",

                    contrastTheme = "default",
                    fontSize = "default",
                    fontFace = "default",
                    buttonSize = "default",
                    timeOut = "long",
                    language = "el"
                };
            }
            else if (userToken.Contains("jasmin"))
            {
                tvmPreferences = new TVMPreferences
                {
                    //user token added for debuggin 
                    userToken = "jasmin",

                    contrastTheme = "default",
                    fontSize = "default",
                    fontFace = "default",
                    buttonSize = "big",
                    timeOut = "default",
                    language = "fr"
                };
            }
            else if (userToken.Contains("vladimir"))
            {
                tvmPreferences = new TVMPreferences
                {
                    //user token added for debuggin 
                    userToken = "vladimir",

                    contrastTheme = "yellow-black",
                    fontSize = "big",
                    fontFace = "default",
                    buttonSize = "big",
                    timeOut = "default",
                    language = "en"
                };
            } 
            else
            {
                tvmPreferences = TVMSettings.getDefaultPreferences();

            }

            TVMSettings tvmSettings = new TVMSettings(tvmPreferences);
            return tvmSettings;
        }

        public static TVMSettings print_and_default_TVMSettings(TVMSettings t)
        
        {
            if (t != null)
            {
                if (t.TVMPreferences != null)
                {
                    if (t.TVMPreferences.contrastTheme != null)
                    {
                        Console.WriteLine("contrastTheme " + t.TVMPreferences.contrastTheme);
                    }
                    else
                    {
                        t.TVMPreferences.contrastTheme = "default";
                    }

                    if (t.TVMPreferences.fontSize != null)
                    {
                        Console.WriteLine("fontSize " + t.TVMPreferences.fontSize);
                    }
                    else
                    {
                        t.TVMPreferences.fontSize = "default";
                    }

                    if (t.TVMPreferences.fontFace != null)
                    {
                        Console.WriteLine("fontFace " + t.TVMPreferences.fontFace);
                    }
                    else
                    {
                        t.TVMPreferences.fontFace = "default";
                    }

                    if (t.TVMPreferences.buttonSize != null)
                    {
                        Console.WriteLine("buttonSize " + t.TVMPreferences.buttonSize);
                    }
                    else
                    {
                        t.TVMPreferences.buttonSize = "default";
                    }

                    if (t.TVMPreferences.timeOut != null)
                    {
                        Console.WriteLine("timeOut " + t.TVMPreferences.timeOut);
                    }
                    else
                    {
                        t.TVMPreferences.timeOut = "default";
                    }

                    if (t.TVMPreferences.language != null)
                    {
                        Console.WriteLine("language " + t.TVMPreferences.language);
                    }
                    else
                    {
                        t.TVMPreferences.language = "default";
                    }
                }
                else
                {
                    t = new TVMSettings(TVMSettings.getDefaultPreferences());
                }
                
            }
            return t;
        }
    }
}
