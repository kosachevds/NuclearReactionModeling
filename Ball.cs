namespace NuclearReactionModeling
{
    class Ball : IShape
    {
        private double Radius { get; }

        public Ball(double radius)
        {
            this.Radius = radius;
        }

        public bool IsInternalPoint(double x, double y, double z)
        {
            var durationToCenter = System.Math.Sqrt(x * x + y * y + z * z);
            return durationToCenter <= this.Radius;
        }

        public bool IsInternalPoint(Point point)
        {
            return point.DurationToZero <= this.Radius;
        }
    }
}