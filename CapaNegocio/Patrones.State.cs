using CapaNegocio.Patrones.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Patrones.State
{
    public interface IEstadoRequisicion
    {
        int IdEstado { get; }
        string NombreEstado { get; }

        void EnviarARevision(RequisicionStateContext context);
        void Aprobar(RequisicionStateContext context);
        void Rechazar(RequisicionStateContext context);
        void Cancelar(RequisicionStateContext context);
    }

    // Contexto que gestiona el estado actual
    public class RequisicionStateContext
    {
        public int IdRequisicion { get; set; }
        public IEstadoRequisicion EstadoActual { get; set; }

        public RequisicionStateContext(int idRequisicion, int idEstado)
        {
            IdRequisicion = idRequisicion;
            EstadoActual = ObtenerInstanciaEstado(idEstado);
        }

        public static IEstadoRequisicion ObtenerInstanciaEstado(int idEstado)
        {
            return idEstado switch
            {
                1 => new EstadoCreada(),
                2 => new EstadoEnRevision(),
                3 => new EstadoAprobada(),
                4 => new EstadoRechazada(),
                5 => new EstadoCancelada(),
                _ => throw new Exception("Estado no reconocido.")
            };
        }

        public void EnviarARevision() => EstadoActual.EnviarARevision(this);
        public void Aprobar() => EstadoActual.Aprobar(this);
        public void Rechazar() => EstadoActual.Rechazar(this);
        public void Cancelar() => EstadoActual.Cancelar(this);
    }

    // Estado: Creada
    public class EstadoCreada : IEstadoRequisicion
    {
        public int IdEstado => 1;
        public string NombreEstado => "Creada";

        public void EnviarARevision(RequisicionStateContext context)
        {
            context.EstadoActual = new EstadoEnRevision();
        }

        public void Aprobar(RequisicionStateContext context)
        {
            throw new InvalidOperationException("Una requisición en estado 'Creada' no puede aprobarse directamente. Debe pasar primero a 'En Revisión'.");
        }

        public void Rechazar(RequisicionStateContext context)
        {
            throw new InvalidOperationException("Una requisición en estado 'Creada' no puede rechazarse directamente. Debe pasar primero a 'En Revisión'.");
        }

        public void Cancelar(RequisicionStateContext context)
        {
            context.EstadoActual = new EstadoCancelada();
        }
    }

    //  Estado: En Revisión
    public class EstadoEnRevision : IEstadoRequisicion
    {
        public int IdEstado => 2;
        public string NombreEstado => "En Revisión";

        public void EnviarARevision(RequisicionStateContext context)
        {
            throw new InvalidOperationException("La requisición ya se encuentra 'En Revisión'.");
        }

        public void Aprobar(RequisicionStateContext context)
        {
            context.EstadoActual = new EstadoAprobada();
        }

        public void Rechazar(RequisicionStateContext context)
        {
            context.EstadoActual = new EstadoRechazada();
        }

        public void Cancelar(RequisicionStateContext context)
        {
            context.EstadoActual = new EstadoCancelada();
        }
    }

    // Estado Final: Aprobada 
    public class EstadoAprobada : IEstadoRequisicion
    {
        public int IdEstado => 3;
        public string NombreEstado => "Aprobada";

        public void EnviarARevision(RequisicionStateContext context) => ThrowImmutableError();
        public void Aprobar(RequisicionStateContext context) => ThrowImmutableError();
        public void Rechazar(RequisicionStateContext context) => ThrowImmutableError();
        public void Cancelar(RequisicionStateContext context) => ThrowImmutableError();

        private void ThrowImmutableError()
        {
            throw new InvalidOperationException("No se permite modificar una requisición cuando su estado es 'Aprobada'.");
        }
    }

    // Estado Final: Rechazada
    public class EstadoRechazada : IEstadoRequisicion
    {
        public int IdEstado => 4;
        public string NombreEstado => "Rechazada";

        public void EnviarARevision(RequisicionStateContext context) => ThrowImmutableError();
        public void Aprobar(RequisicionStateContext context) => ThrowImmutableError();
        public void Rechazar(RequisicionStateContext context) => ThrowImmutableError();
        public void Cancelar(RequisicionStateContext context) => ThrowImmutableError();

        private void ThrowImmutableError()
        {
            throw new InvalidOperationException("No se permite modificar una requisición cuando su estado es 'Rechazada'.");
        }
    }

    // 5. Estado Final: Cancelada (Inmutable)
    public class EstadoCancelada : IEstadoRequisicion
    {
        public int IdEstado => 5;
        public string NombreEstado => "Cancelada";

        public void EnviarARevision(RequisicionStateContext context) => ThrowImmutableError();
        public void Aprobar(RequisicionStateContext context) => ThrowImmutableError();
        public void Rechazar(RequisicionStateContext context) => ThrowImmutableError();
        public void Cancelar(RequisicionStateContext context) => ThrowImmutableError();

        private void ThrowImmutableError()
        {
            throw new InvalidOperationException("No se permite modificar una requisición cuando su estado es 'Cancelada'.");
        }
    }
}
