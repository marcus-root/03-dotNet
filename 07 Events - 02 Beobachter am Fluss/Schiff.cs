using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dotNet_07_Events_02_Beobachter_am_Fluss
{
    internal class Schiff : Beobachter
    {
        public Schiff(String name) : base(name)
        {
            _minPegel = 250;
            _maxPegel = 8000;
            _istAktiv = true;
        }

        public override string ToString()
        {
            return $"Das Schiff mit dem Namen {_name} hält an, wenn der Wasserstand unter {_minPegel} fällt oder über {_maxPegel} steigt.";
        }

        public override void Reaktion(object sender, FlussEventArgs e)
        {
            if (e.NeuerPegel < 250 || e.NeuerPegel > 8000)
            {
                if (_istAktiv)
                {
                    Ausgabe("Wir müssen anhalten!", e, ConsoleColor.Red);
                    _istAktiv = false;
                }
            }
            else
            {
                if (!_istAktiv)
                {
                    Ausgabe("Wir können weiterfahren!", e, ConsoleColor.Green);
                    _istAktiv = true;
                }
            }
        }
    }
}
