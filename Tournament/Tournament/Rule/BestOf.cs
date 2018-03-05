using System;
using System.Collections.Generic;
using System.Linq;
using Tournament.Nodes;
using Tournament.Team;

namespace Tournament.Rule
{
    public class BestOf : IRule
    {
        private int BestOfFirstTo;
        public BestOf( int numberOfGames = 3 )
        {
            
            BestOfFirstTo = (int)Math.Floor((float)numberOfGames/2.0f);
        }

        public bool CanGameRun(INode game)
        {
            return IsGameFull(game) && !IsGameOver(game);
        }

        public ITeam GetCompetitorPosition(INode game, int pos)
        {
            ITeam team = DummyTeamCreator.DummyTeamInstance;

            if ( IsGameOver(game) )
            {
                List <CompetitorData> temp = ((MatchNode)game).GetBattleResult();
                temp = temp.OrderByDescending(br => br.GetScore()).ToList();
                
                team = temp[pos - 1].GetTeam();

            }

            return team;
        }

        public bool IsGameFull(INode game )
        { 
            int numberofCompetitors = game.GetNumberOfCompeditors();

            return numberofCompetitors == 2; 
                  
        }

        public bool IsGameOver(INode game)
        {
            bool output = false; 
            List<CompetitorData> compData = ((MatchNode)game).GetBattleResult();

            foreach (var battleData in compData)
            {
                if (battleData.GetScore() >= BestOfFirstTo )
                {
                    output = true;
                    break;
                }
            }

            return output; 
        }


    }
}
