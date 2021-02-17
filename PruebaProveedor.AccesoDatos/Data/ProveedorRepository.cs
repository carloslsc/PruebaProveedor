using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ProveedorRepository : IProveedorRepository
    {
        protected readonly DbContext _context;
        internal DbSet<Proveedores> _dbSet;

        public ProveedorRepository(DbContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<Proveedores>();
        }

        public IEnumerable<SelectListItem> GetListaProveedores()
        {
            return this._dbSet.Select(p => new SelectListItem()
            {
                Text = p.RazonSocial,
                Value = p.IdProveedor.ToString()
            });
        }

        public void Add(Proveedores proveedor)
        {
            this._dbSet.Add(proveedor);
        }

        public Proveedores Get(long id)
        {
            return this._dbSet.Find(id);
        }

        public IEnumerable<Proveedores> GetAll(Expression<Func<Proveedores, bool>> filter = null, Func<IQueryable<Proveedores>, IOrderedQueryable<Proveedores>> orderBy = null, string includeProperties = null)
        {
            IQueryable<Proveedores> query = this._dbSet;

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

        public Proveedores GetFirstOrDefault(Expression<Func<Proveedores, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<Proveedores> query = this._dbSet;

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

        public void Remove(int id)
        {
            Proveedores entityToRemove = this._dbSet.Find(id);
            Remove(entityToRemove);
        }

        public void Remove(Proveedores proveedor)
        {
            this._dbSet.Remove(proveedor);
        }

        public void Update(Proveedores proveedor)
        {
            var objProveedorDB = this._dbSet.FirstOrDefault(p => p.IdProveedor == proveedor.IdProveedor);
            objProveedorDB.RazonSocial = proveedor.RazonSocial;
            objProveedorDB.Rfc = proveedor.Rfc;

            this._context.SaveChanges();
        }
    }
}
