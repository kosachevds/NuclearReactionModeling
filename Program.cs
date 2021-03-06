﻿using System;
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

        static void BallWithInteractionProbabilities(double absorption, double scattering, double fission)
        {
            var ball = new Ball(10);
            var particles = GenerateInternalParticles(ball, 1000);
            var reaction = new NuclearReaction(ball, particles, 0.9);
            reaction.RandomInteractions = new InteractionWithProbabilities(absorption, scattering, fission);
            var counts = reaction.Run();
               
        }

        static void DifferentShapes(string cubeFilename, string ballFilename)
        {
            var volumes = Enumerable.Range(1, 5)
                .Select(x => 100.0 * x)
                .ToList();
            volumes.AddRange(Enumerable.Range(1, 5)
                .Select(x => 1000.0 * x));
            var writingTasks = new List<Task>(2);

            var ballCounts = AnalyzeVolumes(volumes, BallFromVolume);
            var ballCountsWriting = WriteCountsAsync(ballCounts, ballFilename);

            var cubeCounts = AnalyzeVolumes(volumes, CubeFromVolume);
            var cubeCountsWriting = WriteCountsAsync(cubeCounts, cubeFilename);

            Task.WaitAll(ballCountsWriting, cubeCountsWriting);
        }

        static Dictionary<double, List<int>> AnalyzeVolumes(List<double> volumes, Func<double, IShape> shapeCreator)
        {
            var beginPointsCount = 1000;
            var lambda = 0.9;

            var result = new Dictionary<double, List<int>>(volumes.Count);
            foreach (var volume in volumes)
            {
                result.Add(volume, DoReaction(shapeCreator(volume), beginPointsCount, lambda));
            }
            return result;
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
        static async Task WriteCountsAsync(Dictionary<double, List<int>> counts, string filename)
        {
            using (var writer = new StreamWriter(File.Open(filename, FileMode.Truncate)))
            {
                foreach (var pair in counts)
                {
                    await writer.WriteAsync(pair.Key + " ");
                    await writer.WriteAsync(String.Join(' ', pair.Value));
                    await writer.WriteLineAsync();
                }
            }
        }

        static IShape BallFromVolume(double volume)
        {
            return new Ball(Math.Pow((3 * volume) / (4 * Math.PI), 1.0 / 3.0));
        }

        static IShape CubeFromVolume(double volume)
        {
            return new Cube(Math.Pow(volume, 1.0 / 3.0));
        }
    }
}
