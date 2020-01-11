using System;
using System.Collections.Generic;
using System.Text;

namespace MOME.GoogleMapDotNetExtension.DisntanceMatrix.Model
{
    internal class DistanceMatrixResponse
    {
        public string[] destination_addresses { get; set; }

        public string[] origin_addresses { get; set; }

        public Row[] rows { get; set; }

        public string status { get; set; }
    }

    internal class Row
    {
        public Element[] elements { get; set; }
    }

    internal class Element
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }

    internal class Distance : ElementItem
    {
    }

    internal class Duration : ElementItem
    {
    }

    internal class ElementItem
    {
        public string text { get; set; }
        public int value { get; set; }
    }
}
