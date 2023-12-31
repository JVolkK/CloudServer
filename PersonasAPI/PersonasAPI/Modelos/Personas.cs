﻿using System.ComponentModel.DataAnnotations;

namespace PersonasAPI.Modelos
{
    public class Personas
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set;}

        public string? Direccion { get; set; }

        public string? Email { get; set; }

    }
}
