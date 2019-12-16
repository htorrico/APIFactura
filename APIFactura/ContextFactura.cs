using APIFactura.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFactura
{
    public class ContextFactura : DbContext
    {
        public ContextFactura(DbContextOptions options): base(options)
        {
        }

        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Detalle> Detalles { get; set; }


    }

}
