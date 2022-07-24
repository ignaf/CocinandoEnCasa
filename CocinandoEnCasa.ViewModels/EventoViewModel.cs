using CocinandoEnCasa.Data.models;
using CocinandoEnCasa.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocinandoEnCasa.ViewModels
{
    public class EventoViewModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre excede el límite de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [ValidarFechaAttribute(ErrorMessage ="No se permiten fechas anteriores al día de hoy")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int CantidadComensales { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [MaxLength(50, ErrorMessage = "La ubicación excede el límite de 50 caracteres")]
        public string Ubicacion { get; set; }


        public string Foto { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public List<int> IdsRecetas { get; set; }
    }
}
