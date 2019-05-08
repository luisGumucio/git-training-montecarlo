/// <summary>
/// The MonteCarloPI.cs file
/// </summary>
namespace MontecarloAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The MonteCarloPI implementation
    /// </summary>
    public class MonteCarloPI
    {
        /// <summary>
        /// Internal declaration of Points dictionary
        /// </summary>
        private Random rnd;
        public List<MPoint> Points { get { return Points; } }

        /// <summary>
        /// The MonteCarloPI constructor.
        /// </summary>
        public MonteCarloPI()
        {
            this.rnd = new Random();
            this.Points = new List<MPoint>();
        }

        /// <summary>
        /// Method to generate a new point.
        /// </summary>
        public void GeneratePoint()
        {
            MPoint newPoint = GenerateRandomPoint();
            this.Points.Add(newPoint);
        }

        /// <summary>
        /// Method to generate PI.
        /// </summary>
        /// <returns></returns>
        public float GetPI()
        {
            int circleCounter = this.Points.Count(x=>x.InsideCircle);
            int rectangleCounter = this.Points.Count;

            return 4.0f * circleCounter / rectangleCounter;
        }

        /// <summary>
        /// Generates a new random point.
        /// </summary>
        /// <returns>An instance of MPoint.</returns>
        private MPoint GenerateRandomPoint()
        {
            float x = GenerateRandomValue();
            float y = GenerateRandomValue();

            double ratio = Math.Sqrt(x * x + y * y);
            bool insideCircle = ratio <= 0.5;

            MPoint newOne = new MPoint(x, y, insideCircle);
            return newOne;
        }

        /// <summary>
        /// Generates the random coordinates.
        /// </summary>
        /// <returns>The random value.</returns>
        private float GenerateRandomCoordinate()
        {
            return (float)rnd.NextDouble() - 0.5f;
        }
    }
}
