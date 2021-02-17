using Microsoft.EntityFrameworkCore;
using PruebaProveedor.AccesoDatos.Data.Interfaces;
using PruebaProveedor.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PruebaProveedor.AccesoDatos.Data
{
    public class ProductoRepository : IProductoRepository
    {
        protected readonly DbContext _context;
        internal DbSet<Productos> _dbSet;

        public ProductoRepository(DbContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<Productos>();
        }

        public void Add(Productos producto)
        {
            this._dbSet.Add(producto);
        }

        public Productos Get(long id)
        {
            return this._dbSet.Find(id);
        }

        public IEnumerable<Productos> GetAll(Expression<Func<Productos, bool>> filter = null, Func<IQueryable<Productos>, IOrderedQueryable<Productos>> orderBy = null, string includeProperties = null)
        {
            IQueryable<Productos> query = this._dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            
            //include properties separadas por comas
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public Productos GetFirstOrDefault(Expression<Func<Productos, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<Productos> query = this._dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //include properties separadas por comas
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }
    }
}
