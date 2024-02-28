using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto : BaseEntityString
    {

        public string DescripcionTexto { get; set; } = null!;

        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();
    }
}
