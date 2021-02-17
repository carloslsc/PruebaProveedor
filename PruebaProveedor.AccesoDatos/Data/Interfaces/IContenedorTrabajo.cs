using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaProveedor.AccesoDatos.Data.Interfaces
{
    public interface IContenedorTrabajo : IDisposable
    {
        IProveedorRepository Proveedor { get; }

        IProductoRepository Producto { get; }

        void Save();
    }
}
