using System;

using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using Microsoft.PointOfService.Legacy;
using Microsoft.PointOfService.Management;
using Microsoft.PointOfService;
using System.Drawing;
using System.Drawing.Imaging;


public partial class _Default : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void ButtonScan_Click(object sender, EventArgs e)
    {
        //Diese beiden Zeilen scannen einen Barcode ein und speichern die eingescannten Daten in Data
        IDScanner scanner = new IDScanner();
        string Data = scanner.scan();
        Console.WriteLine(Data);




        //Diese Zeilen erstellen ein Ticket mit den eingegebenen Parametern und drucken dieses aus
        Bitmap ticket = Printer.generateTicket("Single Ticket", "Duri", "Jatinegara","10.000 Rp.");
        Printer printer = new Printer();
        printer.printTicket(ticket);


    }


    protected void mybutton_Click(object sender, EventArgs e)
    {
        
    }

}
