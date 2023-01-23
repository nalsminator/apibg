using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibg._Data
{
    public class ObPago
    {
        public int CodigoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public string NombreCliente { get; set; }
        public object MaestroPagos { get; set; }
    }
}
