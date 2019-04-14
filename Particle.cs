namespace NuclearReactionModeling
{
    class Particle
    {
        public Particle(Vector3 coordinates, Vector3 velocity)
        {
            Coordinates = coordinates;
            Velocity = velocity;
        }

        public Vector3 Coordinates { get; set; }

        public Vector3 Velocity { get; set; }

        public void Move(double length)
        {
            this.Coordinates = new Vector3(
                this.Coordinates.X + length * this.Velocity.X,
                this.Coordinates.Y + length * this.Velocity.Y,
                this.Coordinates.Z + length * this.Velocity.Z
            );
        }

        public Particle CopyWithNewVelocity()
        {
            return new Particle(this.Coordinates, Vector3.GetRandom());
        }
    }
}