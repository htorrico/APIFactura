using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIFactura.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ContextFactura _context;

        public ClientesController(ContextFactura context)
        {
            _context = context;
        }

        [Route("Get")]
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return  _context.Clientes.ToList();
        }


        [Route("Insert")]
        [HttpPost]
        public Cliente Insert(Cliente request)
        {
            _context.Clientes.Add(request);
            _context.SaveChanges();
            return request;
        }
    }
}