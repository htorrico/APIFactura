using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Infraestructure;
namespace Service
{
   public class ProductosService
    {
        private readonly ContextFactura _context;

        public ProductosService(ContextFactura context)
        {
            _context = new ContextFactura();
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
