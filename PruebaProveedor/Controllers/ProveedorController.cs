using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaProveedor.AccesoDatos.Data;
using PruebaProveedor.AccesoDatos.Data.Interfaces;
using PruebaProveedor.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaProveedor.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly PruebaProveedoresContext _context;

        public ProveedorController(IContenedorTrabajo contenedorTrabajo, PruebaProveedoresContext context)
        {
            this._contenedorTrabajo = contenedorTrabajo;
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Proveedores proveedor)
        {
            if (ModelState.IsValid)
            {
                var proveedorCodigoExist = this._contenedorTrabajo.Proveedor.GetFirstOrDefault(p => p.Codigo == proveedor.Codigo);
                if (proveedorCodigoExist == null)
                {
                    this._contenedorTrabajo.Proveedor.Add(proveedor);
                    this._contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("codigo", "El código esta en uso");
                }
            }
            return View(proveedor);
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Proveedores proveedor = new Proveedores();
            proveedor = this._contenedorTrabajo.Proveedor.Get(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Proveedores proveedor)
        {
            if (ModelState.IsValid)
            {
                this._contenedorTrabajo.Proveedor.Update(proveedor);
                this._contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(proveedor);
        }

        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            var proveedores = this._context.Proveedores.FromSqlRaw<Proveedores>("SP_Obtener_Proveedores").ToList();
            return Json(new { data = proveedores });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = this._contenedorTrabajo.Proveedor.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando proveedor" });
            }

            this._contenedorTrabajo.Proveedor.Remove(objFromDb);
            this._contenedorTrabajo.Save();
            return Json(new { success = true, message = "Proveedor borrado correctamente" });
        }

        [HttpPost]
        public IActionResult VerificacionDelete(int id)
        {
            var objFromDb = this._contenedorTrabajo.Producto.GetFirstOrDefault(p => p.IdProveedor == id);

            if (objFromDb == null)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false});
        }
        #endregion
    }
}
