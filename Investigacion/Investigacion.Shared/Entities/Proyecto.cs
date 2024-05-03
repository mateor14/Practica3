using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Investigacion.Shared.Entities
{
    public class Proyecto
    {
 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin_Estimada { get; set; }

        [JsonIgnore]
        public ICollection<ParticipacionInvestigadoresProyectos>? Investigadores { get; set; }

        [JsonIgnore]
        public ICollection<ActividadInvestigacion>? Actividades { get; set; }

        [JsonIgnore]
        public ICollection<Publicacion>? Publicaciones { get; set; }
    }

}
