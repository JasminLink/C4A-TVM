using System;
using System.Collections.Generic;

using System.Text;
using System.Threading;

namespace Eventtest
{
    class Eventtest
    {
        static void Main(string[] args)
        {
            Sender sender = new Sender();
        }
    }
 
    public class Empfänger
    {
        public void EmpfangeDaten(object sender, DatenEventArgs e)
        {

            Console.WriteLine("Empfangen: " + e.Text);
        }
    }
 
    public class Sender
    {
        private delegate void SenderHandler(object sender, DatenEventArgs e);
        private event SenderHandler _meinEvent;
        private Empfänger _empfänger;
 
        public Sender()
        {
            _empfänger = new Empfänger();
            _meinEvent += new SenderHandler(_empfänger.EmpfangeDaten);


            long i = 0;
            while (i < 2000)
            {
                i++;
                Console.WriteLine(i);
            }

            RaiseEvent();
        }
 
 
        private void RaiseEvent()
        {
            for (int i = 1000; i < 10000; i = i+1000)
            {
                string time = string.Format("{0} Sekunden sind vergangen", i / 1000);
 
                if(_meinEvent != null)
                {
                    DatenEventArgs daten = new DatenEventArgs(time);
                    _meinEvent(this, daten);
                }
                 
                Thread.Sleep(i);
            }
        }
    }
 
    public class DatenEventArgs : EventArgs
    {
        public readonly string Text;
 
        public DatenEventArgs(string text)
        {
            Text = text;
        }
    }
}