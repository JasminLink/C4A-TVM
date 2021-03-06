﻿//using HoeftAndWessel;
using Microsoft.PointOfService.BaseServiceObjects;
using Microsoft.PointOfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using HoeftAndWessel.UposDevicesLib;
//using HoeftAndWessel.UposDevicesLib.ViewModels.LogVMs;
using System.Configuration;
using System.Data;
using System.Threading;
using log4net;



using System.Windows;



public class FeigRFID
{
    private PosExplorer explorer;
    private RFIDScanner rfid;


    public FeigRFID()
    {
        explorer = new PosExplorer();
        if (rfid == null)
        {
            var deviceCollection = explorer.GetDevices("RFIDScanner");
            foreach (DeviceInfo deviceInfo in deviceCollection)
            {
                if (deviceInfo.ServiceObjectName != "FeigRFID")
                    continue;
                rfid = (RFIDScanner)explorer.CreateInstance(deviceInfo);
                log.Info(deviceInfo.ToString());
                break;
            }
        }



    }
    public string getName()
    {
         return rfid.DeviceName;
    }

    public void scanNFC()
    {

        if (rfid != null)
        {
            rfid.Open();
            log.Info("RFID opened");
            rfid.Claim(1000);
            log.Info("RFID claimed");
            rfid.DeviceEnabled = true;
            log.Info("RFID enabled");

            
            byte[] filterID = new byte[]{0};
            byte[] filterMask = new byte[]{0};
            rfid.ReadTags(RFIDReadOptions.TagId, filterID, filterMask, 1, 1, 1000, null);
            log.Info("Reading successfull");
            //rfid.FirstTag();

            
            byte[] dataTagID = rfid.CurrentTagId;
            log.Info("TagID: " + BitConverter.ToString(dataTagID));
            byte[] dataUserData = rfid.CurrentTagUserData;
            log.Info("UserData: " + BitConverter.ToString(dataUserData));

            rfid.Release();
            log.Info("RFID released");
            rfid.Close();
            log.Info("RFID closed");
            //return Data;
        }
    }


    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
}