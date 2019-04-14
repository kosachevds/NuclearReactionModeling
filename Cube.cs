using System;
using System.Linq;

namespace NuclearReactionModeling
{
    class Cube : IShape
    {
        private static Random rnd = new Random();
        private double SideLength { get; }

        public Cube(double sideLength)
        {
            this.SideLength = sideLength;
        }

        public bool IsInternalPoint(Vector3 point)
        {
            var sideLengthHalf = this.SideLength / 2;
            var coordinates = new[]{point.X, point.Y, point.Z};
            if (coordinates.Any(x_ => x_ > sideLengthHalf))
            {
                return false;
            }
            return point.Length <= sideLengthHalf;
        }

        public Vector3 RandomPointFromSurface()
        {
            var components = Enumerable.Range(0, 3)
                .Select(_ => rnd.NextDouble() * this.SideLength + this.SideLength / 2)
                .ToArray();
            return new Vector3(components[0], components[1], components[2]);
        }
    }
}