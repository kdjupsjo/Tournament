using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Tournament.Team;
using TournamentWeb.Models;

namespace TournamentWeb.DAL.DBContext
{
    public class TournamentContext : DbContext
    {
        public TournamentContext(){
            Accounts.RemoveRange(Accounts);
            SaveChanges();
        }
        public DbSet<PlayerModelDB> Accounts { get; set; }
    }
}