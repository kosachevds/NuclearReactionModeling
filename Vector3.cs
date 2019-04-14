using System.Linq;

namespace NuclearReactionModeling
{
    class Vector3
    {
        private static readonly System.Random rnd = new System.Random();

        public Vector3(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; }

        public double Y { get; }

        public double Z { get; }

        public double Length => System.Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector3 Multiply(double scalar)
        {
            return new Vector3(
                this.X * scalar,
                this.Y * scalar,
                this.Z * scalar
            );
        }

        public Vector3 Add(Vector3 another)
        {
            return new Vector3(
                this.X + another.X,
                this.Y + another.Y,
                this.Z + another.Z
            );
        }

        public static Vector3 GetRandom(double radius = 1.0)
        {
            var components = Enumerable.Range(0, 3)
                .Select(_ => rnd.NextDouble() * (2 * radius) - radius)
                .ToArray();
            return new Vector3(components[0], components[1], components[2]);
        }
    }
}