using System.Linq;

namespace NuclearReactionModeling
{
    class Vector3D
    {
        private static readonly System.Random rnd = new System.Random();

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

        public static Vector3D GetRandom(double radius = 1.0)
        {
            var components = Enumerable.Range(0, 3)
                .Select(_ => rnd.NextDouble() * (2 * radius) - radius)
                .ToArray();
            return new Velocity(components[0], components[1], components[2]);
        }
    }
}