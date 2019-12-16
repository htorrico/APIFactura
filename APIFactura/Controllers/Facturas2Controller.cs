using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIFactura;
using APIFactura.Model;

namespace APIFactura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly ContextFactura _context;

        public FacturasController(ContextFactura context)
        {
            _context = context;
        }

        // GET: api/Facturas
        [Route("GetFacturas")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas()
        {
            return await _context.Facturas.ToListAsync();
        }

        [Route("GetFactura")]
        // GET: api/Facturas/5
        //[HttpGet("{id}")]
        [HttpGet]
        public async Task<ActionResult<Factura>> GetFactura(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);

            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }



        // POST: api/Facturas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.

        [Route("PostFactura")]
        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFactura", new { id = factura.FacturaID }, factura);
        }


        [Route("InsertCalculo")]
        [HttpPost]
        public async Task<ActionResult<Factura>> InsertCalculo(Factura factura)
        {
            factura.IGV = factura.SubTotal * 0.19M;
            factura.Total = factura.SubTotal + factura.IGV;

            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFactura", new { id = factura.FacturaID }, factura);
        }


        [Route("Insert")]
        [HttpPost]
        public int Insert(Factura request)
        {
            _context.Facturas.Add(request);
            _context.SaveChanges();
            return request.FacturaID;
        }



        [Route("UpdateMonto")]
        [HttpPost]
        public async Task<ActionResult<Factura>> UpdateMonto(Factura request)
        {
            var factura = await _context.Facturas.Where(x => x.Numero == request.Numero).FirstOrDefaultAsync();

            factura.SubTotal = request.SubTotal;
            factura.IGV = request.SubTotal * 0.19M;
            factura.Total = factura.SubTotal + factura.IGV;
            _context.Entry(factura).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFactura", new { id = factura.FacturaID }, factura);
        }



        [Route("UpdateMontoNoTask")]
        [HttpPost]
        public Factura UpdateMontoNoTask(Factura request)
        {
            var factura =  _context.Facturas.Where(x => x.Numero == request.Numero).FirstOrDefault();

            factura.SubTotal = request.SubTotal;
            factura.IGV = request.SubTotal * 0.19M;
            factura.Total = factura.SubTotal + factura.IGV;
            _context.Entry(factura).State = EntityState.Modified;
             _context.SaveChangesAsync();

            return factura;
        }




        // PUT: api/Facturas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, Factura factura)
        {
            if (id != factura.FacturaID)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Facturas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Factura>> DeleteFactura(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();

            return factura;
        }

        private bool FacturaExists(int id)
        {
            return _context.Facturas.Any(e => e.FacturaID == id);
        }
    }
}
