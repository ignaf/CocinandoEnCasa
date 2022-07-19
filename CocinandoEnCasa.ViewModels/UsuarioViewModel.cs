using System;
using System.ComponentModel.DataAnnotations;

namespace CocinandoEnCasa.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="Campo obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Ingrese una dirección de Email válida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage ="Ingrese una contraseña válida")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Ingrese una contraseña válida")]
        [Compare("Password", ErrorMessage ="Las contraseñas no coinciden")]
        public string RepitePassword { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(1,2)]
        public int Perfil { get; set; }
    }
}
