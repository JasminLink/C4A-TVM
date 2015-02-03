using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.PointOfService;


namespace C4A_demo_2
{
    public class CashUnit
    {
        private CashChanger cashUnit;
        private PosExplorer explorer;
        int TotalPaid;
        int Remaining;
        private int sum;


    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public CashUnit()
    {
        explorer = new PosExplorer();
        if (cashUnit == null)
            {
            var deviceCollection = explorer.GetDevices("CashChanger");
            foreach (DeviceInfo deviceInfo in deviceCollection)
                {
                if (deviceInfo.ServiceObjectName != "Hoeft & Wessel Cash Unit")
                    continue;
                cashUnit = (CashChanger)explorer.CreateInstance(deviceInfo);
                    break;
                }
            }
            
    }
    public void pay(string price)
    {
    
    sum = (int)(Single.Parse(price)*100);

    cashUnit.Open();
    log.Info("CashUnit opened");
    cashUnit.Claim(3000);
    log.Info("CashUnit claimed");
    cashUnit.DeviceEnabled = true;
    log.Info("CashUnit enabled");
   


    cashUnit.DataEvent += OnDataEvent;

    cashUnit.DataEventEnabled = true;
    cashUnit.BeginDeposit();
    log.Info("Deposit begun");


    }

    public void OnDataEvent(object sender, DataEventArgs dataEventArgs)
    {
        log.Info("Cash Unit Data Event registered");
        if (cashUnit.DepositAmount < sum)
        {
            
            TotalPaid = TotalPaid + cashUnit.DepositAmount;
            Remaining = sum - TotalPaid;
            if (Remaining <= 0)
            {
                //Hier steht, was passiert, wenn die Summe oder mehr als die Summe bezahlt wurde
                log.Info("Gesamte Summe bezahlt.");
                cashUnit.Close();
            }
            else
            {
                //Hier steht, was passiert, wenn noch nciht die gesamte Summe beglichen wurde
                log.Info("Es fehlen noch " + Remaining.ToString() + " Euro");
            }
        }
        else
        {
            //Hier steht, was passiert, wenn die Summe oder mehr als die Summe bezahlt wurde
            log.Info("Gesamte Summe bezahlt.");
            cashUnit.Close();
        }


    }

    }
}