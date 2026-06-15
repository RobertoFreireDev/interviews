using System;

namespace ComposingMethods.ReplaceMethodWithMethodObject
{
    public class EarthDistance
    {
        private Point PointA;
        private Point PointB;

        public EarthDistance(Point pointA, Point pointB)
        {
            PointA = pointA;
            PointB = pointB;
        }

        public double CalculateDistance() {            
            var radianLatitudeA = PointA.GetRadianLatitude();            
            var radianLongitudeA = PointA.GetRadianLongitude();
            var radianLatitudeB = PointB.GetRadianLatitude();
            var radianLongitudeB = PointB.GetRadianLongitude();
            
            var arc = Math.Acos(Math.Sin(radianLatitudeA) * Math.Sin(radianLatitudeB)
                      + Math.Cos(radianLatitudeA) * Math.Cos(radianLatitudeB)
                         * Math.Cos(radianLongitudeA - radianLongitudeB));
            return Math.Round(arc * Point.Radius, 3) ;
        }
    }
}
