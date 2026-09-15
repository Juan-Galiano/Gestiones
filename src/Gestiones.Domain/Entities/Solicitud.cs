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
            OperarioAsignado = empleado;
            Estado = EstadoSolicitud.Asignada;

           
        }
    }

}





