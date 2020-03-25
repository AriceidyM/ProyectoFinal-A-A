using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaSystem.Models
{
    public class Entrada
    {
        [Key]
        public int EntradaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ProductoId { get; set; }
        [Range(minimum: 1, maximum: 1000000, ErrorMessage = "La cantidad debe ser mayor a cero")]
        public string Cantidad { get; set; }

        public Entrada()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            ProductoId = 0;
            Cantidad = string.Empty;
        }
    }
}
