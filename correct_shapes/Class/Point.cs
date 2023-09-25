using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    /// <summary>
    /// Stores the abscissa and ordinate
    /// </summary>
    public class Point
    {
        public int _x { get; set; }
        public int _y { get; set; }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Overriding the ToString method to format outputting abscissa and ordinate output
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"x = {_x}; y = {_y}";
    }
}
