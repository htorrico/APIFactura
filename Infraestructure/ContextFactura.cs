using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure
{
    public class ContextFactura : DbContext
    {
      
        public ContextFactura(DbContextOptions options): base(options)
        {
        }

        public ContextFactura() : base() { }

        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Detalle> Detalles { get; set; }

        public IConfiguration Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            //var connectionString = Convert.ToString( Configuration.GetSection("ConnectionStrings")["Conexion"]);

            var connectionString = "Data Source=DESKTOP-F970KVM;Initial Catalog=FacturaDB;User ID=usrFactura;Password=123456;";

            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(config.SecondsTimeOutBD));
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(120));
            }
        }

    }

}
