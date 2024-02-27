using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Factura : BaseEntity
    {
        public int IdFactura { get; set; }

        public string IdCliente { get; set; } = null!;

        public string IdEmisor { get; set; } = null!;

        public decimal? TotalFactura { get; set; }

        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

        public virtual Cliente IdClienteNavigation { get; set; } = null!;

        public virtual Emisor IdEmisorNavigation { get; set; } = null!;
    }
}
