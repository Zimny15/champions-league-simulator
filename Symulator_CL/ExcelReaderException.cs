using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symulator_CL
{
    /// <summary>
    /// Exception thrown when reading an xslx file isnt succesful
    /// </summary>
    public class ExcelReaderException : Exception
    {
        /// <summary>
        /// Initialises an instance of the class and sets the field error
        /// </summary>
        /// <param name="error">Specifies what causes the exception to be thrown</param>
        public ExcelReaderException(string error)
        {
            this.error = error;
        }
        /// <summary>
        /// /gets or sets a class field called error
        /// </summary>
        public string error {  get; set; }

    }
}
