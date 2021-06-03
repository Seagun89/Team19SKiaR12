using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
   
    public class ConnectionPoint
    {
        public float Radius { get; set; }
        public SKPaint defaultPaint { get; set; }
        public SKPaint validconnectionPaint { get; set; }
        public SKPaint invalidconnectionPaint { get; set; }

        protected SKPoint point;

        public ConnectionPoint(SKPoint pt)
        {
            point = pt;
            Radius = 3;

            defaultPaint = new SKPaint
            {
                Color = SKColors.Yellow,
                IsAntialias = true,
                StrokeWidth = 1,
                Style = SKPaintStyle.StrokeAndFill

            };

            validconnectionPaint = new SKPaint
            {
                Color = SKColors.Green,
                IsAntialias = true,
                StrokeWidth = 1,
                Style = SKPaintStyle.StrokeAndFill

            };

            invalidconnectionPaint = new SKPaint
            {
                Color = SKColors.Red,
                IsAntialias = true,
                StrokeWidth = 1,
                Style = SKPaintStyle.StrokeAndFill

            };
        }

        public ConnectionPoint(float x, float y)
        {
            this.point.X = x;
            this.point.Y = y;

            Radius = 3;

            defaultPaint = new SKPaint
            {
                Color = SKColors.Yellow,
                IsAntialias = true,
                StrokeWidth = 1,
                Style = SKPaintStyle.StrokeAndFill

            };

            validconnectionPaint = new SKPaint
            {
                Color = SKColors.Green,
                IsAntialias = true,
                StrokeWidth = 1,
                Style = SKPaintStyle.StrokeAndFill

            };

            invalidconnectionPaint = new SKPaint
            {
                Color = SKColors.Red,
                IsAntialias = true,
                StrokeWidth = 1,
                Style = SKPaintStyle.StrokeAndFill

            };

        }

        public void defaultDraw(SKCanvas canvas)
        {
            canvas.DrawCircle(point, Radius, defaultPaint);
        }

        public void validDraw(SKCanvas canvas)
        {
            canvas.DrawCircle(point, Radius, validconnectionPaint);
        }

        public void invalidDraw(SKCanvas canvas)
        {
            canvas.DrawCircle(point, Radius, invalidconnectionPaint);
        }


        public void Move(float x, float y)
        {
            setPoint(x, y);
        }

        public void Move(SKPoint delta)
        {
            setPoint(delta);
        }

        public bool Contains(SKPoint p)
        {
            if (Math.Abs(point.X - p.X) < 20 && Math.Abs(point.Y - p.Y) < 20)
            {
                return true;

            }
            else
                return false;
        }

        public ConnectionPoint Nearby(SKPoint p)
        {
            if (Math.Abs(this.point.X - p.X) < 30 && Math.Abs(this.point.Y - p.Y) < 30)
            {
                return this;

            }
            else
                return null;
        }

        public void setPoint(float x, float y)
        {
            this.point.X = x;
            this.point.Y = y;
        }

        public void setPoint(SKPoint delta)
        {
            this.point = delta;
        }

        public SKPoint getPoint()
        {
            return this.point;
        }




    }
}
