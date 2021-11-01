using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Inventáro.Models.Context
{
    public class MySQLContext: DbContext
    {

        public MySQLContext() { }


        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        
        
        
        
        public DbSet<Computador> Computadors { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Modelo> Modelos { get; set; }


        public DbSet <Equipamento> Equipamentos { get; set; }


        public DbSet<Setor> Setors { get; set; }

        public DbSet<Login> Logins { get; set; }
        
        
        
        
        
        
        
        
        
        



    }
}
