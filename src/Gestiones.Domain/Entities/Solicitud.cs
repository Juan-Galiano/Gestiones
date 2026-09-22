using Gestiones.Domain.Enums;

namespace Gestiones.Domain.Entities
{
    public class Solicitud
    {
        public int IdSolicitud { get; set; }
        public DateTime FechaCreacion { get; private set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public Cliente Cliente { get; set; }

        public EstadoSolicitud Estado { get; private set; }

        public Empleado? OperarioAsignado { get; private set; }



        public Solicitud(string titulo, string descripcion, Cliente cliente)
        {
            FechaCreacion = DateTime.Now;
            Titulo = titulo;
            Descripcion = descripcion;
            Cliente = cliente;
            Estado = EstadoSolicitud.Creada;
            OperarioAsignado = null;
        }


        public void AsignarOperario(Empleado empleado)
        {
            if (Estado == EstadoSolicitud.Resuelta ||
                Estado == EstadoSolicitud.Cerrada || Estado == EstadoSolicitud.Anulada)
            {
                throw new InvalidOperationException(
                   "No se puede asignar un operario a una solicitud resuelta, anulada o cerrada."
                );
            }

            if (OperarioAsignado != null)
            {
                throw new InvalidOperationException("La solicitud ya tiene un operario asignado.");
            }

            OperarioAsignado = empleado;
            Estado = EstadoSolicitud.Asignada;
        }

        public void ReasignarOperario(Empleado empleado)
        {
            if (Estado == EstadoSolicitud.Resuelta ||
                Estado == EstadoSolicitud.Cerrada || Estado == EstadoSolicitud.Anulada)
            {
                throw new InvalidOperationException(
                    "No se puede reasignar un operario a una solicitud resuelta, anulada o  cerrada."
                );
            }

            if (OperarioAsignado == null)
            {
                throw new InvalidOperationException("No se puede reasignar un operario porque no esta asignada a ninguno.");
            }

            OperarioAsignado = empleado;
        }


        public void Iniciar()
        {
            if (Estado != EstadoSolicitud.Asignada)
            {
                throw new InvalidOperationException(
                    "No se puede iniciar una solicitud que no esta Asignada."
                );
            }

            Estado = EstadoSolicitud.EnProceso;
        }


        public void Resolver()
        {
            if (Estado != EstadoSolicitud.EnProceso)
            {
                throw new InvalidOperationException(
                    "No se puede resolver una solicitud que no está en proceso."
                );
            }

            Estado = EstadoSolicitud.Resuelta;
        }

        public void Anular()
        {
            if (Estado != EstadoSolicitud.Creada &&
                Estado != EstadoSolicitud.Asignada)
            {
                throw new InvalidOperationException(
                    "No se puede anular una solicitud que no está en estado creada o asignada."
                );
            }

            Estado = EstadoSolicitud.Anulada;
        }



        public void Cerrar()
        {
            if (Estado != EstadoSolicitud.Resuelta)
            {
                throw new InvalidOperationException(
                    "No se puede cerrar una solicitud que no está resuelta."
                );
            }

            Estado = EstadoSolicitud.Cerrada;
        }
    }

}





