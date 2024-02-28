using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace API.Dtos; 
    public class DetalleFacturaDto : BaseDto
    { 
        public int IdFactura { get; set; }

        public string IdProducto { get; set; } = null!;

        public int Cantidad { get; set; }

        public decimal PrecioUnidad { get; set; }

        public decimal Subtotal { get; set; }
    } 
