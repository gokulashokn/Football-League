using Football_League.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football_League.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Football_League.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> fbl_team { get; set; }
        public DbSet<PlayedMatch> fbl_playedmatch { get; set; }
        public AppDbContext(DbContextOptions options): base(options) {  }


    }

}
