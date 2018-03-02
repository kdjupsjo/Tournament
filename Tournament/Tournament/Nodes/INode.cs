using System;
using Tournament.Team;

namespace Tournament.Nodes
{
    public enum MatchOutcome
    {
        OneVsOneWinner = 1,
        OneVsOneLooser = 2

    }


    public interface INode
    {
        /// <summary>
        /// Checks if game is finished by calling the node specif set of rules. 
        /// </summary>
        /// <returns>Return true if game is finihed, otherwise false.  </returns>
        bool IsGameFinished();
        /// <summary>
        /// Return the competitor of specif posistion. If node is a leafnode, the same team
        /// will always be returned. 
        /// </summary>
        /// <param name="position">The team poistion/result </param>
        /// <returns>Returns the team. </returns>
        ITeam GetCompeditor(MatchOutcome position);
        /// <summary>
        /// Returns the number of compeditors of a game object.
        /// </summary>
        /// <returns>Return number in int. </returns>
        int GetNumberOfCompeditors();
        /// <summary>
        /// Updates the finalist into compeditors.
        /// </summary>
        void Update();
        /// <summary>
        /// Add finalist to node. 
        /// </summary>
        /// <param name="node">Node to add reference to</param>
        /// <param name="pos">"Position" of the node/match</param>
        void AddFinalist(INode node, MatchOutcome pos);
        bool IsGameActive();
        int GetNodeDepth();
    }
}
