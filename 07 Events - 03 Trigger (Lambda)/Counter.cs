using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_07_Events_03_Trigger_Lambda
{
    internal class Counter
    {
        int _zählerstand;
        Func<int, bool> _bedingung;
        Action _aktion;

        public event EventHandler<CounterEventArgs> Zählerstandsänderung;

        public Counter(Func<int, bool> bedingung, Action aktion)
        {
            _zählerstand = 0;
            _bedingung = bedingung; // eine Bedingung für den Zählerstand
            _aktion = aktion; // die Aktion die ausgeführt werden soll wenn die Bedingung zutrifft
        }

        public void ZählerstandErhöhen(int x)
        {
            CounterEventArgs e = new CounterEventArgs(x, _zählerstand, false);  // EventArgs-Objekt erstellen
            _zählerstand += x; // Zählerstand erhöhen
            Zählerstandsänderung?.Invoke(this, e); // Subscriber des Events benachrichtigen falls welche vorhanden
            if (_bedingung(_zählerstand)) // Wenn die Bedingung für den Zählerstand erreicht ist
            {
                _aktion(); // die Aktion ausführen
            }
            else Console.WriteLine();
        }

        public void Clear()
        {
            CounterEventArgs e = new CounterEventArgs(0, _zählerstand, true);  // EventArgs-Objekt erstellen
            _zählerstand = 0;
            Zählerstandsänderung?.Invoke(this, e); // Subscriber des Events benachrichtigen falls welche vorhanden
        }
    }
}
