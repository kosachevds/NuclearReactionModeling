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
            DifferentShapes("cube.txt", "ball.txt");

            Console.WriteLine("Done!");
        }

        static void DifferentShapes(string cubeFilename, string ballFilename)
        {
            var beginPointsCount = 1000;
            var lambda = 0.9;
            var volume = 5000;
            var side = Math.Pow(volume, 1.0 / 3.0);
            var radius = side * Math.Pow(3.0 / (4.0 * Math.PI), 1.0 / 3.0);

            var writingTasks = new Task[2];
            var ballCounts = DoReaction(new Ball(radius), beginPointsCount, lambda);
            writingTasks[0] = WriteValuesInLinesAsync(ballCounts, ballFilename);
            var cubeCounts = DoReaction(new Cube(side), beginPointsCount, lambda);
            writingTasks[1] = WriteValuesInLinesAsync(cubeCounts, cubeFilename);
            Task.WaitAll(writingTasks);
        }

        static List<Particle> GenerateInternalParticles(IShape shape, int count)
        {
            return Enumerable.Range(0, count)
                .Select(_ => new Particle(shape.RandomInternalPoint(), Vector3.GetRandom()))
                .ToList();
        }

        static List<int> DoReaction(IShape shape, int particlesCount, double lambda)
        {
            var particles = GenerateInternalParticles(shape, particlesCount);
            var reaction = new NuclearReaction(shape, particles, lambda);
            return reaction.Run();
        }

        static async Task WriteValuesInLinesAsync<TValue>(List<TValue> values, string filename)
        {
            using (var writer = new StreamWriter(File.Open(filename, FileMode.Truncate)))
            {
                foreach (var value in values)
                {
                    await writer.WriteAsync($"{value}\n");
                }
            }
        }
    }
}
