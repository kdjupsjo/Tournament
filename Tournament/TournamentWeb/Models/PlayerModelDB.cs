using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentWeb.Models
{
    public class PlayerModelDB
    {
        [Key]
        [Column(TypeName = "VARCHAR")]
        [StringLength(256)]
        public string PlayerName { get { return PlayerName; } set { PlayerName = value; } }
        public string PlayerPass { get { return PlayerPass; } set { PlayerPass = value; } }
        public string PlayerEmail { get { return PlayerEmail; } set { PlayerEmail = value; } }
    }
}