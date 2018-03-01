using System;
namespace Tournament.Team
{
    public class DummyTeam : ITeam
    {
        public DummyTeam()
        {
        }

        public string GetTeamName()
        {
            return "Dummy Team";
        }
    }


    public static class DummyTeamCreator
    {
        public static DummyTeam DummyTeamInstance = new DummyTeam();
    }
}
