using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournament.Team;

namespace TournamentWeb.BLL
{
    public class PlayerBLL
    {
        public List<Player> players; 

        public PlayerBLL()
        {
            players = new List<Player>();
        }
        
        //TODO - Add Validate password
        public bool CreatePlayer(string userName, string password, string email)
        {
            var player = new Player
            {
                PlayerName = userName,
                PlayerEmail = email,
                PlayerPass = password
            };

            players.Add(player);

            return false; 
        }
        
        public List<Player> getPlayerList()
        {
            return players;
        }


    }
}