using GestionConf.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;
using System.Transactions;

namespace GestionConf.server.Data
{
    public class GestionConfDbContext : DbContext
    {

        public GestionConfDbContext(DbContextOptions<GestionConfDbContext> options) : base(options)
        {
        }


        public DbSet<Administrateur> Administrateurs { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Conférence> Conférences { get; set; }
        public DbSet<Entreprise> Entreprises { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Relecteur> Relecteurs { get; set; }
        public DbSet<Université> Universités { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
