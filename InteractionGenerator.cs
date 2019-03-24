using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<Interaction> GenerateSequence(int size)
        {
            return Enumerable.Range(0, size)
                .Select(_ => this.Next())
                .ToList();
        }
    }
}