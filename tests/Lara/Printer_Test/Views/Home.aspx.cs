using System;

using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using Microsoft.PointOfService;
using System.Drawing;
using System.Drawing.Imaging;



namespace Home
{
    public partial class _Default : System.Web.UI.Page
    {


        protected void Page_LoadComplete(object sender, EventArgs e)
        {
           
        }

        
        protected void ButtonScan_Click(object sender, EventArgs e)
        {
        //Diese beiden Zeilen scannen einen Barcode ein und speichern die eingescannten Daten in Data
             // Data = scanner.scan();
           
        //Diese Zeilen erstellen ein Ticket mit den eingegebenen Parametern und drucken dieses aus
            //Bitmap ticket = Printer.generateTicket("Single Ticket", "Duri", "Jatinegara","10.000 Rp.");
            //Printer printer = new Printer();
            //printer.printTicket(ticket);

        //IDNFC scanner = new IDNFC();
            PosExplorer explorer = new PosExplorer();
            
            string devices = "";

            FeigRFID rfid = new FeigRFID();
            
            rfid.Open();
            rfid.Claim(1000);
            rfid.DeviceEnabled = true;
            Label1.Text = "finished";
           
        }

      



    }  
}
