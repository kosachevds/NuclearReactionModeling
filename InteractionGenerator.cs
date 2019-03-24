using System;

namespace NuclearReactionModeling
{
    class InteractionGenerator
    {
        protected static readonly Random rnd = new Random();

        public enum Interaction
        {
            Absorption, Scattering, Fission
        }

        public virtual Interaction Next()
        {
            return (Interaction) rnd.Next(2);
        }
    }
}