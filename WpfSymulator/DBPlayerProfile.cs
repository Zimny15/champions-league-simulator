using Symulator_CL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSymulator
{
    /// <summary>
    /// Class representing a player profile stored in a database
    /// </summary>
    [Serializable]
    public class DBPlayerProfile : PlayerProfile
    {
        /// <summary>
        /// Creates an instance of the class and sets the isDefault parameter to false
        /// </summary>
        public DBPlayerProfile() : base() { isDefault = false; }
        /// <summary>
        /// Creates an instance of the class, sets its name parameter and sets the isDefault parameter to false
        /// </summary>
        /// <param name="name">Name of a player profile</param>
        public DBPlayerProfile(string name) : base(name) { isDefault = false; }
    }
}
