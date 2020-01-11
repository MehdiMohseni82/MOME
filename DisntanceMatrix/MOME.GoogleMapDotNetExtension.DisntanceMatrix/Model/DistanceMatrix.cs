using System;
using System.Collections.Generic;
using System.Text;

namespace MOME.GoogleMapDotNetExtension.DisntanceMatrix.Model
{
    public class DistanceMatrix
    {
        public string DestinationAddress
        {
            get;
            set;
        }

        public string OriginAddress
        {
            get;
            set;
        }

        public int? Disntance
        {
            get;
            set;
        }

        public TimeSpan? Duration
        {
            get;
            set;
        }

        public Unit Unit
        {
            get;
            set;
        }

        public RequestStatus Status
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"{nameof(DestinationAddress)}: {DestinationAddress}, {nameof(OriginAddress)}: {OriginAddress}, {nameof(Disntance)}: {Disntance}, {nameof(Duration)}: {Duration}, {nameof(Duration)}: {Duration}, {nameof(Unit)}: {Unit}, {nameof(Status)}: {Status}";
        }
    }
}
