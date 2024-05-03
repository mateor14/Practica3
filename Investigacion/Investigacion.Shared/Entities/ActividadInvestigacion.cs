using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Investigacion.Shared.Entities
{
    public class ActividadInvestigacion
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin_Estimada { get; set; }
        public int ID_Proyecto { get; set; }

        [ForeignKey("ID_Proyecto")]
        public virtual Proyecto? Proyecto { get; set; }

        [JsonIgnore]
        public ICollection<AsignacionRecursosEspecializadosActividadesInvestigacion>? RecursosEspecializados { get; set; }
    }
}
