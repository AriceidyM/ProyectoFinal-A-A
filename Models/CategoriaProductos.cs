using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaSystem.Models
{
    public class CategoriaProductos
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "El nombre no puede estar vacio")]
        public string Nombre { get; set; }

        public CategoriaProductos()
        {
            CategoriaId = 0;
            Nombre = string.Empty;
        }
    }
}
