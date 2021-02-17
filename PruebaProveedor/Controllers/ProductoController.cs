using Microsoft.AspNetCore.Mvc;
using PruebaProveedor.AccesoDatos.Data.Interfaces;
using PruebaProveedor.Modelos.ViewModels;
using PruebaProveedor.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaProveedor.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ProductoController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProductosVM productoVM = new ProductosVM()
            {
                Producto = new Productos(),
                ListaProveedores = this._contenedorTrabajo.Proveedor.GetListaProveedores()
            };
            return View(productoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductosVM productoVM)
        {
            if (ModelState.IsValid)
            {
                this._contenedorTrabajo.Producto.Add(productoVM.Producto);
                this._contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }

            productoVM.ListaProveedores = this._contenedorTrabajo.Proveedor.GetListaProveedores();
            return View(productoVM);
        }

        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Producto.GetAll(includeProperties: "IdProveedorNavigation") });
        }
        #endregion
    }
}
