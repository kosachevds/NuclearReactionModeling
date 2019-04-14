using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NuclearReactionModeling
{
    class Program
    {
        static void Main(string[] args)
        {
            DifferentShapes("foo.txt");
        }

        static void DifferentShapes(string filename)
        {
            var beginPointsCount = 10;
            var lambda = 0.9;
            var volume = 27.0;
            var side = Math.Pow(volume, 1.0 / 3.0);
            var radius = side * Math.Pow(3.0 / (4.0 * Math.PI), 1.0 / 3.0);

            var writingTasks = new Task[2];
            var ballCounts = DoReaction(new Ball(radius), beginPointsCount, lambda);
            writingTasks[0] = WriteValuesInLinesAsync(ballCounts, "ball.txt");
            var cubeCounts = DoReaction(new Cube(side), beginPointsCount, lambda);
            writingTasks[1] = WriteValuesInLinesAsync(cubeCounts, "cube.txt");
            Task.WaitAll(writingTasks);
        }

        static List<Particle> GenerateParticlesOnSurface(IShape shape, int count)
        {
            return Enumerable.Range(0, count)
                .Select(_ => new Particle(shape.RandomInternalPoint(), Vector3.GetRandom()))
                .ToList();
        }

        static List<int> DoReaction(IShape shape, int particlesCount, double lambda)
        {
            var particles = GenerateParticlesOnSurface(shape, particlesCount);
            var reaction = new NuclearReaction(shape, particles, lambda);
            return reaction.Run();
        }

        static async Task WriteValuesInLinesAsync<TValue>(List<TValue> values, string filename)
        {
            using (var writer = new StreamWriter(File.OpenWrite(filename)))
            {
                foreach (var value in values)
                {
                    await writer.WriteAsync($"{value}\n");
                }
            }
        }
    }
}
