using System;
using System.Collections.Generic;
using System.Text;

namespace MOME.GoogleMapDotNetExtension.DisntanceMatrix.Exceptions
{
    internal class DistanceMatrixRequestExceptionFactory
    {
        private readonly Dictionary<string, string> _errorMessages = new Dictionary<string, string>()
        {
            { "INVALID_REQUEST", "Provided request was invalid" },
            { "MAX_ELEMENTS_EXCEEDED", @"The API key is missing or invalid.
                                        Billing has not been enabled on your account.
                                        A self-imposed usage cap has been exceeded.
                                        The provided method of payment is no longer valid (for example, a credit card has expired)." },
            { "OVER_QUERY_LIMIT", "The service has received too many requests from your application within the allowed time period." },
            { "REQUEST_DENIED", "The service denied use of the Distance Matrix service by your application." },
            { "UNKNOWN_ERROR", "A Distance Matrix request could not be processed due to a server error. The request may succeed if you try again." },

        };

        internal DistanceMatrixRequestException CreateException(string statusCode)
        {
            if (statusCode.ToUpper() == "OK")
            {
                return null;
            }

            _errorMessages.TryGetValue(statusCode, out var message);
            if (message == null)
            {
                message = "Unknown error.";
            }

            return new DistanceMatrixRequestException(message);
        }
    }
}
