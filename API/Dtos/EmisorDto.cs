using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace API.Dtos; 
    public class EmisorDto : BaseDtoString
    { 
        public string RazonSocial { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string? ComplementosDireccion { get; set; }
    } 
