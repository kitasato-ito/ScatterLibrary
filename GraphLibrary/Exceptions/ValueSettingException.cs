using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary
{
    [Serializable()]
    public class ValueSettingException : System.Exception
    {
        public ValueSettingException() : base()
        {
        }

        public ValueSettingException(string message): base(message)
        {

        }

        public ValueSettingException(string message, Exception inner): base(message, inner)
        {

        }

        protected ValueSettingException(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
