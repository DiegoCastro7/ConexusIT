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
    public class EmisorRepository : GenericRepository<Emisor> , IEmisor 
    { 
        public ConexusITContext _context { get; set; } 
        public EmisorRepository(ConexusITContext context) : base(context) 
        { 
            _context = context; 
        } 
    } 
} 
