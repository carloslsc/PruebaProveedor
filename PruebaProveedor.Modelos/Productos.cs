using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaProveedor.Modelos
{
    public partial class Productos
    {
        [Key]
        public long IdProducto { get; set; }
        [Required(ErrorMessage = "El proveedor es obligatorio")]
        public long IdProveedor { get; set; }
        [Required(ErrorMessage = "El código del producto es obligatorio.")]
        [DisplayName("Código")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "La descripción del producto es obligatorio")]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La Unidad del producto es obligatorio")]
        [DisplayName("Unidad")]
        public string Unidad { get; set; }
        [Required(ErrorMessage = "El costo del producto es obligatorio")]
        [DataType(DataType.Currency, ErrorMessage = "El costo debe estar escrito en formato de moneda")]
        [Column(TypeName = "decimal(11, 2)")]
        [DisplayName("Costo")]
        public decimal Costo { get; set; }
        public virtual Proveedores IdProveedorNavigation { get; set; }
    }
}
