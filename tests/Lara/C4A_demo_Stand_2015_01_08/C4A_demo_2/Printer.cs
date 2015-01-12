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
        //ResizePicByWidth(ticket, 480);


        //string ticketPathFile = "ticket.bmp";
        //ticket.Save(ticketPathFile, System.Drawing.Imaging.ImageFormat.Bmp);
        //printer.PrintBitmap(PrinterStation.Receipt, ticketPathFile, PosPrinter.PrinterBitmapAsIs, PosPrinter.PrinterBitmapCenter);
        using (System.IO.MemoryStream ms = new MemoryStream())
        {
            ticket.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            using (System.Drawing.Bitmap bmp = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(ms))
            {
                printer.PrintMemoryBitmap(PrinterStation.Receipt, bmp, PosPrinter.PrinterBitmapAsIs, PosPrinter.PrinterBitmapCenter);
            }
        }

        System.Threading.Thread.Sleep(2000);
        printer.CutPaper(100);
        printer.Release();
        printer.Close();

    }

    public string tvm_printer()
    {
        return "tvm_printer";
    }

    public string mobile_printer()
    {
        return "mobile_printer";
    }

    public static Bitmap getTicket(string ticketType, string special, string destination, string price, string person, string printerType)
    {
        if (ticketType == "Streifenticket")
        {
            Bitmap ticket = generateStreifenticket(person, price, special, printerType);
            return ticket;
        }
        else
        {
            Bitmap ticket = generateTicket(ticketType, special, destination, price, person, printerType);
            return ticket;
        }
    }
    public static Bitmap generateTicket(string ticketType, string special, string destination, string price, string person, string printerType)
    {

        DateTime today = DateTime.Now;
        string date = today.ToString("dd.MM.yyyy");
        if (special == "Kein Zusatzangebot")
        {
            special = "";
        }
        else
        {

        }

        if (printerType == "mobile_printer")
        {
            //Orte der verschiedenen Textboxen auf dem Ticket:
            PointF logoLocation = new PointF(110, 10);
            Point StartLine1 = new Point(20, 60);
            Point EndLine1 = new Point(480, 60);
            PointF ticketTypeLocation = new PointF(20, 75);
            PointF dateLocation = new PointF(320, 75);
            PointF personLocation = new PointF(20, 115);
            PointF destinationLocation = new PointF(20, 220);
            PointF specialLocation = new PointF(250, 300);
            Point StartLine2 = new Point(20, 350);
            Point EndLine2 = new Point(480, 350);
            PointF totalLocation = new PointF(20, 385);
            PointF priceLocation = new PointF(320, 385);




            //string imageFilePath = "C:\\Users\\kuehnle\\Documents\\TestWebsite\\NewTestTicket.bmp";


            Bitmap tempBmp = new Bitmap(560, 450);

            //auf das neu erstellte Bitmap draufzeichnen:
            using (Graphics g = Graphics.FromImage(tempBmp))
            {

                g.Clear(Color.White);

                using (Font arialFont = new Font("Arial", 30, FontStyle.Bold))
                {
                    g.DrawString("Cloud4all TVM", arialFont, Brushes.Black, logoLocation);
                }

                g.DrawLine(new Pen(Brushes.Black, 5), StartLine1, EndLine1);

                using (Font arialFont = new Font("Arial", 20, FontStyle.Bold))
                {
                    g.DrawString(ticketType, arialFont, Brushes.Black, ticketTypeLocation);
                    g.DrawString(date, arialFont, Brushes.Black, dateLocation);
                }

                using (Font arialFont = new Font("Arial", 20, FontStyle.Regular))
                {
                    g.DrawString(person, arialFont, Brushes.Black, personLocation);
                    g.DrawString(special, arialFont, Brushes.Black, specialLocation);
                }

                using (Font arialFont = new Font("Arial", 33, FontStyle.Bold))
                {

                    g.DrawString(destination, arialFont, Brushes.Black, destinationLocation);
                }

                g.DrawLine(new Pen(Brushes.Black, 5), StartLine2, EndLine2);

                using (Font arialFont = new Font("Arial", 25, FontStyle.Regular))
                {
                    g.DrawString("Summe:", arialFont, Brushes.Black, totalLocation);
                    g.DrawString(price, arialFont, Brushes.Black, priceLocation);
                }

            }
            //Farbtiefe auf 1 reduzieren:
            Bitmap ticket = tempBmp.Clone(new Rectangle(0, 0, tempBmp.Width, tempBmp.Height), PixelFormat.Format1bppIndexed);

            //ticket.Save(imageFilePath,System.Drawing.Imaging.ImageFormat.Bmp);
            //ticket.Dispose();
            return ticket;
        }
        else
        {
            //Orte der verschiedenen Textboxen auf dem Ticket:
            PointF logoLocation = new PointF(110, 10);
            Point StartLine1 = new Point(20, 60);
            Point EndLine1 = new Point(480, 60);
            PointF ticketTypeLocation = new PointF(20, 75);
            PointF dateLocation = new PointF(320, 75);
            PointF personLocation = new PointF(20, 115);
            PointF destinationLocation = new PointF(20, 220);
            PointF specialLocation = new PointF(250, 300);
            Point StartLine2 = new Point(20, 350);
            Point EndLine2 = new Point(480, 350);
            PointF totalLocation = new PointF(20, 385);
            PointF priceLocation = new PointF(320, 385);




            //string imageFilePath = "C:\\Users\\kuehnle\\Documents\\TestWebsite\\NewTestTicket.bmp";


            Bitmap tempBmp = new Bitmap(560, 450);

            //auf das neu erstellte Bitmap draufzeichnen:
            using (Graphics g = Graphics.FromImage(tempBmp))
            {

                g.Clear(Color.White);

                using (Font arialFont = new Font("Arial", 30, FontStyle.Bold))
                {
                    g.DrawString("Cloud4all TVM", arialFont, Brushes.Black, logoLocation);
                }

                g.DrawLine(new Pen(Brushes.Black, 5), StartLine1, EndLine1);

                using (Font arialFont = new Font("Arial", 20, FontStyle.Bold))
                {
                    g.DrawString(ticketType, arialFont, Brushes.Black, ticketTypeLocation);
                    g.DrawString(date, arialFont, Brushes.Black, dateLocation);
                }

                using (Font arialFont = new Font("Arial", 20, FontStyle.Regular))
                {
                    g.DrawString(person, arialFont, Brushes.Black, personLocation);
                    g.DrawString(special, arialFont, Brushes.Black, specialLocation);
                }

                using (Font arialFont = new Font("Arial", 33, FontStyle.Bold))
                {

                    g.DrawString(destination, arialFont, Brushes.Black, destinationLocation);
                }

                g.DrawLine(new Pen(Brushes.Black, 5), StartLine2, EndLine2);

                using (Font arialFont = new Font("Arial", 25, FontStyle.Regular))
                {
                    g.DrawString("Summe:", arialFont, Brushes.Black, totalLocation);
                    g.DrawString(price, arialFont, Brushes.Black, priceLocation);
                }

            }
            //Farbtiefe auf 1 reduzieren:
            Bitmap ticket = tempBmp.Clone(new Rectangle(0, 0, tempBmp.Width, tempBmp.Height), PixelFormat.Format1bppIndexed);

            //ticket.Save(imageFilePath,System.Drawing.Imaging.ImageFormat.Bmp);
            //ticket.Dispose();
            return ticket;
        }


    }

    public static Bitmap generateStreifenticket(string person, string price, string special, string printerType)
    {
        DateTime today = DateTime.Now;
        string date = today.ToString("dd.MM.yyyy");
        if (special == "Kein Zusatzangebot")
        {
            special = "";
        }
        else
        {

        }

        if (printerType == "mobile_printer")
        {
            //Orte der verschiedenen Textboxen auf dem Ticket:
            //PointF logoLocation = new PointF(170, 10);
            //PointF typeLocation = new PointF(215, 45);
            //PointF personLocation = new PointF(225, 90);
            PointF logoLocation = new PointF(170, 10);
            Point StartLine = new Point(50, 60);
            Point EndLine = new Point(550, 60);
            PointF ticketTypeLocation = new PointF(80, 75);
            PointF dateLocation = new PointF(380, 75);
            PointF personLocation = new PointF(80, 115);
            PointF specialLocation = new PointF(310, 150);

            Point StartLine1 = new Point(0, 190);
            Point EndLine1 = new Point(720, 190);
            PointF EightLocation = new PointF(20, 220);

            Point StartLine2 = new Point(0, 280);
            Point EndLine2 = new Point(720, 280);
            PointF SevenLocation = new PointF(20, 310);

            Point StartLine3 = new Point(0, 370);
            Point EndLine3 = new Point(720, 370);
            PointF SixLocation = new PointF(20, 400);

            Point StartLine4 = new Point(0, 460);
            Point EndLine4 = new Point(720, 460);
            PointF FiveLocation = new PointF(20, 490);

            Point StartLine5 = new Point(0, 550);
            Point EndLine5 = new Point(720, 550);
            PointF FourLocation = new PointF(20, 580);

            Point StartLine6 = new Point(0, 640);
            Point EndLine6 = new Point(720, 640);
            PointF ThreeLocation = new PointF(20, 670);

            Point StartLine7 = new Point(0, 730);
            Point EndLine7 = new Point(720, 730);
            PointF TwoLocation = new PointF(20, 760);

            Point StartLine8 = new Point(0, 820);
            Point EndLine8 = new Point(720, 820);
            PointF OneLocation = new PointF(20, 850);

            Point StartLine9 = new Point(0, 910);
            Point EndLine9 = new Point(720, 910);

            PointF totalLocation = new PointF(50, 1040);
            PointF priceLocation = new PointF(400, 1040);

            PointF instructionLocation1 = new PointF(95, 1120);
            PointF instructionLocation2 = new PointF(55, 1146);




            Bitmap tempBmp = new Bitmap(720, 1280);

            using (Graphics g = Graphics.FromImage(tempBmp))
            {

                g.Clear(Color.White);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine1, EndLine1);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine2, EndLine2);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine3, EndLine3);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine4, EndLine4);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine5, EndLine5);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine6, EndLine6);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine7, EndLine7);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine8, EndLine8);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine9, EndLine9);

                using (Font arialFont = new Font("Arial", 30, FontStyle.Bold))
                {
                    g.DrawString("Cloud4all TVM", arialFont, Brushes.Black, logoLocation);
                }

                g.DrawLine(new Pen(Brushes.Black, 5), StartLine, EndLine);

                g.DrawLine(new Pen(Brushes.Black, 5), StartLine1, EndLine1);

                using (Font arialFont = new Font("Arial", 20, FontStyle.Bold))
                {
                    g.DrawString("Streifenticket", arialFont, Brushes.Black, ticketTypeLocation);
                    g.DrawString(date, arialFont, Brushes.Black, dateLocation);
                }

                using (Font arialFont = new Font("Arial", 20, FontStyle.Regular))
                {
                    g.DrawString(person, arialFont, Brushes.Black, personLocation);
                    g.DrawString(special, arialFont, Brushes.Black, specialLocation);
                }
                using (Font arialFont = new Font("Arial", 30, FontStyle.Bold))
                {

                    g.DrawString("1", arialFont, Brushes.Black, OneLocation);
                    g.DrawString("2", arialFont, Brushes.Black, TwoLocation);
                    g.DrawString("3", arialFont, Brushes.Black, ThreeLocation);
                    g.DrawString("4", arialFont, Brushes.Black, FourLocation);
                    g.DrawString("5", arialFont, Brushes.Black, FiveLocation);
                    g.DrawString("6", arialFont, Brushes.Black, SixLocation);
                    g.DrawString("7", arialFont, Brushes.Black, SevenLocation);
                    g.DrawString("8", arialFont, Brushes.Black, EightLocation);
                }

                using (Font arialFont = new Font("Arial", 25, FontStyle.Regular))
                {
                    g.DrawString("Summe:", arialFont, Brushes.Black, totalLocation);
                    g.DrawString(price, arialFont, Brushes.Black, priceLocation);
                }

                using (Font arialFont = new Font("Arial", 15, FontStyle.Bold))
                {
                    g.DrawString("Bitte stempeln Sie pro Zone einen Streifen.", arialFont, Brushes.Black, instructionLocation1);
                    g.DrawString("Ab dem Zeitpunkt des Stempelns für 2 Stunden gültig.", arialFont, Brushes.Black, instructionLocation2);

                }
            }
            //Farbtiefe auf 1 reduzieren:
            Bitmap ticket = tempBmp.Clone(new Rectangle(0, 0, tempBmp.Width, tempBmp.Height), PixelFormat.Format1bppIndexed);

            //ticket.Save(imageFilePath,System.Drawing.Imaging.ImageFormat.Bmp);
            //ticket.Dispose();
            return ticket;
        }
        else
        {
            //Orte der verschiedenen Textboxen auf dem Ticket:
            PointF logoLocation = new PointF(170, 10);
            PointF typeLocation = new PointF(215, 45);
            PointF personLocation = new PointF(225, 90);

            Point StartLine1 = new Point(0, 160);
            Point EndLine1 = new Point(720, 160);
            PointF EightLocation = new PointF(20, 190);

            Point StartLine2 = new Point(0, 250);
            Point EndLine2 = new Point(720, 250);
            PointF SevenLocation = new PointF(20, 280);

            Point StartLine3 = new Point(0, 340);
            Point EndLine3 = new Point(720, 340);
            PointF SixLocation = new PointF(20, 370);

            Point StartLine4 = new Point(0, 430);
            Point EndLine4 = new Point(720, 430);
            PointF FiveLocation = new PointF(20, 460);

            Point StartLine5 = new Point(0, 520);
            Point EndLine5 = new Point(720, 520);
            PointF FourLocation = new PointF(20, 550);

            Point StartLine6 = new Point(0, 610);
            Point EndLine6 = new Point(720, 610);
            PointF ThreeLocation = new PointF(20, 640);

            Point StartLine7 = new Point(0, 700);
            Point EndLine7 = new Point(720, 700);
            PointF TwoLocation = new PointF(20, 730);

            Point StartLine8 = new Point(0, 790);
            Point EndLine8 = new Point(720, 790);
            PointF OneLocation = new PointF(20, 820);

            Point StartLine9 = new Point(0, 880);
            Point EndLine9 = new Point(720, 880);

            PointF instructionLocation1 = new PointF(95, 1024);
            PointF instructionLocation2 = new PointF(55, 1048);
            PointF dateLocation = new PointF(275, 1080);



            Bitmap tempBmp = new Bitmap(720, 1200);

            using (Graphics g = Graphics.FromImage(tempBmp))
            {

                g.Clear(Color.White);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine1, EndLine1);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine2, EndLine2);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine3, EndLine3);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine4, EndLine4);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine5, EndLine5);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine6, EndLine6);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine7, EndLine7);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine8, EndLine8);
                g.DrawLine(new Pen(Brushes.Black, 5), StartLine9, EndLine9);

                using (Font arialFont = new Font("Arial", 30, FontStyle.Bold))
                {

                    g.DrawString("Cloud4all TVM", arialFont, Brushes.Black, logoLocation);
                    g.DrawString("1", arialFont, Brushes.Black, OneLocation);
                    g.DrawString("2", arialFont, Brushes.Black, TwoLocation);
                    g.DrawString("3", arialFont, Brushes.Black, ThreeLocation);
                    g.DrawString("4", arialFont, Brushes.Black, FourLocation);
                    g.DrawString("5", arialFont, Brushes.Black, FiveLocation);
                    g.DrawString("6", arialFont, Brushes.Black, SixLocation);
                    g.DrawString("7", arialFont, Brushes.Black, SevenLocation);
                    g.DrawString("8", arialFont, Brushes.Black, EightLocation);
                }
                using (Font arialFont = new Font("Arial", 25, FontStyle.Bold))
                {
                    g.DrawString("Streifenticket", arialFont, Brushes.Black, typeLocation);
                }
                using (Font arialFont = new Font("Arial", 20, FontStyle.Bold))
                {
                    g.DrawString(person, arialFont, Brushes.Black, personLocation);
                }

                using (Font arialFont = new Font("Arial", 15, FontStyle.Bold))
                {
                    g.DrawString("Bitte stempeln Sie pro Zone einen Streifen.", arialFont, Brushes.Black, instructionLocation1);
                    g.DrawString("Ab dem Zeitpunkt des Stempelns für 2 Stunden gültig.", arialFont, Brushes.Black, instructionLocation2);
                    g.DrawString(date, arialFont, Brushes.Black, dateLocation);
                }
            }
            //Farbtiefe auf 1 reduzieren:
            Bitmap ticket = tempBmp.Clone(new Rectangle(0, 0, tempBmp.Width, tempBmp.Height), PixelFormat.Format1bppIndexed);

            //ticket.Save(imageFilePath,System.Drawing.Imaging.ImageFormat.Bmp);
            //ticket.Dispose();
            return ticket;
        }




    }

    private static Bitmap ResizePicByWidth(Image sourceImage, double newWidth)
    {
        double sizeFactor = newWidth / sourceImage.Width;
        double newHeigth = sizeFactor * sourceImage.Height;
        Bitmap newImage = new Bitmap((int)newWidth, (int)newHeigth);
        using (Graphics g = Graphics.FromImage(newImage))
        {
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //InterpolationMode.HighQualityBicubic;
            g.DrawImage(sourceImage, new Rectangle(0, 0, (int)newWidth, (int)newHeigth));
        }
        return newImage;
    }
}