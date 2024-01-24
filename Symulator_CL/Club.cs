using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_CL
{
    /// <summary>
    /// Class representing a football club
    /// </summary>
    public class Club 
    {
        /// <summary>
        /// Class fields containing a path to a club's crest, club's name and a list of its players 
        /// </summary>
        public string imageSource { get; set; }
        string nazwa;
        List<Player> zawodnicy;
        /// <summary>
        /// Creates an instance of the class ant initialises the field zawodnicy as an empty list
        /// </summary>
        public Club()
        {
            zawodnicy = new List<Player>();
        }
        /// <summary>
        /// Creates an instance of the class and sets its nazwa field 
        /// </summary>
        /// <param name="nazwa">Club's name</param>
        public Club(string nazwa)
        {
            this.nazwa = nazwa;
        }
        /// <summary>
        /// Sets zawodnicy field of an already existing class instance
        /// </summary>
        /// <param name="nazwa">Club's name</param>
        /// <param name="zawodnicy">List of the club's players</param>
        public Club(string nazwa, List<Player> zawodnicy) : this(nazwa)
        {
            this.zawodnicy = zawodnicy;
        }
        /// <summary>
        /// Gets and sets the property Nazwa
        /// </summary>
        public string Nazwa { get => nazwa; set => nazwa = value; }
        /// <summary>
        /// Gets and sets the property Zawodnicy
        /// </summary>
        public List<Player> Zawodnicy { get => zawodnicy; set => zawodnicy = value; }
        /// <summary>
        /// Method adding a player to a list of each club's players 
        /// </summary>
        /// <param name="player">Player's name</param>
        /// <exception cref="ArgumentException">Gets thrown when an added player isn't unique</exception>
        public void AddPlayer(Player player) 
        {
            if (zawodnicy.Any(existingPlayer => existingPlayer.Equals(player)))
            {
                throw new ArgumentException("One of the players has been added more than once!");
            }
            zawodnicy.Add(player);
        }
        /// <summary>
        /// Randomly chooses one of the two players from a club
        /// </summary>
        public void LosujGraczaZDruzyny()
        {
            zawodnicy.Sort();
            Random rnd = new Random();
            int index = rnd.Next(0, 2);
            zawodnicy.Remove(zawodnicy[index]);
        }
        /// <summary>
        /// Method adding an image source to an already existing class instance
        /// </summary>
        /// <param name="sourcePath"></param>
        public void DodajSourceImage(string sourcePath)
        {
            this.imageSource = sourcePath;
        }
        /// <summary>
        /// Overrides the default ToString method
        /// </summary>
        /// <returns>A formatted string</returns>
        public override string ToString() 
        {
            return $"{nazwa} {zawodnicy[0].ToString()}";
        }

    }
}
