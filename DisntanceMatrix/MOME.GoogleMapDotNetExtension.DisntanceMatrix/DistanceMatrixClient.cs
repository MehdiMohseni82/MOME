using MOME.GoogleMapDotNetExtension.DisntanceMatrix.Exceptions;
using MOME.GoogleMapDotNetExtension.DisntanceMatrix.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace MOME.GoogleMapDotNetExtension.DisntanceMatrix
{
    public class DistanceMatrixClient
    {
        public static readonly string apiUri = "https://maps.googleapis.com/maps/api/distancematrix/json?units={0}&origins={1}&destinations={2}&key={3}";
        public HttpClient _client;
        public string _apiKey;

        public DistanceMatrixClient(string apiKey)
        {
            _client = new HttpClient();
            _apiKey = apiKey;
        }

        public DistanceMatrix RequestDistance(Unit unit, string origin, string distance)
        {
            var requestUri = string.Format(apiUri, unit, origin, distance, _apiKey);
            var result = _client.GetStringAsync(requestUri).Result;
            var resultSt = new DistanceMatrixResponse();
            var resultObject = (DistanceMatrixResponse)JsonConvert.DeserializeObject(result, resultSt.GetType());

            var exception = new DistanceMatrixRequestExceptionFactory().CreateException(resultObject.status);
            if (exception != null)
            {
                throw exception;
            }

            return ConvertToDistanceMatrix(resultObject);
        }

        private DistanceMatrix ConvertToDistanceMatrix(DistanceMatrixResponse response)
        {
            var result = new DistanceMatrix
            {
                DestinationAddress = response.destination_addresses[0],
                OriginAddress = response.origin_addresses[0],
                Disntance = response.rows[0].elements[0].distance?.value,
                Duration = response.rows[0].elements[0].duration == null ? new TimeSpan() : new TimeSpan(days: 0, hours:0, minutes: 0, seconds: response.rows[0].elements[0].duration.value),
                Status = GetStatus(response.rows[0].elements[0].status)
            };

            return result;
        }

        private RequestStatus GetStatus(string status)
        {
            switch (status)
            {
                case "OK":
                    return RequestStatus.Ok;
                case "NOT_FOUND":
                    return RequestStatus.NotFound;
                case "ZERO_RESULTS":
                    return RequestStatus.ZeroResult;
                case "MAX_ROUTE_LENGTH_EXCEEDED":
                    return RequestStatus.MaxRouteLengthExceeded;
                default:
                    return RequestStatus.UnKnown;
            }
        }
    }
}
