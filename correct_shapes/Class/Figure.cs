using System;
using System.Linq;
namespace Class
{
    /// <summary>
    /// base class Figures. With a description of all methods
    /// </summary>
    public abstract class Figure
    {
        public Point[] points;

        public int Lenght
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="point"> first points </param>
        /// <param name="lenght"> lenght </param>
        /// <exception cref="Exception"> if lenght is it negative number </exception>
        public Figure(Point point, int lenght)
        {
            Lenght = lenght;

            if (Lenght < 0)
            {
                throw new Exception("Exeption - Длина стороны отрицательная");
            }

            points = GetPeaks(point, lenght);
        }
        /// <summary>
        /// Vertex search, by first point and length
        /// </summary>
        /// <param name="point"> first points </param>
        /// <param name="lenght"> lenght </param>
        /// <returns></returns>
        public abstract Point[] GetPeaks(Point point, int lenght);

        /// <summary>
        /// Calculating the area of a figure
        /// </summary>
        /// <returns> Area </returns>
        public abstract int Area();

        /// <summary>
        /// Counting the radius of the circumscribed circles
        /// </summary>
        /// <returns> Radius </returns>
        public abstract int Radius();

        /// <summary>
        /// Describes all the X and Y coordinates of the shape,
        /// the length of the side of the shape, and also body type
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            string text = "";

            points.ToList().ForEach(x => text += x.ToString() + "\n");

            return text + GetType().Name + " " + Area();
        }
    }
}
