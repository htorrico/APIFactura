using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Common;
using Infraestructure;
namespace Service
{
   public class ProductosService
    {
        private readonly ContextFactura _context;

        public ProductosService()
        {
            _context = new ContextFactura();
        }


        public ResponseBase<Producto> GetFinal()
        {
            ResponseBase<Producto> response = new ResponseBase<Producto>();
            
            try
            {


                string errorFuncional = string.Empty;
                List<Producto> productos= _context.Productos.ToList();

                throw new Exception("Excepcion forzado");

                if (productos.Count()>1)                
                    errorFuncional = "Su consulta devulve demasiados resultados";

                if (errorFuncional!=string.Empty)
                {
                    List<string> FunctionalErrors = new List<string>();
                    FunctionalErrors.Add(errorFuncional);
                    response.FunctionalErrors = FunctionalErrors;
                }


                if (response.FunctionalErrors==null)
                {
                    response.Message = "OK";
                    response.IsResultList = true;
                }
                else
                {
                    response.Code = 201;
                    response.Message = "Leer Errores Funcionales";
                }
                
                return response;
            }
            catch (Exception ex) 
            {
                //Escribir Log                
                response.Message = "Por favor comuniquese con el administrador";
                response.TechnicalErrors = ex;                                
                return response;
            }
           
        }


        public IEnumerable<Producto> Get()
        {
            
            return _context.Productos.ToList();
        }
      
        public Producto Insert(Producto producto)
        {
            try
            {
                producto.Activo = true;
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return producto;
            }
            catch (Exception ex)
            {
                //Escribir Log
                //throw;
                return new Producto{ ProductoID = 0};
            }
           
        }
    }
}
