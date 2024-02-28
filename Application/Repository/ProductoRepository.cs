using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
using Api.Repository; 
using Domain.Entities; 
using Domain.Interfaces; 
using Microsoft.EntityFrameworkCore; 
using Persistence.Data; 

namespace Application.Repository 
{ 
    public class ProductoRepository : GenericRepositoryString<Producto> , IProducto 
    { 
        public ConexusITContext _context { get; set; } 
        public ProductoRepository(ConexusITContext context) : base(context) 
        { 
            _context = context; 
        } 
    } 
} 
