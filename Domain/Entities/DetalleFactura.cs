using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DetalleFactura : BaseEntity
    {

        public int IdFactura { get; set; }

        public string IdProducto { get; set; } = null!;

        public int Cantidad { get; set; }

        public decimal PrecioUnidad { get; set; }

        public decimal Subtotal { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; } = null!;

        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
