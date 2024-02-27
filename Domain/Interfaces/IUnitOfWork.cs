using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

    public interface IUnitOfWork
{
        ICliente Clientes { get; }
        IDetalleFactura DetalleFacturas { get; }
        IEmisor Emisors { get; }
        IFactura Facturas { get; }
        IProducto Productos { get; }
        Task<int> SaveAsync();
}
