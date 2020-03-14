using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaSystem.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public Decimal Precio { get; set; }
        public DateTime Fecha { get; set; }

        public Productos()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            Precio = 0;
            Fecha = DateTime.Now;

        }
    }
}
