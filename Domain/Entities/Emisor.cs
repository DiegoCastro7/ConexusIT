using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Emisor : BaseEntity
    {
        public string Identificacion { get; set; } = null!;

        public string RazonSocial { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string? ComplementosDireccion { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
