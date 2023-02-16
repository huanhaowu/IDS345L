using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicaciónInfidelidades
{
    internal class Infidelidad
    {
        public int ID { get; set; }
        public string NombresAfectado { get; set; }
        public string ApellidosAfectado { get; set; }
        public string NombresInfiel { get; set; }
        public string ApellidosInfiel { get; set; }
        public string SexoAfectado { get; set; }
        public string SexoInfiel { get; set; }
        public DateTime FechaEvento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string EstadoPareja { get; set; }
        public bool EsLaPrimeraVez { get; set; }
    }
}
