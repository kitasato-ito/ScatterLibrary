using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.Exceptions
{
    [Serializable()]
    internal class CountOutOfRangeException : Exception
    {
        public CountOutOfRangeException() : base()
        {

        }
        public CountOutOfRangeException(string message) : base(message)
        {

        }

        public CountOutOfRangeException(string message, Exception inner) : base(message, inner)
        {

        }

        protected CountOutOfRangeException(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
