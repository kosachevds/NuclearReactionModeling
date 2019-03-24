using System;
using System.Linq;

namespace NuclearReactionModeling
{
    class Cube : IShape
    {
        private double SideLength { get; }

        public Cube(double sideLength)
        {
            this.SideLength = sideLength;
        }

        public bool IsInternalPoint(double x, double y, double z)
        {
            return IsInternalPoint(new Point(x, y, z));
        }

        public bool IsInternalPoint(Point point)
        {
            var sideLengthHalf = this.SideLength / 2;
            var coordinates = new[]{point.X, point.Y, point.Z};
            if (coordinates.Any(x_ => x_ > sideLengthHalf))
            {
                return false;
            }
            return point.DurationToZero <= sideLengthHalf;
        }
    }
}