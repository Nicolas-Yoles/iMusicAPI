﻿using System.ComponentModel.DataAnnotations;

namespace back_end.Entidades
{
    public class Genero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, ErrorMessage = "La cantidad maxima de caracteres debe ser igual a 10")]
        public string Nombre { get; set; }

        //[Range(18,20)]
        //public int Edad { get; set; }

        //[CreditCard]
        //public string TarjetaDeCredito { get; set; }

        //[Url]
        //public string URL { get; set; }
    }
}
