using System;
using Tournament.Nodes;
using Tournament.Team;

namespace Tournament.Rule
{
    public interface IRule
    {
        /// <summary>
        /// Determine if a game is able to run by check by doing
        /// multiple validations.
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>Return true if the game is ready to run, otherwise returns false.</returns>
        bool CanGameRun(INode game);
        /// <summary>
        /// Checks if the game is over by comparting teams 
        /// against the match's max score.
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>Returns true if game score is true, otherwise returns false</returns>
        bool IsGameOver(INode game);
        /// <summary>
        /// Fetch the Team of a specif result/posistion. 
        /// </summary>
        /// <param name="game">Game to check.</param>
        /// <param name="pos">The position. 1 = First place, 2 = second place, etc.</param>
        /// <returns>Returns the team. </returns>
        ITeam GetCompetitorPosition(INode game, int pos);
        /// <summary>
        /// Checks if game has the requiered number of competitors to start. 
        /// </summary>
        /// <param name="game">Game to check.</param>
        /// <returns>Return true if game is full, otherwise false. </returns>
        bool IsGameFull(INode game);
    }
}
