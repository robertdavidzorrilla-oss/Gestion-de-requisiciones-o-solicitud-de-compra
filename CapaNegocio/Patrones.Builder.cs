
using System;
using System.Collections.Generic;
using System.Linq;


namespace CapaNegocio.Patrones.Builder
{

    //Patrones DTO para el reporte de requisición
    public class ReporteRequisicionDTO
    {
        public int IdRequisicion { get; set; }
        public string CodigoRequisicion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        public string PoliticaImpuesto { get; set; }
        public decimal SubtotalGeneral { get; set; }
        public decimal ImpuestoTotal { get; set; }
        public decimal TotalGeneral { get; set; }
        public List<ItemReporteDTO> Detalle { get; set; } = new List<ItemReporteDTO>();
    }

    public class ItemReporteDTO
    {
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubtotalLinea { get; set; }
    }

    public class ItemRequisicionDTO
    {
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubtotalLinea => Cantidad * PrecioUnitario;
    }

    // Entidad Requisición
    public class Requisicion
    {
        public string Codigo { get; set; }
        
        public TasaStrategy TaxStrategy { get; set; } 
        public List<ItemRequisicionDTO> Detalles { get; set; } = new List<ItemRequisicionDTO>();

        public decimal Subtotal => Detalles.Sum(d => d.SubtotalLinea);
        public decimal Impuesto => TaxStrategy != null ? TaxStrategy.CalcularImpuesto(Subtotal) : 0.00m;
        public decimal Total => Subtotal + Impuesto;
    }

    // Patrón Builder
    public class RequisicionBuilder
    {
        private readonly Requisicion _requisicion = new Requisicion();

        public RequisicionBuilder EstablecerEncabezado(string codigo, TasaStrategy taxStrategy)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new Exception("El código de requisición es obligatorio.");
            if (taxStrategy == null)
                throw new Exception("Debe seleccionar una política de impuestos.");

            _requisicion.Codigo = codigo;
            _requisicion.TaxStrategy = taxStrategy;
            return this;
        }

        public RequisicionBuilder AgregarItem(string nombreProducto, int cantidad, decimal precioUnitario)
        {
            if (string.IsNullOrWhiteSpace(nombreProducto))
                throw new Exception("El nombre del producto es obligatorio.");
            if (cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor a cero.");
            if (precioUnitario <= 0)
                throw new Exception("El precio unitario debe ser mayor a cero.");

            if (_requisicion.Detalles.Any(i => i.NombreProducto.Equals(nombreProducto.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception($"El producto '{nombreProducto}' ya existe en esta requisición.");
            }

            _requisicion.Detalles.Add(new ItemRequisicionDTO
            {
                NombreProducto = nombreProducto.Trim(),
                Cantidad = cantidad,
                PrecioUnitario = precioUnitario
            });

            return this;
        }

        public Requisicion Build()
        {
            if (_requisicion.Detalles.Count == 0)
            {
                throw new Exception("La requisición debe contener al menos un ítem para ser creada.");
            }

            return _requisicion;
        }

    }

    //Patrones Strategy para calcular el impuesto según la tasa seleccionada

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






