using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
    public static class DrawingExtensions
    {
        public static SKPoint Move(this SKPoint pt1, SKPoint pt2)
        {
            pt1.Offset(pt2);

            return pt1;
        }

        public static SKRect Move(this SKRect rect, SKPoint pt)
        {
            rect.Offset(pt);

            return rect;
        }

        public static float distance(SKPoint pt1, SKPoint pt2)
        {
            return (float)Math.Abs(Math.Sqrt(Math.Pow((pt1.X - pt2.X), 2) + Math.Pow((pt1.Y - pt2.Y), 2)));
        }
    }
}
