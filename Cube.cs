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

        public bool IsInternalPoint(Vector3D point)
        {
            var sideLengthHalf = this.SideLength / 2;
            var coordinates = new[]{point.X, point.Y, point.Z};
            if (coordinates.Any(x_ => x_ > sideLengthHalf))
            {
                return false;
            }
            return point.Length <= sideLengthHalf;
        }
    }
}