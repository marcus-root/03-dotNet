using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dotNet_07_Events_02_Beobachter_am_Fluss
{
    internal class Stadt : Beobachter
    {
        public Stadt(String name) : base(name)
        {
            _maxPegel = 8200;
            _istAktiv = false;
        }

        public override string ToString()
        {
            return $"Die Stadt {_name} errichtet ihre Wasserschutzwand bei Flusspegeln über {_maxPegel}";
        }

        public override void Reaktion(object sender, FlussEventArgs e)
        {
            if (e.NeuerPegel > _maxPegel)
            {
                if (!_istAktiv)
                {
                    Ausgabe("Wir errichten die Wasserschutzwand!", e, ConsoleColor.Red);
                    _istAktiv = true;
                }
            }
            else
            {
                if (_istAktiv)
                {
                    Ausgabe("Wir reißen die Wasserschutzwand wieder ab!", e, ConsoleColor.Green);
                    _istAktiv = false;
                }
            }
        }
    }
}
