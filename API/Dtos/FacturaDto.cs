using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace API.Dtos; 
    public class FacturaDto : BaseDto
    { 
        public string IdCliente { get; set; } = null!;

        public string IdEmisor { get; set; } = null!;

        public decimal? TotalFactura { get; set; }
    } 
