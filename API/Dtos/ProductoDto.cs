using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 

namespace API.Dtos; 
    public class ProductoDto : BaseDtoString
    { 
        public string DescripcionTexto { get; set; } = null!;
    } 
