namespace MOME.GoogleMapDotNetExtension.DisntanceMatrix.Model
{
    public enum RequestStatus
    {
        /// <summary>
        /// Indicates the response contains a valid result
        /// </summary>
        Ok,

        /// <summary>
        /// Indicates that the origin and/or destination of this pairing could not be geocoded.
        /// </summary>
        NotFound,

        /// <summary>
        /// Indicates no route could be found between the origin and destination.
        /// </summary>
        ZeroResult,

        /// <summary>
        /// Indicates the requested route is too long and cannot be processed.
        /// </summary>
        MaxRouteLengthExceeded,

        /// <summary>
        /// Unknown
        /// </summary>
        UnKnown
    }
}
