using System.Linq;

namespace NuclearReactionModeling
{
    class Velocity : Vector3D
    {
        private static readonly System.Random rnd = new System.Random();

        private const double MinValue = -1.0;

        private const double MaxValue = 1.0;

        public Velocity(double x, double y, double z)
            : base(x, y, z)
        {

        }

        public static Velocity Generate()
        {
            var components = Enumerable.Range(0, 3)
                .Select(_ => rnd.NextDouble() * (MaxValue - MinValue) - MinValue)
                .ToArray();
            return new Velocity(components[0], components[1], components[2]);
        }
    }
}