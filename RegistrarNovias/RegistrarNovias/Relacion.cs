using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarNovias
{
    internal class Relacion
    {

        public int ID { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Estado { get; set; }
        public string Nacionalidad { get; set; }
        public string PaisOrigen { get; set; }
        public string TipoDocumentoNovio { get; set; }
        public int DocumentoNovio { get; set; }

    }
}
