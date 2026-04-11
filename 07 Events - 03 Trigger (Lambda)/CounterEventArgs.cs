using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_07_Events_03_Trigger_Lambda
{
    internal class CounterEventArgs : EventArgs
    {
        int _alterStand;
        int _neuerStand;
        int _änderung;
        bool _clear;

        public CounterEventArgs(int änderung, int alt, bool clear)
        {
            if (!clear)
            {
                _alterStand = alt;
                _neuerStand = _alterStand + änderung;
                _änderung = änderung;
            }
            else
            {
                _alterStand = alt;
                _neuerStand = 0;
                _clear = true;
            }
        }

        public override string ToString()
        {
            if (!_clear) return $"Zähler | Alt: {_alterStand,4}  +  Änderung: {_änderung,4}  =  Neuer Stand {_neuerStand,4}";
            else return $"Zähler | Alt: {_alterStand,4}  |  zurückgesetzt.     Neuer Stand {_neuerStand,4}";
        }
    }
}
