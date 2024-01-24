using Symulator_CL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSymulator
{
    /// <summary>
    /// Class representing a default player profile
    /// </summary>
    public class DefaultPlayerProfile : PlayerProfile
    {
        /// <summary>
        /// Creates an instance of the class and sets the isDefault parameter to true
        /// </summary>
        public DefaultPlayerProfile() : base() { isDefault = true; }
        /// <summary>
        /// Creates an instance of the class, sets its name parameter and sets the isDefault parameter to true
        /// </summary>
        /// <param name="name">Name of a player profile</param>
        public DefaultPlayerProfile(string name) : base(name) { isDefault = true; }
    }
}
