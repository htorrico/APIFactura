using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Common;
using Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ProductosService
    {

        
        public ResponseBase<Producto> Get()
        {
            ResponseBase<Producto> response;
            try
            {

               
                    using (var context = new ContextFactura())
                    {
                        IQueryable<Producto> query = context.Productos.Where(x=>x.Activo==true);
                        response = new UtilitariesResponse<Producto>().setResponseBaseForList(query);
                    }

                }
                catch (Exception e)
                {
                    response = new UtilitariesResponse<Producto>().setResponseBaseForException(e);
                }
                return response;

            

       }

        public ResponseBase<Producto> GetById(int? Id)
        {
           
            ResponseBase<Producto> response;
            try
            {
                using (var context = new ContextFactura())
                {
                    Producto producto = context.Productos.Find(Id);
                    response = new UtilitariesResponse<Producto>().setResponseBaseForObj(producto);

                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Producto>().setResponseBaseForException(e);                
            }

            return response;
        }

        public ResponseBase<Producto> InsertOrUpdate(Producto model, int? Id)
        {            
            ResponseBase<Producto> response = null;
            try
            {
                if (Id > 0)
                {
                    using (var context = new ContextFactura())
                    {
                        Producto Producto = context.Productos.Find(Id);
                        context.Entry(Producto).State = EntityState.Modified;
                        //Campos  modificar
                        Producto.Descripcion = model.Descripcion;
                        context.SaveChanges();
                        response = new UtilitariesResponse<Producto>().setResponseBaseForOK(model);
                    }
                }
                else
                {
                    using (var context = new ContextFactura())
                    {
                        model.Activo = true;
                        context.Productos.Add(model);
                        context.SaveChanges();
                        response = new UtilitariesResponse<Producto>().setResponseBaseForOK(model);
                    }
                }
            }
            catch (Exception e)
            {
                response = new UtilitariesResponse<Producto>().setResponseBaseForException(e);                
            }

            return response;
        }
    }
}
