using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_07_Events_02_Beobachter_am_Fluss
{
    internal abstract class Beobachter
    {
        protected String _name;
        protected int _minPegel;
        protected int _maxPegel;
        protected bool _istAktiv;

        public Beobachter(String name)
        {
            _name = $"{this.GetType().Name} {name}";
        }

        public abstract void Reaktion(object sender, FlussEventArgs e);

        protected void Ausgabe(String text, FlussEventArgs e, ConsoleColor farbe)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{e.Zeitpunkt}");
            Console.ResetColor();
            Console.Write($" | {_name.PadRight(18, '.')} : ");
            Console.ForegroundColor = farbe;
            Console.WriteLine($"{text}");
            Console.ResetColor();
        }
    }
}
