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
    public class Vendedores : ControllerBase
    {
        private readonly ContextFactura _context;

        public Vendedores(ContextFactura context)
        {
            _context = context;
        }

        [Route("Get")]
        [HttpGet]
        public IEnumerable<Vendedor> Get()
        {
            return  _context.Vendedores.ToList();
        }


        [Route("Insert")]
        [HttpPost]
        public Vendedor Insert(Vendedor request)
        {
            _context.Vendedores.Add(request);
            _context.SaveChanges();
            return request;
        }
    }
}