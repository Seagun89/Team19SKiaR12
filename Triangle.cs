using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
    public class Triangle : Shape
    {
        protected SKPoint trianglePt;
        protected float heightTriangle;
        protected string text;
        protected SKPath trianglePath;


        public Triangle(SKPoint pt)
        {
            this.trianglePt = pt;
            this.heightTriangle = 60;

            this.left = new ConnectionPoint(trianglePt.X - this.heightTriangle / 2, trianglePt.Y + this.heightTriangle / 2);
            this.right = new ConnectionPoint(trianglePt.X + this.heightTriangle / 2, trianglePt.Y);
            this.top = new ConnectionPoint(trianglePt.X - this.heightTriangle / 2, trianglePt.Y - this.heightTriangle / 2);

            this.rect = new SKRect(this.trianglePt.X - this.heightTriangle / 2, this.trianglePt.Y - this.heightTriangle / 2, this.trianglePt.X + this.heightTriangle / 2, this.trianglePt.Y + this.heightTriangle / 2);


            connectionPoints.Add(left);
            connectionPoints.Add(right);
            connectionPoints.Add(top);

            this.text = "Triangle";

        }

        public override void Draw(SKCanvas canvas)
        {
            CreatePaint();
            createStroke();

            SKPath path = new SKPath
            {
                FillType = SKPathFillType.EvenOdd
            };

            path.MoveTo(trianglePt.X - this.heightTriangle / 2, trianglePt.Y + this.heightTriangle / 2); //left
            path.LineTo(trianglePt.X - this.heightTriangle / 2, trianglePt.Y - this.heightTriangle / 2); // draw line to the top
            path.LineTo(trianglePt.X + this.heightTriangle / 2, trianglePt.Y); // draw line to the right
            path.LineTo(trianglePt.X - this.heightTriangle / 2, trianglePt.Y + this.heightTriangle / 2); //draw line to the left

            if (box.getShowBox())
            { 
                canvas.DrawPath(path, Paint);
            }

            TextDraw(canvas);

            if (getShowConnections())
            {
                drawConnectionPoints(canvas);
            }

            if (getShowRectangle())
            {
                drawRectangle(canvas);
            }
        }


        public override void Move(SKPoint delta)
        {
            setTrianglePoint(delta);

            left.Move(delta.X - getTriangleHeight() / 2, delta.Y + getTriangleHeight() / 2);
            right.Move(delta.X + getTriangleHeight() / 2, delta.Y);
            top.Move(delta.X - getTriangleHeight() / 2, delta.Y - getTriangleHeight() / 2);


            this.rect = new SKRect(delta.X - this.heightTriangle / 2, delta.Y - this.heightTriangle / 2, delta.X + this.heightTriangle / 2, delta.Y + this.heightTriangle / 2);
        }

        public override void drawRectangle(SKCanvas canvas)
        {
            canvas.DrawRect(this.rect, RectPaint);
        }

        public override void drawConnectionPoints(SKCanvas canvas)
        {
            if (getDefaultPaint())
            {
                foreach (var cn in connectionPoints)
                {
                    cn.defaultDraw(canvas);
                }
            }
            if (getValidPaint())
            {
                foreach (var cn in connectionPoints)
                {
                    cn.validDraw(canvas);
                }
            }
            if (getInvalidPaint())
            {
                foreach (var cn in connectionPoints)
                {
                    cn.invalidDraw(canvas);
                }
            }
        }

        public override bool Contains(SKPoint pt)
        {
            if (Math.Abs(getTrianglePoint().X - pt.X) < getTriangleHeight() && Math.Abs(getTrianglePoint().Y - pt.Y) < getTriangleHeight())
            {
                return true;

            }
            else
                return false;
        }

        public SKPoint getTrianglePoint()
        {
            return this.trianglePt;
        }

        public void setTrianglePoint(SKPoint pt)
        {
            this.trianglePt = pt;
        }

        public float getTriangleHeight()
        {
            return this.heightTriangle;
        }

        public void setTriangleHeight(float h)
        {
            this.heightTriangle = h;
        }

        public override void Resize(int delta)
        {
            const float scale_per_delta = 0.1f / 20;
            float r = getTriangleHeight();

            r += delta * scale_per_delta;

            if(r < 30)
            {
                setTriangleHeight(30);
            }
            else
            {
                setTriangleHeight(r);
            }

            left.Move(getTrianglePoint().X - getTriangleHeight() / 2, getTrianglePoint().Y + getTriangleHeight() / 2);
            right.Move(getTrianglePoint().X + getTriangleHeight() / 2, getTrianglePoint().Y + getTriangleHeight() / 2);
            top.Move(getTrianglePoint().X, getTrianglePoint().Y - getTriangleHeight() / 2);
        }

        public override List<ConnectionPoint> getConnectionPoints()
        {
            return connectionPoints;
        }

        public override ConnectionPoint getNearConnectionPoint(SKPoint pt)
        {
            float shortestDistance = DrawingExtensions.distance(connectionPoints.ElementAt(0).getPoint(), pt);
            ConnectionPoint shortestConnPt = connectionPoints.ElementAt(0);
            foreach (var cnp in connectionPoints)
            {
                if (DrawingExtensions.distance(cnp.getPoint(), pt) < shortestDistance)
                {
                    shortestDistance = DrawingExtensions.distance(cnp.getPoint(), pt);
                    shortestConnPt = cnp;
                }
            }
            return shortestConnPt;

        }

        public override void setShowConnections(bool val)
        {
            showConnectionPoints = val;
        }

        public override bool getShowConnections()
        {
            return showConnectionPoints;
        }

        public override void setShowRectangle(bool val)
        {
            showRectangle = val;
        }

        public override bool getShowRectangle()
        {
            return showRectangle;
        }

        public override void TextDraw(SKCanvas canvas)
        {
            setText();
            Text_Paint.TextSize = 10.0f;
            Text_Paint.IsAntialias = true;
            Text_Paint.TextAlign = SKTextAlign.Center;
            canvas.DrawText(text, trianglePt.X, trianglePt.Y - getTriangleHeight() / 2 - 10, Text_Paint);

        }

        public void setText()
        {
            this.text = CreateText();
        }

        public string getText()
        {
            return this.text;
        }
    }
}
