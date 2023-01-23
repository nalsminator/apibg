using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibg._Data
{
    public class DetalleDeuda
    {
        public int Gestion { get; set; }
        public string AbreviaturaConceptoPago { get; set; }
        public int Prioridad { get; set; }
        public int NroCuota { get; set; }
        public int MesPeriodo { get; set; }
        public int AnioPeriodo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CodigoMoneda { get; set; }
        public decimal MontoConcepto { get; set; } 
        public decimal MontoMulta { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal MontoNeto { get; set; }
        public object DatosAdicionales { get; set; }
    }
}
