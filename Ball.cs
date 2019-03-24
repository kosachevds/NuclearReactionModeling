namespace NuclearReactionModeling
{
    class Ball : IShape
    {
        private double Radius { get; }

        public Ball(double radius)
        {
            this.Radius = radius;
        }

        public bool IsInternalPoint(Vector3D point)
        {
            return point.Length <= this.Radius;
        }
    }
}