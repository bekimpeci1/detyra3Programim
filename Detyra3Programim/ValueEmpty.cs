using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detyra3Programim
{
    class ValueEmptyException : ApplicationException
    {
        public ValueEmptyException()
            : base("Ju lutem mos e leni fushen e zbrazet ")
        { }

        public ValueEmptyException(string message)
            : base(message)
        { }
        public ValueEmptyException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
