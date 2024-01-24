using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_CL
{
    /// <summary>
    /// An interface used to change properties of a player based on his nationality
    /// </summary>
    public interface IDodajePunktyNarodowosci
    {
        /// <summary>
        /// Adds points to a particular player based on what his nationality is
        /// </summary>
        /// <param name="p">Player</param>
        void DodajPunktyNarodowosci(Player p);
    }
}
