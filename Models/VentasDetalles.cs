using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaSystem.Models
{
    public class VentasDetalles
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public int Importe { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }
        [ForeignKey("VentaId")]
        public virtual Ventas Venta { get; set; }

        public VentasDetalles()
        {
            Id = 0;
            VentaId = 0;
            ClienteId = 0;
            ProductoId = 0;
            Descripcion = string.Empty;
            Precio = 0;
            Cantidad = 0;
            Importe = 0;
        }

        public VentasDetalles(int id, int ventaId, int productoId, string descripcion, int precio, int cantidad, int importe)
        {
            this.Id = id;
            this.VentaId = ventaId;
            this.ProductoId = productoId;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.Importe = importe;
        }
    }
}
