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
        [Required(ErrorMessage = "El nombre del cliente no puede estar vacío!")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El Email del cliente no puede esta vacío!")]
        [EmailAddress(ErrorMessage = "Email Invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La dirección del cliente no puede estar vacía!")]
        public string Direccion { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "El teléfono del cliente no puede estar vacía!")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Telefono Invalido")]
        public string Telefono { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "El Celular del cliente no puede estar vacío!")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Celular Invalido")]
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
