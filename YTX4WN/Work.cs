using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTX4WN
{
    public class Work
    {
        public string MunkaNev { get; private set; }
        public int Munkaido { get; private set; }
        public int Anyagkoltseg { get; private set; }
        public int Oraber { get; private set; } = 15000;

        public Work(string munkaNev, int munkaido, int anyagkoltseg) 
        { 
            this.MunkaNev = munkaNev;
            this.Munkaido = munkaido;
            this.Anyagkoltseg = anyagkoltseg;
        }

        public int CalculateCost()
        {
            int cost = Munkaido * (Oraber / 60);
            return cost;
        }

        public int Minute
        {
            get
            {
                return Munkaido % 60;
            }
        }

        public int Hour => Munkaido / 60;

        public string HourMinute => Hour < 1 ? $"{Minute}p" : $"{Hour}ó {Minute}p";

    }
}
