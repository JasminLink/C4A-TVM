using System;
using System.Collections.Generic;
using Microsoft.PointOfService;



    public class IDScanner
    {
        private Scanner scanner;
        private PosExplorer explorer;
        private string sData;



        public IDScanner()
        {
            explorer = new PosExplorer();
            var deviceCollection = explorer.GetDevices("Scanner");
            foreach (DeviceInfo deviceInfo in deviceCollection)
            {
                if (deviceInfo.ServiceObjectName != "Honeywell3310g")
                    continue;
                scanner = (Scanner)explorer.CreateInstance(deviceInfo);
                break;

            }
        }

        public string scan()
        {
            //warten auf DataEvent und Ausgabe der Daten in sData

            scanner.Open();
            scanner.Claim(1000);
            scanner.DeviceEnabled = true;

            scanner.DataEvent += new DataEventHandler(scanner_DataEvent);
            scanner.DataEventEnabled = true;
            scanner.DecodeData = true;

            while (scanner.DeviceEnabled == true)
            {
                System.Threading.Thread.Sleep(1);
            }


            scanner.Release();
            scanner.Close();
            
            // remove the space sign at the end of scanned string:
            int x = sData.Length;
            if (x < 0)
            {
                sData = sData.Remove(sData.Length - 1);
            }

            //sData = "jasmin";
            return sData;
        }

        // This method is made only for not having to remake the bar codes on the cards for the review 3
        // NP sets are called tvm_xxx while the cards show token xxx
        public String scan_for_review3_tvmTokens()
        {

            string userToken = scan();
            if (userToken.Contains("sammy"))
            {
                return "tvm_sammy";
            }
            else if (userToken.Contains("lara"))
            {
                return "tvm_lara";
            }
            else if (userToken.Contains("jasmin"))
            {
                return "tvm_valdimir"; ;
            }
            else if (userToken.Contains("vladimir"))
            {
                return "tvm_valdimir";
            }
            else
            {
                return "logout";
            }
        }


        public void scanner_DataEvent(object sender, DataEventArgs e)
        {
            //sobald Scan erkannt, Daten ablegen in sData
            byte[] Data = scanner.ScanData;
            sData = System.Text.Encoding.ASCII.GetString(Data);
            sData = sData.Remove(0, 5);
        }

    }
