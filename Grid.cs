using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
    public class Grid
    {
        protected SKPaint gridPaint;
        public Grid()
        {
            gridPaint = new SKPaint
            {
                Color = SKColors.Black,
                StrokeWidth = 1.5f,
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                StrokeCap = SKStrokeCap.Round
            };


        }
           
        
        public void Draw(SKCanvas Canvas)
        {
           
            for (int p0 = 0; p0 < 551; p0 += 20)
            {
                for (int p1 = 0; p1 < 976; p1 += 20)
                {
                    var y = (p0 + 5) * 2;
                    var x = (p1 + 5) * 2;
                    var Point = new SKPoint(x, y);
                    Canvas.DrawPoint(Point, gridPaint);
                }

            }


        }
    }
}
