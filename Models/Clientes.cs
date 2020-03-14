using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaSystem.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Fecha = DateTime.Now;
            Nombres = string.Empty;
            Email = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
        }
    }
}
