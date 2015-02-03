using HoeftAndWessel;
using Microsoft.PointOfService.BaseServiceObjects;
using Microsoft.PointOfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoeftAndWessel.UposDevicesLib;
using HoeftAndWessel.UposDevicesLib.ViewModels.LogVMs;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;



public class FeigRFID
{
    private PosExplorer explorer;
    private RFIDScanner rfid;
    private string Data;

    public FeigRFID()
    {
        explorer = new PosExplorer();
        if (rfid == null)
        {
            var deviceCollection = explorer.GetDevices("RFID Scanner");
            foreach (DeviceInfo deviceInfo in deviceCollection)
            {
                if (deviceInfo.ServiceObjectName != "FeigRFID")
                    continue;
                rfid = (RFIDScanner)explorer.CreateInstance(deviceInfo);
                break;
            }
        }



    }


    public void scanNFC()
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
        //return Data;
    }


    public void nfc_DataEvent(object sender, DataEventArgs e)
    {
        log.Info("nfc scan notified");
    }

    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
}