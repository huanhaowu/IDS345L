using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Movimiento
    {

        public int ID{ get; set; }

        public string TipoDocumento { get; set; }

        public string Documento { get; set; }

        public decimal Monto { get; set; }

        public string DbCr{ get; set; }
    
        public int TipoTransacccion { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaTransaccion { get; set; } 

    }
}
