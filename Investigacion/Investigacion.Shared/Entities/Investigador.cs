using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Investigacion.Shared.Entities
{
    public class Investigador
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Afiliacion { get; set; }

        [JsonIgnore]
        public ICollection<ParticipacionInvestigadoresProyectos>? Proyectos { get; set; }
    }
}
