using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaSystem.Models
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El cliente no puede estar vacio")]
        public int ClienteId { get; set; }
        public decimal SubTotal { get; set; }
        public float ITBIS { get; set; }
        [Required(ErrorMessage = "El total no puede estar vacio")]
        public decimal Total { get; set; }
        public virtual ICollection<VentasDetalles> Detalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            SubTotal = 0;
            ITBIS = 0;
            Total = 0;
            this.Detalle = new List<VentasDetalles>();
        }

        public void AgregarDetalle(int ID, int VentaId, int ProductoId, string Descripcion, int Precio, int Cantidad, int Importe)
        {
            this.Detalle.Add(new VentasDetalles(ID, VentaId, ProductoId, Descripcion, Precio, Cantidad, Importe));
        }
    }
}
