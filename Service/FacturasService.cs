using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Domain;
using Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class FacturasService
    {
        public ResponseBase<Factura> Insert(Factura model)
        {
            ResponseBase<Factura> response = null;
            try
            {
                
                    using (var context = new ContextFactura())
                    {
                        model.Activo = true;
                        context.Facturas.Add(model);
                        context.SaveChanges();
                        response = new UtilitariesResponse<Factura>().setResponseBaseForOK(model);
                    }
                
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Factura>().setResponseBaseForException(e);
            }

            return response;
        }




    }
}
