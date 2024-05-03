using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Investigacion.Shared.Entities;

namespace Investigacion.Shared.Entities
{
    public class ParticipacionInvestigadoresProyectos
    {
        [Key]
        public int ID_Asignacion { get; set; }

        public int ID_Investigador { get; set; }
        public int ID_Proyecto { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }

        [ForeignKey("ID_Investigador")]
        public Investigador Investigador { get; set; }
        [ForeignKey("ID_Proyecto")]
        public Proyecto Proyecto { get; set; }
    }
}
