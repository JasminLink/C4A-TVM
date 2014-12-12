using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;

// GET     h ttp://127.0.0.1:8081/vladimir/settings/{"OS":{"id":"linux"},"solutions":[{"id":"org.gnome.desktop.a11y.magnifier"}]}
//BACK     {"org.gnome.desktop.a11y.magnifier":{"mag-factor":2,"mouse-tracking":"centered","screen-position":"full-screen"}} 

// GET     h ttp://127.0.0.1:8081/sammy/settings/{"OS":{"id":"web"},"solutions":[{"id":"de.fraunhofer.iao.C4A-TVM"}]}
//BACK     {"de.fraunhofer.iao.C4A-TVM":{"highContrastEnabled": true, "fontSize": "big"}} 


namespace ConsoleGET
{
    class Program
    {
        static void Main(string[] args)
            
        {


            TVMPreferences tvmPrefs = new TVMPreferences
            {
                contrastTheme = "yellow-black",
                fontSize = "big",
                fontFace = "Comic Sans",
                buttonSize = "big",
                timeOut = "long",
                language = "de"

            };

            TVMSettings t2 = new TVMSettings(tvmPrefs);

            string x = JsonConvert.SerializeObject(t2);
            
            Console.WriteLine(x + "  ConsoleGET.Program");

            x = "{\"de.fraunhofer.iao.C4A-TVM\":{\"contrastTheme\": \"yellow-black\", \"fontSize\": \"default\", \"fontFace\": \"default\", \"buttonSize\": \"default\", \"timeOut\": \"default\", \"language\": \"default\"}}";

            Console.WriteLine("input string" + x);

            TVMSettings t1 = JsonConvert.DeserializeObject<TVMSettings>(x);
            printTVMSettings(t1);

            

            Console.ReadLine();
            
        }

        public static void printTVMSettings(TVMSettings t)
        {
            String c = t.TVMPreferences.contrastTheme;
            String fs = t.TVMPreferences.fontSize;
            String ff = t.TVMPreferences.fontFace;
            String bs = t.TVMPreferences.buttonSize;
            String to = t.TVMPreferences.timeOut;
            String l = t.TVMPreferences.language;

            if (fs != null)
            {
                Console.WriteLine("fs = " + fs);
            }
            else
            {
                Console.WriteLine("fs = null");
            }


            if (c != null)
            {
                Console.WriteLine("c = " + c);
            }
            else
            {
                Console.WriteLine("c = null");
            }

            if (ff != null)
            {
                Console.WriteLine("ff = " + ff);
            }
            else
            {
                Console.WriteLine("ff = null");
            }

            if (fs != null)
            {
                Console.WriteLine("fs = " + fs);
            }
            else
            {
                Console.WriteLine("fs = null");
            }

            if (bs != null)
            {
                Console.WriteLine("bs = " + bs);
            }
            else
            {
                Console.WriteLine("bs = null");
            }

            if (to != null)
            {
                Console.WriteLine("to = " + to);
            }
            else
            {
                Console.WriteLine("to = null");
            }

            if (l != null)
            {
                Console.WriteLine("l = " + l);
            }
            else
            {
                Console.WriteLine("l = null");
            }
        }

        public void readJson()
        {
            string url_to_flowmanager = "http://flowmanager.gpii.net/";
            string usertoken = "sammy";
            string command = "/settings"; //Flow Manager takes login, logout, save, update an settings requests
            string device_info = "/%7B%22OS%22:%7B%22id%22:%22linux%22%7D,%22solutions%22:%5B%7B%22id%22:%22org.gnome.desktop.a11y.magnifier%22%7D%5D%7D";
            string requested_url = "";
            //"{\"OS\":{\"id\":\"linux\"},\"solutions\":[{\"id\":\"org.gnome.desktop.a11y.magnifier\"}]}"; //for testing only later: see below
            //string device_info = "{\"OS\":{\"id\":\"window\"},\"solutions\":[{\"id\":\"org.H+W+FraunhoferIAO.C4A.tvm\"}]}"; //what the solution id might look like
            string json = "{\"org.gnome.desktop.a11y.magnifier\":{\"mag-factor\":2,\"mouse-tracking\":\"centered\",\"screen-position\":\"full-screen\"}}";

            //string json1 = "{\"org.gnome.desktop.a11y.magnifier\":{\"mag-factor\":2,\"mouse-tracking\":\"centered\",\"screen-position\":\"full-screen\"}}";
            string json2 = "{\"de.fraunhofer.iao.C4A-TVM\":{\"fontsize\":\"big\",\"contrast\":\"yellow-black\",\"screen-position\":\"full-screen\"}}";
            //string json = json1;


            // BUILD STRUCTURE FOR TVM SETTINGS: de.fraunhofer.iao.C4A-TVM - "", fontsize , contrast,...


            //JsonConvert.DeserializeObject<List<CustomerJson>>(json);

            Console.WriteLine("Hello Cloud! Who's there?");
            //usertoken = Console.ReadLine();
            Console.WriteLine("Hello " + usertoken + "! ");
            Console.ReadLine();
            //try{
            //  requested_url = Path.Combine(url_to_flowmanager, usertoken, command) + device_info;
            //}catch (ArgumentException argEx){
            //  Console.WriteLine("Exception message: " + argEx.Message);
            //}             
            requested_url = url_to_flowmanager + usertoken + command + device_info;
            Console.WriteLine("requested url = " + requested_url);
            Console.ReadLine();

        }

        public static string makeRequest(String reqUrl)
        {
            String r = "";
            WebRequest request = WebRequest.Create(reqUrl);
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine("HttpWebResponse.StatusDescription: "+((HttpWebResponse)response).StatusDescription);
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
            return r;
        }
    }



    public class TVMSettings
    {

        public TVMSettings(TVMPreferences tvmPreferences)
        {
            this.TVMPreferences = tvmPreferences;
        }

        [JsonProperty("de.fraunhofer.iao.C4A-TVM")]
        public TVMPreferences TVMPreferences { get; set; }
    }


    public class TVMPreferences
    {
        //[JsonProperty("name")]
        public string contrastTheme {get; set;} // default, yellow-black
        //[JsonProperty("name")]
        public string fontSize { get; set; } //default, big
        //[JsonProperty("name")]
        public string fontFace { get; set; } //default (Calibri), Comics Sans, Tiresias
        //[JsonProperty("name")]
        public string buttonSize { get; set; } //default, big
        //[JsonProperty("name")]
        public string timeOut { get; set; } //default, long
        //[JsonProperty("name")]
        public string language { get; set; } //default (en), es, fr, it, de, he, ...
    }


    public class TVMUserListener
    {
        public String listenForUserToken()
        {
            //question web app or scanner
            return "sammy";
        }


    }

    public class TVMPreferenceInvoker
    {

        public String getPreferencesFromServer()
        {
            //question web app or scanner
            return "{\"de.fraunhofer.iao.C4A-TVM\":{\"contrastTheme\": \"yellow-black\", \"fontSize\": \"default\", \"fontFace\": \"default\", \"buttonSize\": \"default\", \"timeOut\": \"default\", \"language\": \"default\"}}";

        }

        public TVMPreferences applyPrefsToUi()
        {
            //question web app or scanner
            TVMPreferences t = new TVMPreferences{
                contrastTheme = "yellow-black",
                fontSize = "big",
                fontFace = "Comic Sans",
                buttonSize = "big",
                timeOut = "long",
                language = "de"

            };
            return t;
        }

    }
}
