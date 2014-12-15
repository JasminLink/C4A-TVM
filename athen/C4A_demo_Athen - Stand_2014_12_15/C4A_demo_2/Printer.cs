using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.PointOfService;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;



public class Printer
{
    private PosExplorer explorer;
    private PosPrinter printer;


    public Printer()
    {
        explorer = new PosExplorer();
        var deviceCollection = explorer.GetDevices("PosPrinter");
        foreach (DeviceInfo deviceInfo in deviceCollection)
        {
            if (deviceInfo.ServiceObjectName != "VoRiMTD300Printer")
                continue;
            printer = (PosPrinter)explorer.CreateInstance(deviceInfo);
            break;
        }
    }

    public void printTicket(Bitmap ticket)
    {
        printer.Open();
        printer.Claim(1000);
        printer.DeviceEnabled = true;

        //string ticketPathFile = "tix.bmp";
        //string ticketPathFile = "C:\\Temp\\ticket.bmp";
        string ticketPathFile = "C:\\Cloud4All\\GITRepository\\TestWebsite\\Ticket.bmp";
        //ticket.Save(ticketPathFile, System.Drawing.Imaging.ImageFormat.Bmp);
        printer.PrintBitmap(PrinterStation.Receipt, ticketPathFile, PosPrinter.PrinterBitmapAsIs, PosPrinter.PrinterBitmapCenter);
        // wirft POSControll Exception In Microsoft.PointOfService.PosControlException ist eine Ausnahme vom Typ "Microsoft.PointOfService.ControlBase.dll" aufgetreten, doch wurde diese im Benutzercode nicht verarbeitet.
        //printer.PrintMemoryBitmap(PrinterStation.Receipt, ticket, PosPrinter.PrinterBitmapAsIs, PosPrinter.PrinterBitmapCenter);

        //printer.PrintNormal(PrinterStation.Receipt, "Ticket");

        System.Threading.Thread.Sleep(8000);
        Console.WriteLine("sleeping");
        printer.CutPaper(100);
        printer.Release();
        printer.Close();

    }

    public static Bitmap generateTicket(string ticketType, string start, string destination, string price, string date, string person)
    {

        //Orte der verschiedenen Textboxen auf dem Ticket:
        Point StartLine1 = new Point(0, 100);
        Point EndLine1 = new Point(960, 100);
        Point StartLine2 = new Point(0, 700);
        Point EndLine2 = new Point(960, 700);
        PointF logoLocation = new PointF(150, 20);
        PointF fromLocation = new PointF(40, 300);
        PointF toLocation = new PointF(40, 500);
        PointF totalLocation = new PointF(40, 750);
        PointF ticketTypeLocation = new PointF(40, 150);
        PointF startLocation = new PointF(40, 400);
        PointF destinationLocation = new PointF(40, 600);
        PointF priceLocation = new PointF(500, 750);
        PointF dateLocation = new PointF(600, 150);
        PointF personLocation = new PointF(40, 200);

        //string imageFilePath = "C:\\Users\\kuehnle\\Documents\\TestWebsite\\NewTestTicket.bmp";


        Bitmap tempBmp = new Bitmap(960, 900);

        //auf das neu erstellte Bitmap draufzeichnen:
        using (Graphics g = Graphics.FromImage(tempBmp))
        {

            g.Clear(Color.White);
            g.DrawLine(new Pen(Brushes.Black, 10), StartLine1, EndLine1);
            g.DrawLine(new Pen(Brushes.Black, 10), StartLine2, EndLine2);

            using (Font arialFont = new Font("Arial", 40, FontStyle.Bold))
            {

                g.DrawString("Jakarta Commuter Train", arialFont, Brushes.Black, logoLocation);

                g.DrawString(ticketType, arialFont, Brushes.Black, ticketTypeLocation);

                g.DrawString(date, arialFont, Brushes.Black, dateLocation);


            }
            using (Font arialFont = new Font("Arial", 40, FontStyle.Underline))
            {
                g.DrawString("From:", arialFont, Brushes.Black, fromLocation);
                g.DrawString("To:", arialFont, Brushes.Black, toLocation);
            }
            using (Font arialFont = new Font("Arial", 40, FontStyle.Regular))
            {
                g.DrawString("Total:", arialFont, Brushes.Black, totalLocation);
                g.DrawString(start, arialFont, Brushes.Black, startLocation);
                g.DrawString(destination, arialFont, Brushes.Black, destinationLocation);
                g.DrawString(price, arialFont, Brushes.Black, priceLocation);
                g.DrawString(person, arialFont, Brushes.Black, personLocation);
            }
        }
        //Farbtiefe auf 1 reduzieren:
        Bitmap ticket = tempBmp.Clone(new Rectangle(0, 0, tempBmp.Width, tempBmp.Height), PixelFormat.Format1bppIndexed);

        //ticket.Save(imageFilePath,System.Drawing.Imaging.ImageFormat.Bmp);
        //ticket.Dispose();
        return ticket;

    }


}