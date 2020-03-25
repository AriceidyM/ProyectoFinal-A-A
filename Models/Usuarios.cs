using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaSystem.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "El campo Nombres obligatorio.")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo Nivel de usuario es obligatorio.")]
        public string NivelUsuario { get; set; }
        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "La Clave no puede estar vacia")]
        public string Clave { get; set; }
        public DateTime FechaIngreso { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            Email = string.Empty;
            NivelUsuario = string.Empty;
            Usuario = string.Empty;
            Clave = string.Empty;
            FechaIngreso = DateTime.Now;
        }
    }
}
