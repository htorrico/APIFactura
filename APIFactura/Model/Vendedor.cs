using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFactura.Model
{
    public class Vendedor
    {
        public int VendedorID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public eTipoDocumento TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public bool Activo { get; set; }
        public ICollection<Factura> Facturas { get; set; }
    }
}
