using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Infraestructure;

namespace Service
{
    public class FacturasService
    {
        private readonly ContextFactura _context;

        public FacturasService()
        {
            _context = new ContextFactura();
        }


        public Factura Insert(Factura factura)
        {
            try
            {
                List<string> FunctionalErrors = new List<string>();

                //Valido lógica del producto
                foreach (var item in factura.Detalles)
                {
                    var producto=_context.Productos.Find(item.ProductoID);
                    if (producto.Precio > 10)
                        FunctionalErrors.Add("El precio es muy alto para esta tienda");
                }


                //Validar lógica del cliente
                var cliente = _context.Clientes.Find(factura.ClienteID);

                if (cliente.RazonSocial=="Hugo Torrico")
                    FunctionalErrors.Add("El cliente es moroso");





                factura.Activo = true;
                _context.Facturas.Add(factura);
                _context.SaveChanges();
                return factura;
            }
            catch (Exception ex)
            {
                //Escribir Log
                //throw;
                return new Factura { FacturaID = 0 };
            }

        }

    }
}
