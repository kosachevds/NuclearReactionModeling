using System;
using System.Linq;

namespace NuclearReactionModeling
{
    class Ball : IShape
    {
        private static Random rnd = new Random();

        private double Radius { get; }

        public Ball(double radius)
        {
            this.Radius = radius;
        }

        public bool IsInternalPoint(Vector3 point)
        {
            return point.Length <= this.Radius;
        }

        public Vector3 RandomInternalPoint()
        {
            var components = Enumerable.Range(0, 3)
                .Select(_ => (rnd.NextDouble() * 2 - 1) * this.Radius / 2)
                .ToArray();
            return new Vector3(components[0], components[1], components[2]);
        }
    }
}