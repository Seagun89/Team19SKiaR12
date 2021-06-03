using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
    public class Circle : Shape
    {
        protected SKPoint circlePt;
        protected float radius;
        protected string text;
     

        public Circle(SKPoint pt)
        {
            this.circlePt = pt;
            this.radius = 40;
            this.left = new ConnectionPoint(circlePt.X - this.radius, circlePt.Y);
            this.right = new ConnectionPoint(circlePt.X + this.radius, circlePt.Y);
            this.top = new ConnectionPoint(circlePt.X, circlePt.Y - this.radius);
            this.bottom = new ConnectionPoint(circlePt.X, circlePt.Y + this.radius);

           
            this.rect = new SKRect(this.circlePt.X - this.radius, this.circlePt.Y - this.radius, this.circlePt.X + this.radius, this.circlePt.Y + this.radius);

            connectionPoints.Add(left);
            connectionPoints.Add(right);
            connectionPoints.Add(top);
            connectionPoints.Add(bottom);

            this.text = "";
        }



        public override void setLeftConn(SKPoint pt)
        {
            this.left.setPoint(pt);
        }

        public override void setRightConn(SKPoint pt)
        {
            this.right.setPoint(pt);
        }

        public override ConnectionPoint getLeftConn()
        {
            return left;
        }

        public override ConnectionPoint getRightConn()
        {
            return right;
        }

        public override void setTopConn(SKPoint pt)
        {
            this.top.setPoint(pt);
        }

        public override void setBottomConn(SKPoint pt)
        {
            this.bottom.setPoint(pt);
        }

        public override ConnectionPoint getTopConn()
        {
            return top;
        }

        public override ConnectionPoint getBottomConn()
        {
            return bottom;
        }

        public override void Draw(SKCanvas canvas)
        {
            CreatePaint();
            createStroke();

            if(box.getShowBox())
            {
                canvas.DrawCircle(getCirclePoint(), getRadius(), Paint);
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

        public override void drawRectangle(SKCanvas canvas)
        {
            canvas.DrawRect(this.rect, RectPaint);
        }

        public override void drawConnectionPoints(SKCanvas canvas)
        {
            if(getDefaultPaint())
            {
                foreach (var cn in connectionPoints)
                {
                    cn.defaultDraw(canvas);
                }
            }
            if(getValidPaint())
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
            if (Math.Abs(getCirclePoint().X - pt.X) < getRadius() && Math.Abs(getCirclePoint().Y - pt.Y) < getRadius())
            {
                return true;

            }
            else
                return false;
        }

        public override void Move(SKPoint delta)
        {
            setCirclePoint(delta);

            left.Move(delta.X - getRadius(), delta.Y);
            right.Move(delta.X + getRadius(), delta.Y);
            top.Move(delta.X, delta.Y - getRadius());
            bottom.Move(delta.X, delta.Y + getRadius());

            this.rect = new SKRect(delta.X - this.radius, delta.Y - this.radius, delta.X + this.radius, delta.Y + this.radius);
        }

    

        public SKPoint getCirclePoint()
        {
            return this.circlePt;
        }

        public void setCirclePoint(SKPoint pt)
        {
            this.circlePt = pt;
        }

        public float getRadius()
        {
            return this.radius;
        }

        public void setRadius(float rad)
        {
            this.radius = rad;
        }

        public override void Resize(int delta)
        {
            const float scale_per_delta = 0.1f / 20;
            float r = getRadius();

            r += delta * scale_per_delta;

            if(r < 8)
            {
                setRadius(10);
            }
            else
            {
                setRadius(r);
            }

            left.Move(getCirclePoint().X - getRadius(), getCirclePoint().Y);
            right.Move(getCirclePoint().X + getRadius(), getCirclePoint().Y);
            top.Move(getCirclePoint().X, getCirclePoint().Y - getRadius());
            bottom.Move(getCirclePoint().X, getCirclePoint().Y + getRadius());

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
            canvas.DrawText(text, circlePt.X, circlePt.Y - getRadius() - 5, Text_Paint);

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
