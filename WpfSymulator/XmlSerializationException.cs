using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSymulator
{

    /// <summary>
    /// Exception thrown when serialization from an xml file isnt successful
    /// </summary>
    public class XmlSerializationException : Exception
    {

        /// <summary>
        /// Initialises an instance of the class
        /// </summary>
        public XmlSerializationException() : base() { }
        /// <summary>
        /// Initialises an instance of the class and sets the parameter message
        /// </summary>
        /// <param name="message">Specifies what caused the exception to be thrown</param>
        public XmlSerializationException(string message) : base(message) { }
        /// <summary>
        /// Initialises an instance of the class and sets parameters message and exception
        /// </summary>
        /// <param name="message">Specifies what caused the exception to be thrown</param>
        /// <param name="exception">Exception caught when serialization fails</param>
        public XmlSerializationException(string message, Exception exception) : base(message, exception) { }
    }
}
