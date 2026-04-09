namespace dotNet_01_01_Person_Datum
{
    internal class SimpleDate
    {
        int _year;
        int _month;
        int _day;

        public SimpleDate()
        {
            _year = 1980;
            _month = 1;
            _day = 1;
        }

        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                if (value >= 1 && value <= 9999) _year = value;
                else throw new YearOutOfRangeException(value);
            }
        }
        public int Month
        {
            get
            {
                return _month;
            }
            set
            {
                if (value >= 1 && value <= 12) _month = value;
                else throw new MonthOutOfRangeException(value);
            }
        }
        public int Day
        {
            get
            {
                return _day;
            }
            set
            {
                if (value > 0 && value <= TageImMonat(_month)) _day = value;
                else throw new DayOfMonthException(value);
            }
        }

        private bool IstSchaltjahr(int jahr)
        {
            // vor 1582: alle jahre die durch 4 teillbar sind
            // nach 1582: "übliche Methode"
            if ((jahr < 1582 && jahr % 4 == 0) || (jahr >= 1582 && DateTime.IsLeapYear(jahr)))
            {
                return true;
            }
            else return false;
        }

        private int TageImMonat(int monat)
        {
            if (IstSchaltjahr(_year) && monat == 2) return 29; // Wenn Schaltjahr und Februar
            else
            {
                switch (monat)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12: return 31;
                    case 4:
                    case 6:
                    case 9:
                    case 11: return 30;
                    case 2: return 28;
                    default: return -1;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Day:D2}.{this.Month:D2}.{this.Year:D4}";
        }



    }
}
