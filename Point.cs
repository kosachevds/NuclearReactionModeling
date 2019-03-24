using System;

namespace NuclearReactionModeling
{
    class Point : Vector3D
    {
        public Point(double x, double y, double z)
            : base(x, y, z)
        {
        }

        public double DurationToZero => this.Length;

    }
}