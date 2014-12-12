using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Demo_GPII_Adapter
{

    public class TVMSettings
    {
        public const String GPII_solution_id = "de.fraunhofer.iao.C4A-TVM";
        public const String GPII_OS_id = "web";
        public const String url_to_emulated_FlowManager = "emulate";
        public const String url_to_online_FlowManager = "http://flowmanager.gpii.net/";
        public const String url_to_local_cloudbased_FlowManager = "http://127.0.0.1:8081/";
        //public const String url_to_local_cloudbased_FlowManager = "http%3A%2F%2F127.0.0.1%3A8081%2Fy";
        

        [JsonProperty(GPII_solution_id)]
        public TVMPreferences TVMPreferences { get; set; }

        public TVMSettings(TVMPreferences tvmPreferences)
        {
            this.TVMPreferences = tvmPreferences;
        }

        public static TVMPreferences getDefaultPreferences()
        {
            TVMPreferences tp = new TVMPreferences
            {
                contrastTheme = "default",
                fontSize = "default",
                fontFace = "default",
                buttonSize = "default",
                timeOut = "default",
                language = "default"
            };

            return tp;
        }
        
        
    }
    
    public class TVMPreferences
    {
        //[JsonProperty("JSONname")]
        public string contrastTheme { get; set; } // default, yellow-black
        //[JsonProperty("JSONname")]
        public string fontSize { get; set; } //default, big
        //[JsonProperty("JSONname")]
        public string fontFace { get; set; } //default (Calibri), Comics Sans, Tiresias
        //[JsonProperty("JSONname")]
        public string buttonSize { get; set; } //default, big
        //[JsonProperty("JSONname")]
        public string timeOut { get; set; } //default, long
        //[JsonProperty("JSONname")]
        public string language { get; set; } //default (en), es, fr, it, de, he, ...
    }
}
