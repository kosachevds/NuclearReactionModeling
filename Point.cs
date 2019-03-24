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

        public Point Move(double length, Velocity velocity)
        {
            return new Point(
                this.X + length * velocity.X,
                this.Y + length * velocity.Y,
                this.Z + length * velocity.Z
            );
        }
    }
}