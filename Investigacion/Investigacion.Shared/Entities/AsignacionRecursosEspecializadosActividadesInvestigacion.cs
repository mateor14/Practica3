using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Investigacion.Shared.Entities
{
    // Tabla Intermedia AsignacionRecursosEspecializadosActividadesInvestigacion
    public class AsignacionRecursosEspecializadosActividadesInvestigacion
    {
        [Key]
        public int ID_Asignacion { get; set; }
        public int ID_Actividad { get; set; }
        public int ID_RecursoEspecializado { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha_Entrega { get; set; }

        [ForeignKey("ID_Actividad")]
        public virtual ActividadInvestigacion ActividadInvestigacion { get; set; }
        [ForeignKey("ID_RecursoEspecializado")]
        public virtual RecursoEspecializado RecursoEspecializado { get; set; }
    }
}
