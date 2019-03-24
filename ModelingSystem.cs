using System.Linq;
using System.Collections.Generic;

using Interactions = NuclearReactionModeling.InteractionGenerator.Interaction;

namespace NuclearReactionModeling
{
    class ModelingSystem
    {
        private int maxStepCount;
        private int fissionParticlesCount;
        private double lambda;
        private IShape body;
        private List<Particle> particles;
        private InteractionGenerator interactions;

        private static readonly System.Random rnd = new System.Random();

        private void MoveParticles()
        {
            foreach (var particle in particles)
            {
                var stepLength = GenerateStepLength();
                particle.Move(stepLength);
            }
        }

        private double GenerateStepLength()
        {
            return -System.Math.Log(rnd.NextDouble()) / this.lambda;
        }

        private void RemoveExternalParticles()
        {
            this.particles = this.particles
                .Where(x => this.body.IsInternalPoint(x.Coordinates))
                .ToList();
        }

        private void Interact()
        {
            var nextParticles = new List<Particle>();
            foreach (var particle in this.particles)
            {
                var interaction = this.interactions.Next();
                switch (interaction)
                {
                    case Interactions.Absorption:
                        continue;
                    case Interactions.Scattering:
                        nextParticles.Add(particle.CopyWithNewVelocity());
                        break;
                    case Interactions.Fission:
                        nextParticles.AddRange(SplitNucleus(particle));
                        break;
                }
            }
            this.particles = nextParticles;
        }

        private IEnumerable<Particle> SplitNucleus(Particle particle)
        {
            return Enumerable.Range(0, this.fissionParticlesCount)
                .Select(_ => particle.CopyWithNewVelocity());
        }
    }
}