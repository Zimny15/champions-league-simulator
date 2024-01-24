using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_CL
{
    /// <summary>
    /// PlayerProfile class is an abstract class used to store data about a chosen player profile
    /// </summary>
    [Serializable]
    public abstract class PlayerProfile
    {
        /// <summary>
        /// Class fields storing parameters name, number of wins and losses and if a chosen player profile is default
        /// </summary>
        private string name;
        public int numberOfWins;
        public int numberOfLosses;
        public bool isDefault;

        /// <summary>
        /// Initializes an instance of the class
        /// </summary>
        public PlayerProfile() { }
        /// <summary>
        /// Initializes an instance of the class and sets the parameter name
        /// </summary>
        /// <param name="name">Name of a player profile</param>
        public PlayerProfile(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Gets or sets the name of a player profile
        /// </summary>
        public string Name { get => name; set => name = value; }

       
    }
}
