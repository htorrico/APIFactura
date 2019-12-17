using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service;
using APIFactura.Request;
using APIFactura.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infraestructure;
using Common;
using AutoMapper;
using Domain;

namespace APIFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosService service;

        public ProductosController()
        {
            service = new ProductosService();
        }


        [Route("Get")]
        [HttpGet]
        public ResponseBase<Producto_Response2> Get()
        {

            var responseJSON = service.Get();
            var response = Mapper.Map<ResponseBase<Producto_Response2>>(responseJSON);
            return response;

        }

        [Route("GetById")]
        [HttpGet]
        public ResponseBase<Producto_Response2> GetById(int Id)
        {

            var responseJSON = service.GetById(Id);
            var response = Mapper.Map<ResponseBase<Producto_Response2>>(responseJSON);
            return response;
        }

        [Route("InsertOrUpdate")]
        [HttpPost]
        public ResponseBase<Producto_Response> InsertOrUpdate([FromBody] Producto_Request request)
        {

            var requestConvert = Mapper.Map<Producto>(request);
            var responseJSON = service.InsertOrUpdate(requestConvert, requestConvert.ProductoID);
            var response = Mapper.Map<ResponseBase<Producto_Response>>(responseJSON);
            return response;
        }


    }
}