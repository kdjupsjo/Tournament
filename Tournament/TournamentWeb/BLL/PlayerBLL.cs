using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tournament.Team;

namespace TournamentWeb.BLL
{
    public class PlayerBLL
    {
        //TODO - Add Validate password

        public bool CreatePlayer(string userName, string password, string email)
        {
            var player = new Player
            {
                PlayerName = userName,
                PlayerEmail = email,
                PlayerPass = password
            };



            return false; 
        } 


    }
}