using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_CL
{
    /// <summary>
    /// Class responsible for calculating the number of goals scored by teams engaged in a match. It implements the IComparable interface
    /// </summary>
    public class Results : IComparable
    {
        /// <summary>
        /// Class fields used to store the amount of goals scored by each teams
        /// </summary>
        public int wygrany;
        public int przegrany;

        /// <summary>
        /// Gets and sets properties WYgrany and Przegrany
        /// </summary>
        public int Wygrany { get => wygrany; set => wygrany = value; }
        public int Przegrany { get => przegrany; set => przegrany = value; }

        /// <summary>
        /// Method implemented from the IComparable interface used to compare the amount of goals of two teams
        /// </summary>
        /// <param name="obj">Loser of a match</param>
        /// <returns>Result of the comparison</returns>
        public int CompareTo(object? obj)
        {
            return Wygrany.CompareTo(Przegrany);
        }
        /// <summary>
        /// Method used to calculate each team's amount of goals
        /// </summary>
        public void LosowanieWynikow()
        {
            Random r = new Random();
            Wygrany = r.Next(0,5);
            Przegrany = r.Next(0,5);
            if (Przegrany > Wygrany)
            {
                int temp = Przegrany;
                Przegrany = Wygrany;
                Wygrany = temp;
            }
            if (Przegrany == Wygrany) 
            {
                Wygrany++;
            }


        }
    }
}
