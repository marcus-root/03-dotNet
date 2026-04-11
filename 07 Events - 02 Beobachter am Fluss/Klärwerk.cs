using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dotNet_07_Events_02_Beobachter_am_Fluss
{
    internal class Klärwerk : Beobachter
    {
        public Klärwerk(string name) : base(name)
        {
            _istAktiv = true;
            _minPegel = 3000;
            _maxPegel = 8000;
        }

        public override string ToString()
        {
            return $"Das Klärwerk {_name} stoppt die Einleitung bei Flusspegeln über {_maxPegel} oder unter {_minPegel}";
        }

        public override void Reaktion(object sender, FlussEventArgs e)
        {
            if (e.NeuerPegel < _minPegel || e.NeuerPegel > _maxPegel)
            {
                if (_istAktiv)
                {
                    Ausgabe("Wir stoppen die Einleitung!", e, ConsoleColor.Red);
                    _istAktiv = false;
                }
            }
            else
            {
                if (!_istAktiv)
                {
                    Ausgabe("Wir stoppen die Einleitung!", e, ConsoleColor.Green);
                    _istAktiv = true;
                }
            }
        }
    }
}
