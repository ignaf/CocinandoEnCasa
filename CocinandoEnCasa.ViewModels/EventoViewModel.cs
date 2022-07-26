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
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [MaxLength(50, ErrorMessage = "El nombre excede el límite de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una fecha")]
        [ValidarFecha(ErrorMessage ="La fecha debe ser posterior al día de hoy")]        
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe ingresar la cantidad de comensales")]        
        public int CantidadComensales { get; set; }

        [Required(ErrorMessage = "Debe ingresar una ubicación")]
        [MaxLength(50, ErrorMessage = "La ubicación excede el límite de 50 caracteres")]
        public string Ubicacion { get; set; }


        public string Foto { get; set; }

        [Required(ErrorMessage = "Debe ingresar un precio")]
        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage ="Ingrese un número mayor a cero(0)")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage ="Debe seleccionar al menos una(1) receta")]
        public string[] IdsRecetas { get; set; }

        

    }
}
