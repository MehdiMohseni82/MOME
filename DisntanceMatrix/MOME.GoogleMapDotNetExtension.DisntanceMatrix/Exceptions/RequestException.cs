using System;
using System.Collections.Generic;
using System.Text;

namespace MOME.GoogleMapDotNetExtension.DisntanceMatrix.Exceptions
{
    public class DistanceMatrixRequestException : Exception
    {
        public DistanceMatrixRequestException(string message)
            : base(message: message)
        { 
        }
    }
}
