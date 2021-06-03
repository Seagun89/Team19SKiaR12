using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
    public class TopEndCap
    {
        protected SKPoint trianglePt;
        protected float heightTriangle;
        protected SKPath trianglePath;
        protected SKPaint Paint;

        public TopEndCap(SKPoint pt)
        {
            this.trianglePt = pt;
            this.heightTriangle = 20;

            Paint = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                StrokeWidth = 1,
                Style = SKPaintStyle.StrokeAndFill
            };
        }

        public void Draw(SKCanvas canvas)
        {
            SKPath path = new SKPath
            {
                FillType = SKPathFillType.EvenOdd
            };

            path.MoveTo(trianglePt.X - this.heightTriangle / 2, trianglePt.Y - this.heightTriangle); //left
            path.LineTo(trianglePt.X, trianglePt.Y); // draw line to the top
            path.LineTo(trianglePt.X + this.heightTriangle / 2, trianglePt.Y - this.heightTriangle); // draw line to the right
            path.LineTo(trianglePt.X - this.heightTriangle / 2, trianglePt.Y - this.heightTriangle); //draw line to the left

            canvas.DrawPath(path, Paint);
        }

        public void Move(SKPoint delta)
        {
            setTrianglePoint(delta);
        }

        public SKPoint getTrianglePoint()
        {
            return this.trianglePt;
        }

        public void setTrianglePoint(SKPoint pt)
        {
            this.trianglePt = pt;
        }
    }
}
