using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaProveedor.Modelos.ViewModels
{
    public class ProductosVM
    {
        public Productos Producto { get; set; }

        public IEnumerable<SelectListItem> ListaProveedores { get; set; }
    }
}
