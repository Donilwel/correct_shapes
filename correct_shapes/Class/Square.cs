using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    /// <summary>
    /// Square is inherited from Figure
    /// </summary>
   public class Square : Figure
    {
        public Square(Point point, int lenght) : base(point, lenght) { }

        /// <summary>
        /// Calculating the area of a figure
        /// </summary>
        /// <returns> Area </returns>
        public override int Area() => Lenght * Lenght;

        /// <summary>
        /// Counting the radius of the circumscribed circles
        /// </summary>
        /// <returns> Radius </returns>
        public override int Radius()
        {
            try
            {
                return (int)(Lenght / Math.Sqrt(2));
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exception - Деление на ноль");
                return 0;
            }
        }

        /// <summary>
        /// Vertex search, by first point and length
        /// </summary>
        /// <param name="point"> first points </param>
        /// <param name="lenght"> lenght </param>
        /// <returns></returns>
        public override Point[] GetPeaks(Point points, int lenght) => new Point[] {
            points,
            new Point(points._x, points._y + lenght),
            new Point(points._x + lenght, points._y + lenght),
            new Point(points._x + lenght, points._y)
        };

    }
}
