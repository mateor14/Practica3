using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Investigacion.Shared.Entities
{

    public class Publicacion
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autores { get; set; }
        public DateTime Fecha_Publicacion { get; set; }
        public int ID_Proyecto { get; set; }

        [ForeignKey("ID_Proyecto")]
        public virtual Proyecto? Proyecto { get; set; }
    }
}
