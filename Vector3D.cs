namespace NuclearReactionModeling
{
    abstract class Vector3D
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

        protected double Length => System.Math.Sqrt(X * X + Y * Y + Z * Z);

        // public Vector3D Multiply(double scalar)
        // {
        //     return Vector3D(X, Y, Z);
        // }
    }
}