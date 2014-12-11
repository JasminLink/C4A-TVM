using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.PointOfService;
using HoeftAndWessel.ServiceObjects.FeigRFIDSO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using OBID;
using System.Text;
using HoeftAndWessel.ServiceObjects.MeiBnrSO;
using System.Xml;



public class FeigRFID
 
{
    private PosExplorer explorer;
    private FeigRFID rfid;
    private string Data;

	public FeigRFID()
	{
        PosExplorer explorer = new PosExplorer();
        var deviceCollection = explorer.GetDevices("RFIDScanner");
        FeigRFID rfid = null;
        foreach (DeviceInfo deviceInfo in deviceCollection)
        {
            if (deviceInfo.ServiceObjectName != "FeigRFID")
                continue;
            rfid = (FeigRFID)explorer.CreateInstance(deviceInfo);
            break;
        }
        
        

        
	}
    
    public string scanRFID()
    {
        
        rfid.Open();
        rfid.Claim(1000);
        rfid.DeviceEnabled = true;
        rfid.DataEvent += new DataEventHandler(nfc_DataEvent);
        rfid.DataEventEnabled = true;
        
        while (rfid.DeviceEnabled)
        {
            System.Threading.Thread.Sleep(1);
        }

        rfid.Release();
        rfid.Close();
        return Data;
    }


    public void nfc_DataEvent(object sender, DataEventArgs e)
    {

    }
}