using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio7
{
    class Propiedad
    {
        string casa;
        long dpi;
        int cuota;

        public string Casa { get => casa; set => casa = value; }
        public long Dpi { get => dpi; set => dpi = value; }
        public int Cuota { get => cuota; set => cuota = value; }
    }
}
