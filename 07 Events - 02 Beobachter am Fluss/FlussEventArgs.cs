using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_07_Events_02_Beobachter_am_Fluss
{
    internal class FlussEventArgs : EventArgs
    {
        String _name;
        int _alterPegel;
        int _neuerPegel;
        DateTime _zeitpunlt;

        public FlussEventArgs(String name, int alt, int neu)
        {
            _name = name;
            _alterPegel = alt;
            _neuerPegel = neu;
            _zeitpunlt = DateTime.Now;
        }

        public int AlterPegel
        {
            get
            {
                return _alterPegel;
            }
        }

        public int NeuerPegel
        {
            get
            {
                return _neuerPegel;
            }
        }

        public String Zeitpunkt
        {
            get
            {
                return _zeitpunlt.ToShortTimeString();
            }
        }

        public String Name
        {
            get
            {
                return _name;
            }
        }


    }
}
