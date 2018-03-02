using System;
using System.Collections.Generic;
using Tournament.Rule;
using Tournament.Team;

namespace Tournament.Nodes
{

    public class MatchNode : INode
    {
        List<CompetitorData> MatchNodeBattleResult;
        List<FinalistData> MatchNodeFinalists;
        IRule MatchNodeRule; 

        public MatchNode()
        {
            MatchNodeBattleResult = new List<CompetitorData>();
            MatchNodeFinalists = new List<FinalistData>();
            MatchNodeRule = DummyRuleCreator.DummyRuleInstance; 
        }
        public MatchNode(IRule rule)
        {
            MatchNodeBattleResult = new List<CompetitorData>();
            MatchNodeFinalists = new List<FinalistData>();
            SetRule(rule);
        }

        public void GiveTeamOnePoint(ITeam team)
        {
            if (MatchNodeRule.CanGameRun(this))
            {

                foreach (var battleData in MatchNodeBattleResult)
                {
                    if (battleData.GetTeam().Equals(team))
                    {
                        battleData.IncrementScore();
                        break;
                    }
                }
            }
        }

        public List<CompetitorData> GetBattleResult()
        {
            return MatchNodeBattleResult;
        }

        public void SetRule(IRule rule)
        {
            MatchNodeRule = rule;
        }

        public ITeam GetCompeditor(MatchOutcome position)
        {
            return MatchNodeRule.GetCompetitorPosition(this, (int)position);
        }

        public List<ITeam> GetCompeditors()
        {
            //TODO AUTMAP
            List<ITeam> teams = new List<ITeam>();
            foreach (var battleData in MatchNodeBattleResult)
            {
                teams.Add(battleData.GetTeam()); 
            }

            return teams;
        }



        public int GetNumberOfCompeditors()
        {
            return MatchNodeBattleResult.Count;
        }

        public bool IsGameFinnished()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            MakeFinalistsToCompetitors();
        }

        public void AddFinalist(FinalistData finalist)
        {
            MatchNodeFinalists.Add(finalist);
        }

        public void AddFinalist(INode node, MatchOutcome pos)
        {
            MatchNodeFinalists.Add(new FinalistData(node, pos)); 
        }

        private bool IsTeamACompetitor(ITeam team)
        {
            bool output = false;
            foreach (var competitor in MatchNodeBattleResult)
            {

                if ( competitor.GetTeam().Equals(team) )
                {
                    output = true;
                    break;
                }
             
            }


            return output;
        }


        private void MakeFinalistsToCompetitors()
        {
            for (int i = 0; i < MatchNodeFinalists.Count; i++)
            {
                if( MatchNodeRule.IsGameFull(this))
                {
                    break;
                }


                FinalistData finalist = MatchNodeFinalists[i];

                ITeam compeditor = finalist.GetCompeditor();


                if (!compeditor.Equals(DummyTeamCreator.DummyTeamInstance))
                {
                    if (!IsTeamACompetitor(compeditor))
                    {
                        CompetitorData toAdd = new CompetitorData(compeditor);
                        MatchNodeBattleResult.Add(toAdd);
                    }
                }
            }
        }
    }
}
