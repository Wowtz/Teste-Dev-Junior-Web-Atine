using ApiCadastro.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadastro.Configuration
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StringConnection());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public string StringConnection()
        {
            string strConnection = "Server=WALT; Database=TesteCadastroCliente; Trusted_Connection=True;";
            return strConnection;
        }
    }
}
