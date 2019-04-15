namespace NuclearReactionModeling
{
    class InteractionWithProbabilities : InteractionGenerator
    {
        private double absorption;

        private double scattering;

        private double fission;

        public InteractionWithProbabilities(double absorption, double scattering, double fission)
        {
            this.absorption = absorption;
            this.scattering = scattering;
            this.fission = fission;
            if (!this.ProbabilitiesAreGood()) {
                throw new System.ArgumentException("Sum of probabilities must be equals 1.0");
            }
        }

        public override Interaction Next()
        {
            var randomValue = rnd.NextDouble();
            if (randomValue < this.absorption) {
                return Interaction.Absorption;
            }
            if (randomValue < this.absorption + scattering) {
                return Interaction.Scattering;
            }
            return Interaction.Fission;
        }

        private bool ProbabilitiesAreGood()
        {
            var probSum = this.absorption + this.scattering + this.fission;
            return System.Double.Equals(probSum, 1.0);
        }
    }
}