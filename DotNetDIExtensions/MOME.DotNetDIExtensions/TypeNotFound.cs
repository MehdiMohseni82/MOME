using System;

namespace MOME.DotNetDIExtensions
{
    public class TypeNotFound : Exception
    {
        public TypeNotFound(string message)
            : base(message)
        {

        }
    }
}
