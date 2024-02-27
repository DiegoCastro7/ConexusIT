using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<DetalleFactura, DetalleFacturaDto>().ReverseMap();
            CreateMap<Emisor, EmisorDto>().ReverseMap();
            CreateMap<Factura, FacturaDto>().ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
        }
    }
}
