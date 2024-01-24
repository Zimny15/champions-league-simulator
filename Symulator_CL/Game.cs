using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_CL
{
    /// <summary>
    /// Simulates a match being played between two clubs. Implements IDodajePunktyNarodowosci interface
    /// </summary>
    public class Game : Club , IDodajePunktyNarodowosci
    {
        /// <summary>
        /// Class fields that store number of goals of each team playing in the match, its winner and loser
        /// </summary>
        public int firstClubGoals;
        public int secondClubGoals;
        public Club winner = new Club();
        public Club loser = new Club(); 

        /// <summary>
        /// Gets and sets FirstClubGoals and SecondClubGoals properties
        /// </summary>
        public int FirstClubGoals { get => firstClubGoals; set => firstClubGoals = value; }
        public int SecondClubGoals { get => secondClubGoals; set => secondClubGoals = value; }

        /// <summary>
        /// A method of an implemented interface that adds points to a player's rating based on his nationality
        /// </summary>
        /// <param name="p">Player</param>
        public void DodajPunktyNarodowosci(Player p)
        {
            p.Rating += (p.Nationality == "Poland") ? 5 :
                        (p.Nationality == "France") ? 3 :
                        (p.Nationality == "Croatia") ? 2 :
                        (p.Nationality == "Argentina") ? 1 :
                        (p.Nationality == "Netherlands") ? 1 :
                        (p.Nationality == "Portugal") ? 1 :
                        (p.Nationality == "Germany") ? 1 : 0;
        }

        /// <summary>
        /// Method deciding the outcome of a match based on statistics of each team's chosen player
        /// </summary>
        /// <param name="c">List of clubs currently playing matches</param>
        /// <returns></returns>
        public Club playingMatch(List<Club> c)
        {
            if(c.Count == 2)
            {
                int punkty1 = 0;
                int punkty2 = 0;
                var club1 = c[0];
                var club2 = c[1];
                Player p1kopia = club1.Zawodnicy[0];
                Player p1 = (Player)p1kopia.Clone();
                Player p2 = club2.Zawodnicy[0];
                List<int> p1attributes = p1.PlayerAttributes();
                List<int> p2attributes = p2.PlayerAttributes();
                DodajPunktyNarodowosci(p1);
                DodajPunktyNarodowosci(p2);
                Random random = new Random();
                while (p1attributes.Count > 4 && p2attributes.Count > 4)
                {
                    int losStatystyki = random.Next(0, p1attributes.Count);
                    punkty1 += p1attributes[losStatystyki];
                    punkty2 += p2attributes[losStatystyki];
                    p1attributes.Remove(p1attributes[losStatystyki]);
                    p2attributes.Remove(p2attributes[losStatystyki]);
                }
                
                if (punkty1 >= punkty2)
                {
                    
                    winner = club1;
                    loser = club2;
                    return club1;
                }
                else 
                { 
                    
                    winner = club2;
                    loser = club1;
                    return club2;
                }
            }
            else { return null; }
        }
    }
}
