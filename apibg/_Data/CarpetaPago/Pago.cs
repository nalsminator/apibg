using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibg._Data
{
    public class Pago
    {
        public int CodigoRespuesta { get; set; }
        public string MensajeRespuesta { get; set; }
        public string NroTransaccion { get; set; }
        public object DatosFacturaEmpresa { get; set; }
    }
}
