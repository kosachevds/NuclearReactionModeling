namespace NuclearReactionModeling
{
    class Particle
    {
        public Particle(Point coordinates, Velocity velocity)
        {
            Coordinates = coordinates;
            Velocity = velocity;
        }

        public Point Coordinates { get; set; }

        public Velocity Velocity { get; set; }

        public double X => this.Coordinates.Z;

        public double Y => this.Coordinates.Y;

        public double Z => this.Coordinates.Z;

        public void Move(double length)
        {
            this.Coordinates = new Point(
                this.X + length * this.Velocity.X,
                this.Y + length * this.Velocity.Y,
                this.Z + length * this.Velocity.Z
            );
        }
    }
}