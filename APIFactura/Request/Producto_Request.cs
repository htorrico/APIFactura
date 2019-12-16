using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFactura.Request
{
    public class Producto_Request
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
