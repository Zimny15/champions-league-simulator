using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_CL
{
    /// <summary>
    /// Class representing a championship bracket consisting of four groups
    /// </summary>
    public class ChampionshipBracket
    {
        /// <summary>
        /// Class fields representing each of the four groups
        /// </summary>
        public List<Club> grupaA = new List<Club>();
        public List<Club> grupaB = new List<Club>();
        public List<Club> grupaC = new List<Club>();
        public List<Club> grupaD = new List<Club>();

        /// <summary>
        /// Gets and sets properties
        /// </summary>
        internal List<Club> GrupaA { get => grupaA; set => grupaA = value; }
        internal List<Club> GrupaB { get => grupaB; set => grupaB = value; }
        internal List<Club> GrupaC { get => grupaC; set => grupaC = value; }
        internal List<Club> GrupaD { get => grupaD; set => grupaD = value; }
        
        /// <summary>
        /// Adds a team to group a 
        /// </summary>
        /// <param name="c">Club being added</param>
        public void AddToGroupA(Club c)
        {
            grupaA.Add(c);
        }

        /// <summary>
        /// Adds a team to group b 
        /// </summary>
        /// <param name="c">Club being added</param>
        public void AddToGroupB(Club c)
        {
            grupaB.Add(c);
        }

        /// <summary>
        /// Adds a team to group c 
        /// </summary>
        /// <param name="c">Club being added</param>
        public void AddToGroupC(Club c)
        {
            grupaC.Add(c);
        }

        /// <summary>
        /// Adds a team to group d 
        /// </summary>
        /// <param name="c">Club being added</param>
        public void AddToGroupD(Club c)
        {
            grupaD.Add(c);
        }

        /// <summary>
        /// Overrides the base ToString method of a class 
        /// </summary>
        /// <returns>A formatted string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("GROUP A:");
            foreach (Club c in GrupaA) { sb.AppendLine(c.ToString()); }
            sb.AppendLine("GROUP B:");
            foreach (Club c in GrupaB) { sb.AppendLine(c.ToString()); }
            sb.AppendLine("GROUP C:");
            foreach (Club c in GrupaC) { sb.AppendLine(c.ToString()); }
            sb.AppendLine("GROUP D:");
            foreach (Club c in GrupaD) { sb.AppendLine(c.ToString()); }
            return sb.ToString();
        }



    }
}
