using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_CL
{
    /// <summary>
    /// Class used to read an xlsx file
    /// </summary>
    public class ExcelReaderInterop
    {

        /// <summary>
        /// A method used to read the "FIFA_Data2.xlsx" file, which contains names of football clubs, players and their stats
        /// </summary>
        /// <returns>List of clubs contained in a read xlsx file</returns>
        /// <exception cref="ExcelReaderException">Gets thrown when the reading of a file isn't successful</exception>
        public List<Club> ReadExcelPlayers()
        {
            
                Application excel = null;
                Workbook wb = null;

                try
                {
                    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string relativePath = Path.Combine("..", "..", "..", "..", "FIFA_Data2.xlsx");
                    string filePath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));

                    excel = new Application();
                    wb = excel.Workbooks.Open(filePath);
                    Worksheet ws = wb.Worksheets[1];

                    Microsoft.Office.Interop.Excel.Range cells = ws.UsedRange;
                    int rowCount = cells.Rows.Count;
                    int colCount = cells.Columns.Count;
                    List<Player> zawodnicy = new List<Player>();
                    List<Club> clubs = new List<Club>();

                    for (int i = 2; i <= rowCount; i++)
                    {
                        Player player = new Player
                        {
                            Name = cells[i, 1].Value2.ToString(),
                            Surname = cells[i, 2].Value2.ToString(),
                            Rating = Convert.ToInt32(cells[i, 3].Value2),
                            Position = cells[i, 4].Value2.ToString(),
                            Nationality = cells[i, 5].Value2.ToString(),
                            Club = cells[i, 6].Value2.ToString(),
                            Pace = Convert.ToInt32(cells[i, 7].Value2),
                            Shooting = Convert.ToInt32(cells[i, 8].Value2),
                            Passing = Convert.ToInt32(cells[i, 9].Value2),
                            Dribbling = Convert.ToInt32(cells[i, 10].Value2),
                            Defending = Convert.ToInt32(cells[i, 11].Value2),
                            Physicality = Convert.ToInt32(cells[i, 12].Value2)
                        };
                        zawodnicy.Add(player);

                        Club existingClub = clubs.Find(c => c.Nazwa == player.Club);
                        if (existingClub != null)
                        {
                            existingClub.AddPlayer(player);
                        }
                        else
                        {
                            Club newClub = new Club
                            {
                                Nazwa = player.Club.ToString(),
                            };
                            newClub.AddPlayer(player);
                            clubs.Add(newClub);
                        }
                    }

                    foreach (var club in clubs)
                    {
                        club.LosujGraczaZDruzyny();
                    }

                    return clubs;
                }
                catch (Exception ex)
                {
                    throw new ExcelReaderException("An error occured while reading an xlsx file!");
                }
                finally
                {
                    if (wb != null)
                        wb.Close();
                    if (excel != null)
                        excel.Quit();
                }
        }
        
    }
}
