using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaProveedor.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PruebaProveedor.AccesoDatos.Data.Interfaces
{
    public interface IProveedorRepository
    {
        IEnumerable<SelectListItem> GetListaProveedores();

        Proveedores Get(long id);

        IEnumerable<Proveedores> GetAll(
            Expression<Func<Proveedores, bool>> filter = null,
            Func<IQueryable<Proveedores>, IOrderedQueryable<Proveedores>> orderBy = null,
            string includeProperties = null
            );


        Proveedores GetFirstOrDefault(
            Expression<Func<Proveedores, bool>> filter = null,
            string includeProperties = null
            );

        void Add(Proveedores proveedor);

        void Remove(int id);

        void Remove(Proveedores proveedor);

        void Update(Proveedores proveedor);
    }
}
