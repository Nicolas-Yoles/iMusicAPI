using back_end.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace back_end.DTOs
{
    public class GeneroCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre no debe ser mayor a 10 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
    }
}
