using System;

namespace MOME.GoogleMapDotNetExtension.DisntanceMatrix.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new DistanceMatrixClient("[API KEY]");
            var result = a.RequestDistance(Model.Unit.Metric, "Residential building in Washington, D.C.", "416 Sid Snyder Ave SW");

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
