using PruebaProveedor.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PruebaProveedor.AccesoDatos.Data.Interfaces
{
    public interface IProductoRepository
    {
        Productos Get(long id);

        IEnumerable<Productos> GetAll(
            Expression<Func<Productos, bool>> filter = null,
            Func<IQueryable<Productos>, IOrderedQueryable<Productos>> orderBy = null,
            string includeProperties = null
            );


        Productos GetFirstOrDefault(
            Expression<Func<Productos, bool>> filter = null,
            string includeProperties = null
            );

        void Add(Productos producto);
    }
}
