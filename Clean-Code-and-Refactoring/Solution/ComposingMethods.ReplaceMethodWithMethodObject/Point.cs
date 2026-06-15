namespace ComposingMethods.ReplaceMethodWithMethodObject
{
    /*
     * 
     * Problem:
     * You have a long method in which the local variables are so intertwined that you can’t apply Extract Method.
    */
    public class Point
    {
        private double Latitude;
        private double Longitude;
        public static readonly double Radian = 180 / 3.1415;
        public static readonly double Radius = 6371;

        public Point(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double GetRadianLatitude() {
            return Latitude / Point.Radian; 
        }

        public double GetRadianLongitude()
        {
            return Longitude / Point.Radian;
        }

        public double CalculateDistance(Point anotherPoint)
        {
            return new EarthDistance(this, anotherPoint).CalculateDistance();
        }
    }
}

