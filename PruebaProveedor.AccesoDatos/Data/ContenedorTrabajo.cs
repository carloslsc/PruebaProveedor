using PruebaProveedor.AccesoDatos.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaProveedor.AccesoDatos.Data
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly PruebaProveedoresContext _db;
        public IProveedorRepository Proveedor { get; private set; }
        public IProductoRepository Producto { get; private set; }

        public ContenedorTrabajo(PruebaProveedoresContext db)
        {
            this._db = db;
            this.Proveedor = new ProveedorRepository(this._db);
            this.Producto = new ProductoRepository(this._db);
        }

        public void Dispose()
        {
            this._db.Dispose();
        }

        public void Save()
        {
            this._db.SaveChanges();
        }
    }
}
