namespace RobotWars.Domain
{
    public struct Coordinate
    {
        private readonly int latitude;
        private readonly int longitude;

        public int Latitude { get { return latitude; } }
        public int Longitude { get { return longitude; } }

        public Coordinate(int latitude, int longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public override string ToString()
        {
            return string.Format("Latitude: {0}, Longitude: {1}", Latitude, Longitude);
        }
    }
}