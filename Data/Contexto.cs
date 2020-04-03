using FerreteriaSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaSystem.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<CategoriaProductos> Categorias { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Entradas> Entradas { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(@"Data Source= Database/FerreteriaDb.db");
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"Server= .\SQLEXPRESS; Database=FerreteriaDb; trusted_connection=true");
             base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server = tcp:ferreteriasystemdbserver.database.windows.net,1433; Initial Catalog = FerreteriaSystem_db; Persist Security Info = False; User ID = Ariceidy; Password =Ferreteria01; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }
    }
}
