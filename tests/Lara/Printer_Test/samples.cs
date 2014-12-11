using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using Microsoft.PointOfService;



    public sealed class Session : System.Web.SessionState.HttpSessionState
    {
        private static readonly Session instance = new Session();
        private Session() { }

        public static Session Instance
        {
            get
            {
                return instance;
            }
        }
       
        PosExplorer explorer = new PosExplorer();
        
        private Scanner scanner;
        public Scanner Scanner
        {
            get
            {
                if (scanner == null)
                {
                    var deviceCollection = explorer.GetDevices("scanner");
                    foreach (DeviceInfo deviceInfo in deviceCollection)
                    {
                        if (deviceInfo.ServiceObjectName != "Honeywell3310g")
                            continue;
                        scanner = (Scanner)explorer.CreateInstance(deviceInfo);
                        break;
                    }
                    if (scanner == null)
                        return null;
                    scanner.Open();
                    scanner.Claim(3000);
                    scanner.DeviceEnabled = true;
                }
                return scanner;
            }
            set
            {
                scanner = value;
            }
        }
    }

PosExplorer explorer = new PosExplorer();
        var deviceCollection = explorer.GetDevices("scanner");
        foreach (DeviceInfo deviceInfo in deviceCollection)
        {
            if (deviceInfo.ServiceObjectName != "Honeywell3310g")
                continue;
            scanner = (Scanner)explorer.CreateInstance(deviceInfo);
            break;
        }

        scanner.Open();
        scanner.Claim(10000);
        scanner.DeviceEnabled = true;
        scanner.DataEvent += new DataEventHandler(scanner_DataEvent);
        scanner.DataEventEnabled = true;
        scanner.DecodeData = true;
        //byte[] Data = scanner.ScanData;
        //string sData = System.Text.Encoding.ASCII.GetString(Data);
  