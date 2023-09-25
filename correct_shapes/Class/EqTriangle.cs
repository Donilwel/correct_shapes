using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    /// <summary>
    /// Right Triangle is inherited from Figure
    /// </summary>
    public class EqTriangle : Figure
    {
        public EqTriangle(Point point, int lenght) : base(point, lenght) { }

        /// <summary>
        /// Calculating the area of a figure
        /// </summary>
        /// <returns> Area </returns>
        public override int Area()
        {
            try
            {
                return (int)((Math.Sqrt(3) * Math.Pow(Lenght, 2)) / 4);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exception - Деление на ноль");
                return 0;
            }
        }

        /// <summary>
        /// Counting the radius of the circumscribed circles
        /// </summary>
        /// <returns> Radius </returns>
        public override int Radius()
        {
            try
            {
                return (int)((2 * Lenght) / Math.Sqrt(3));
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
            new Point( lenght / 2 , points._y + lenght),
            new Point(points._x + lenght, points._y)
        };
    }
}
