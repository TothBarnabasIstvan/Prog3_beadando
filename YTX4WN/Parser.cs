using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTX4WN
{
    class Parser
    {
        public static Work WorkParse(string[] columns)
        {
            string munkaNeve = columns[0];
            int munkaIdo = int.Parse(columns[1]);
            int anyagkoltseg = int.Parse(columns[2]);

            return new Work(munkaNeve, munkaIdo, anyagkoltseg);
        }
    }
}
