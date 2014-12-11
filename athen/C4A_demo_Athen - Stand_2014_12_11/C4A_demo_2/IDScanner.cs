using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        //warten auf DataEvent und Ausgabe der Daten in Label2
        scanner.Open();
        scanner.Claim(1000);
        scanner.DeviceEnabled = true;
        scanner.DataEvent += new DataEventHandler(scanner_DataEvent);
        scanner.DataEventEnabled = true;
        scanner.DecodeData = true;
        while (scanner.DeviceEnabled)
        {
            System.Threading.Thread.Sleep(1);
        }

        scanner.Release();
        scanner.Close();
        return sData;
    }
    
    public void scanner_DataEvent(object sender, DataEventArgs e)
    {
        //sobald Scan erkannt, Daten ablegen in sData
        byte[] Data = scanner.ScanData;
        sData = System.Text.Encoding.ASCII.GetString(Data);
        sData = sData.Remove(0, 5);
    }

    public static string getButtonStyle (string Data)
    {
        if (Data == "9783827247827")
        {
            return "bigButton";
        }
        return "idleButton";

    }

    public static string getBodyStyle (string Data)
    {
        if (Data == "9783827247827")
        {
            return "bigFontSize colorYellowBlack";
        }
        return "idle";
    }
}