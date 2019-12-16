using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFactura.Model
{
    public class Detalle
    {
        public int DetalleID { get; set; }



        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal SubTotal { get; set; }

        public decimal IGV { get; set; }

        public decimal Total { get; set; }

        public int FacturaID { get; set; }
        public virtual Factura Factura { get; set; }
        public int ProductoID { get; set; }
        public virtual Producto Producto { get; set; }

    }
}
