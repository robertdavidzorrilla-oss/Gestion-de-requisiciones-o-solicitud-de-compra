using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Patrones.Strategy
{
    public class PatronesStrategy
    {
        public interface TasaStrategy
        {
            int idTipoImpuesto { get; }
            string nombreEstrategia { get; }
            decimal CalcularImpuesto(decimal subtotal);
        }

        // ITBIS 18%
        public class TasaEstandarStrategy : TasaStrategy
        {
            public int idTipoImpuesto => 1;
            public string nombreEstrategia => "ITBIS 18%";
            public decimal CalcularImpuesto(decimal subtotal) => subtotal * 0.18m;
        }

        // Exento de Impuesto (0%)
        public class TasaExtentaStrategy : TasaStrategy
        {
            public int idTipoImpuesto => 2;
            public string nombreEstrategia => "Exento (0%)";
            public decimal CalcularImpuesto(decimal subtotal) => 0.00m;
        }

        // Tasa Reducida a 10%
        public class TasaaraeducidaStrategy : TasaStrategy
        {
            public int idTipoImpuesto => 3;
            public string nombreEstrategia => "Reducido (10%)";
            public decimal CalcularImpuesto(decimal subtotal) => subtotal * 0.10m;
        }

    }
}
