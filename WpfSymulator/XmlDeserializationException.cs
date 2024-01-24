using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSymulator
{
    /// <summary>
    /// Exception thrown when deserialization from an xml file isnt successful
    /// </summary>
    public class XmlDeserializationException : Exception
    {
        /// <summary>
        /// Initialises an instance of the class
        /// </summary>
        public XmlDeserializationException() : base() { }
        /// <summary>
        /// Initialises an instance of the class and sets the parameter message
        /// </summary>
        /// <param name="message">Specifies what caused the exception to be thrown</param>
        public XmlDeserializationException(string message) : base(message) { }
        /// <summary>
        /// Initialises an instance of the class and sets parameters message and exception
        /// </summary>
        /// <param name="message">Specifies what caused the exception to be thrown</param>
        /// <param name="exception">Exception caught when deserialization fails</param>
        public XmlDeserializationException(string message, Exception exception) : base(message, exception) { }
    }
}
