using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaProveedor.Modelos
{
    public partial class Proveedores
    {
        public Proveedores()
        {
            Productos = new HashSet<Productos>();
        }

        [Key]
        public long IdProveedor { get; set; }
        [Required(ErrorMessage = "El código del proveedor es obligatorio.")]
        [DisplayName("Código")]
        [Key]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "La razón social del proveedor es obligatorio")]
        [DisplayName("Razón Social")]
        public string RazonSocial { get; set; }
        [Required(ErrorMessage = "El RFC del proveedor es obligatorio.")]
        [RegularExpression(@"^[A-Z,Ñ,&]{4}[0-9]{2}[0-9][0-9][0-9][0-9][A-Z,0-9]?[0-9]?[0-9]?$", ErrorMessage = "El RFC debe estar compuesto por: (4 letras + 6 dígitos + 1 letra + 2 dígitos)")]
        [DisplayName("RFC")]
        public string Rfc { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
