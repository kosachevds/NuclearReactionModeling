namespace NuclearReactionModeling
{
    class Vector3D
    {
        public Vector3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; }

        public double Y { get; }

        public double Z { get; }

        public double Length => System.Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector3D Multiply(double scalar)
        {
            return new Vector3D(
                this.X * scalar,
                this.Y * scalar,
                this.Z * scalar
            );
        }

        public Vector3D Add(Vector3D another)
        {
            return new Vector3D(
                this.X + another.X,
                this.Y + another.Y,
                this.Z + another.Z
            );
        }
    }
}