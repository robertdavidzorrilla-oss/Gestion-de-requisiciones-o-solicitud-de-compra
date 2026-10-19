using CapaNegocio.Patrones.Builder;
using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class RequisicionesN
    {
        private readonly RequisicionD _cdRequisicion = new RequisicionD();

        public bool GuardarRequisicion(Requisicion requisicion, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (requisicion == null)
            {
                mensajeError = "La requisición no se ha estructurado correctamente.";
                return false;
            }

            List<(string producto, int cantidad, decimal precio)> listaDetalles = new List<(string, int, decimal)>();

            foreach (var item in requisicion.Detalles)
            {
                listaDetalles.Add((item.NombreProducto, item.Cantidad, item.PrecioUnitario));
            }

            return _cdRequisicion.GuardarRequisicionCompleta(
                requisicion.Codigo,
                requisicion.TaxStrategy.idTipoImpuesto,
                requisicion.Subtotal,
                requisicion.Impuesto,
                requisicion.Total,
                listaDetalles,
                out mensajeError
            );
        }
    }
}
