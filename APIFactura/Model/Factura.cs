using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIFactura.Model
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public string Numero { get; set; }        
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IGV { get; set; }
        public bool Activo { get; set; }

        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }

        public  int VendedorID { get; set; }
        public virtual Vendedor Vendedor { get; set; }

        public virtual ICollection<Detalle> Detalles { get; set; }


    }
}
