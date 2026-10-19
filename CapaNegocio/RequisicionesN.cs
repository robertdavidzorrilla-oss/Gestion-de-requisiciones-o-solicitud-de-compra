using CapaDatos;
using CapaNegocio.Patrones.Builder;
using CapaNegocio.Patrones.State;
using System;
using System.Collections.Generic;
using System.Data;

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

        public DataTable ObtenerRequisiciones()
        {
            return _cdRequisicion.ObtenerRequisiciones();
        }

        public bool TransicionarEstado(int idRequisicion, int idEstadoActual, string accion, out string mensajeError)
        {
            mensajeError = string.Empty;

            try
            {
                // Crear el contexto con el estado actual
                RequisicionStateContext contexto = new RequisicionStateContext(idRequisicion, idEstadoActual);

                // Ejecutar la acción solicitada usando el Patrón State 
                switch (accion.ToUpper())
                {
                    case "REVISION":
                        contexto.EnviarARevision();
                        break;
                    case "APROBAR":
                        contexto.Aprobar();
                        break;
                    case "RECHAZAR":
                        contexto.Rechazar();
                        break;
                    case "CANCELAR":
                        contexto.Cancelar();
                        break;
                    default:
                        mensajeError = "Acción de cambio de estado no reconocida.";
                        return false;
                }

                // Persistir en la base de datos con el nuevo ID de estado
                int nuevoIdEstado = contexto.EstadoActual.IdEstado;
                return _cdRequisicion.CambiarEstado(idRequisicion, nuevoIdEstado, out mensajeError);
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
                return false;
            }
        }

        //Metodo para obtener el reporte de requisiciones aprobadas
        public List<ReporteRequisicionDTO> ObtenerReporteAprobadas()
        {
            DataTable dt = _cdRequisicion.ObtenerReporteRequisicionesAprobadas();
            List<ReporteRequisicionDTO> listaReportes = new List<ReporteRequisicionDTO>();

            var grupos = dt.AsEnumerable().GroupBy(r => r.Field<int>("idRequisicion"));

            foreach (var grupo in grupos)
            {
                var primeraFila = grupo.First();
                var reporte = new ReporteRequisicionDTO
                {
                    IdRequisicion = primeraFila.Field<int>("idRequisicion"),
                    CodigoRequisicion = primeraFila.Field<string>("CodigoRequisicion"),
                    FechaCreacion = primeraFila.Field<DateTime>("FechaCreacion"),
                    Estado = primeraFila.Field<string>("Estado"),
                    PoliticaImpuesto = primeraFila.Field<string>("PoliticaImpuesto"),
                    SubtotalGeneral = primeraFila.Field<decimal>("SubtotalGeneral"),
                    ImpuestoTotal = primeraFila.Field<decimal>("ImpuestoTotal"),
                    TotalGeneral = primeraFila.Field<decimal>("TotalGeneral")
                };

                foreach (var fila in grupo)
                {
                    reporte.Detalle.Add(new ItemReporteDTO
                    {
                        NombreProducto = fila.Field<string>("nombreProducto"),
                        Cantidad = fila.Field<int>("Cantidad"),
                        PrecioUnitario = fila.Field<decimal>("PrecioUnitario"),
                        SubtotalLinea = fila.Field<decimal>("SubtotalLinea")
                    });
                }

                listaReportes.Add(reporte);
            }

            return listaReportes;
        }
    }
}
