using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFactura.Model
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string RazonSocial { get; set; }
        public eTipoDocumento TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }

        public ICollection<Factura> Facturas { get; set; }
    }
    public enum eTipoDocumento
    {
        DNI=1,
        RUC=2,
        Pasaporte=3,
        CE=4
    }
}
