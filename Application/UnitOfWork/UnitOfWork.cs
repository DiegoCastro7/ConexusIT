using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;
namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ConexusITContext _context;
    public UnitOfWork(ConexusITContext context)
    {
        _context = context;
    }
    public void Dispose()
    {
        _context.Dispose();
    }
    private ICliente _clientes;
    private IDetalleFactura _detallefacturas;
    private IEmisor _emisors;
    private IFactura _facturas;
    private IProducto _productos;
    public ICliente Clientes {
        get
        {
            if(_clientes == null) 
            {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        }
    }
    public IDetalleFactura DetalleFacturas {
        get
        {
            if(_detallefacturas == null) 
            {
                _detallefacturas = new DetalleFacturaRepository(_context);
            }
            return _detallefacturas;
        }
    }
    public IEmisor Emisors {
        get
        {
            if(_emisors == null) 
            {
                _emisors = new EmisorRepository(_context);
            }
            return _emisors;
        }
    }
    public IFactura Facturas {
        get
        {
            if(_facturas == null) 
            {
                _facturas = new FacturaRepository(_context);
            }
            return _facturas;
        }
    }
    public IProducto Productos {
        get
        {
            if(_productos == null) 
            {
                _productos = new ProductoRepository(_context);
            }
            return _productos;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
