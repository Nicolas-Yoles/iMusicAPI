using back_end.Validaciones;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back_end.Entidades
{
    public class Genero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, ErrorMessage = "La cantidad maxima de caracteres debe ser igual a 10")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

    }
}
