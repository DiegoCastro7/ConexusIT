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
    public class FacturaRepository : GenericRepository<Factura> , IFactura 
    { 
        public ConexusITContext _context { get; set; } 
        public FacturaRepository(ConexusITContext context) : base(context) 
        { 
            _context = context; 
        } 
    } 
} 
