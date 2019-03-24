namespace NuclearReactionModeling
{
    class Particle
    {
        public Particle(Vector3D coordinates, Velocity velocity)
        {
            Coordinates = coordinates;
            Velocity = velocity;
        }

        public Vector3D Coordinates { get; set; }

        public Velocity Velocity { get; set; }

        public void Move(double length)
        {
            this.Coordinates = new Vector3D(
                this.Coordinates.X + length * this.Velocity.X,
                this.Coordinates.Y + length * this.Velocity.Y,
                this.Coordinates.Z + length * this.Velocity.Z
            );
        }

        public Particle CopyWithNewVelocity()
        {
            return new Particle(this.Coordinates, Velocity.Generate());
        }
    }
}