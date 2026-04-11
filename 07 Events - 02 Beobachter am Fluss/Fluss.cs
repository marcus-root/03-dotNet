using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_07_Events_02_Beobachter_am_Fluss
{
    internal class Fluss
    {
        String _name;
        int _wasserstand;

        public event EventHandler<FlussEventArgs> Pegeländerung;

        public Fluss(string name)
        {
            _name = name;
            //Wasserstand = 100;
        }

        public String Name
        {
            get
            {
                return _name;
            }
        }

        public int Wasserstand
        {
            get
            {
                return _wasserstand;
            }
            set
            {
                if (value >= 100 && value <= 10000)
                {
                    if (_wasserstand != value)
                    {
                        FlussEventArgs e = new FlussEventArgs(_name, _wasserstand, value);
                        PrintEvent(e);
                        _wasserstand = value;
                        Pegeländerung?.Invoke(this, e);
                    }
                }
                else throw new Exception("Ungültiger Wasserstand");
            }
        }

        public void PrintEvent(FlussEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{e.Zeitpunkt}");
            Console.ResetColor();
            Console.Write(" | ");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write($"Der Pegelstand des Flusses {e.Name} ändert sich von {e.AlterPegel} zu {e.NeuerPegel}");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
