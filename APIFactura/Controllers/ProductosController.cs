﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service;
using APIFactura.Request;
using APIFactura.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infraestructure;

namespace APIFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosService service;

        public ProductosController(ContextFactura context)
        {
            //ProductosService _context
            service = new ProductosService(context);
        }

        [Route("Insert")]
        [HttpPost]
        public Producto_Response Insert(Producto_Request request)
        {
            //Pendiente Mapper

            Domain.Producto producto= service.Insert(new Domain.Producto
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,                
                Precio = request.Precio
            });            
            return new Producto_Response { ProductoID = producto.ProductoID };
        }


        [Route("Get")]
        [HttpGet]
        public IEnumerable<Producto_Response2> Get()
        {
            return service.Get().
                Select(x=> new Producto_Response2 { 
                                               ProductoID=x.ProductoID, 
                                               Nombre=x.Nombre}).ToList();
        }



    }
}