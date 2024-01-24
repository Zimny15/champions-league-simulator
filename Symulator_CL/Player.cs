using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_CL
{
    /// <summary>
    /// Class representing a football player. It implements IDodajePunktyNarodowosci, IComparable, ICloneable and IEquatable interfaces
    /// </summary>
    public class Player : IDodajePunktyNarodowosci , IComparable<Player> , ICloneable , IEquatable<Player>
    {
        /// <summary>
        /// Class fields representing a players name, surname, nationality and in-game statistics
        /// </summary>
        string name;
        string surname;
        int rating;
        string position;
        string nationality;
        string club;
        int pace;
        int shooting;
        int passing;
        int dribbling;
        int defending;
        int physicality;
        public List<int> attributes = new List<int>();
        /// <summary>
        /// Creates an instance of the class
        /// </summary>
        public Player()
        {

        }
        /// <summary>
        /// Sets the fields of a class instance
        /// </summary>
        /// <param name="name">Player's name</param>
        /// <param name="surname">Player's surname</param>
        /// <param name="rating">Player's overall rating</param>
        /// <param name="position">Player's position</param>
        /// <param name="nationality">Player's nationality</param>
        /// <param name="club">Name of a club which the player is a part of</param>
        /// <param name="pace">Player's pace statistic</param>
        /// <param name="shooting">Player's shooting statistic</param>
        /// <param name="passing">Player's passing statistic</param>
        /// <param name="dribbling">Player's dribbling statistic</param>
        /// <param name="defending">Player's defending statistic</param>
        /// <param name="physicality">Player's physicality statistic</param>
        public Player(string name, string surname, int rating, string position, string nationality, string club, int pace, int shooting, int passing, int dribbling, int defending, int physicality)
        {
            this.name = name;
            this.surname = surname;
            this.rating = rating;
            this.position = position;
            this.nationality = nationality;
            this.club = club;
            this.pace = pace;
            this.shooting = shooting;
            this.passing = passing;
            this.dribbling = dribbling;
            this.defending = defending;
            this.physicality = physicality;
        }
        /// <summary>
        /// Gets and sets each of the properties
        /// </summary>
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Rating { get => rating; set => rating = value; }
        public string Position { get => position; set => position = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public string Club { get => club; set => club = value; }
        public int Pace { get => pace; set => pace = value; }
        public int Shooting { get => shooting; set => shooting = value; }
        public int Passing { get => passing; set => passing = value; }
        public int Dribbling { get => dribbling; set => dribbling = value; }
        public int Defending { get => defending; set => defending = value; }
        public int Physicality { get => physicality; set => physicality = value; }

        /// <summary>
        /// Method adding in-game statistics of players to a list
        /// </summary>
        /// <returns>A list of a particular player's statistics</returns>
        public List<int> PlayerAttributes()
        {
            attributes.Add(Rating);
            attributes.Add(Pace);
            attributes.Add(Shooting);
            attributes.Add(Passing);
            attributes.Add(Dribbling);
            attributes.Add(Defending);
            attributes.Add(Physicality);
            return attributes;
        }
        /// <summary>
        /// Adds a set number to a player's overall rating based on his nationality
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
        /// Overrides the base ToString method of the class
        /// </summary>
        /// <returns>A formatted string</returns>
        public override string ToString()
        {
            return $"{Name} {Surname} \n";
        }
        /// <summary>
        /// Compares surname of two players
        /// </summary>
        /// <param name="other">Player to which we compare</param>
        /// <returns>result of the comparison</returns>
        public int CompareTo(Player other)
        {
            return surname.CompareTo(other.Surname);
        }
        /// <summary>
        /// Creates a deep copy of a player with all of its parameters
        /// </summary>
        /// <returns>A deep clone of player as a new object</returns>
        public object Clone()
        {
            return new Player(Name, Surname, Rating, Position, Nationality, Club, Pace, Shooting, Passing, Dribbling, Defending, Physicality);
        }
        /// <summary>
        /// Checks if surnames of players are the same
        /// </summary>
        /// <param name="other">Player which we compare to</param>
        /// <returns>Result of the comparison as a bool</returns>
        public bool Equals(Player? other) => surname.Equals(other.surname);
    }
}
