using System;
using System.Collections.Generic;
using Microsoft.PointOfService;



    public class IDScanner
    {
        private Scanner scanner;
        private PosExplorer explorer;
        private string sData = null;



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

            for (int i = 0; i < 3; i++)
            {
                try
                {
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
                }
                catch (Microsoft.PointOfService.PosControlException e)
                {
                    Console.WriteLine(e.ToString());
                    Console.ReadLine();
                }
            }


            if (sData != null)
            {
                // remove the space sign at the end of scanned string:
                int x = sData.Length;
                if (x < 0)
                {
                    sData = sData.Remove(sData.Length - 1);
                }
            }
            else
            {
                sData = "SCANNING ERROR";
            }
            
            //sData = "jasmin";
            return sData;
        }



        public void scanner_DataEvent(object sender, DataEventArgs e)
        {
            //sobald Scan erkannt, Daten ablegen in sData
            byte[] Data = scanner.ScanData;
            sData = System.Text.Encoding.ASCII.GetString(Data);
            sData = sData.Remove(0, 5);
        }

    }
