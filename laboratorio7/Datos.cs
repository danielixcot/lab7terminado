using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio7
{
    class Dato
    {
        string nombre;
        string apellido;
        string casa;
        int cuota;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Casa { get => casa; set => casa = value; }
        public int Cuota { get => cuota; set => cuota = value; }
    }
}
