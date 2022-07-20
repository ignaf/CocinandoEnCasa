using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.ViewModels
{
    public class RecetaViewModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public int TiempoCoccion { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Ingredientes { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public int IdTipoReceta { get; set; }
    }
}
