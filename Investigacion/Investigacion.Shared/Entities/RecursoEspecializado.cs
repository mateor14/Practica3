using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Investigacion.Shared.Entities
{
    public class RecursoEspecializado
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad_Disponible { get; set; }
        public string Proveedor { get; set; }
        public DateTime Fecha_Entrega_Estimada { get; set; }

        [JsonIgnore]
        public ICollection<AsignacionRecursosEspecializadosActividadesInvestigacion>? ActividadesInvestigacion { get; set; }
    }
}
