using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationEngine
{
    public class InvalidContentsException : Exception
    {
        public InvalidContentsException(string message) : base(message)
        {
        }
    }
}
