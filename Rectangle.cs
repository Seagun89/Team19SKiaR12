using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
    public class Rectangle : Shape
    {
        protected SKRect rect;
        protected SKPoint rectPt;
        protected float width = 80;
        protected float height = 60;
        protected string text;


        public Rectangle(SKPoint pt)
        {
            this.rectPt = pt;
            this.rect = new SKRect(this.rectPt.X - this.width / 2, this.rectPt.Y - this.height / 2, this.rectPt.X + this.width / 2, this.rectPt.Y + this.height / 2);
            this.text = "Rectangle";

            this.left = new ConnectionPoint(rectPt.X - this.width / 2, rectPt.Y);
            this.right = new ConnectionPoint(rectPt.X + this.width / 2, rectPt.Y);
            this.top = new ConnectionPoint(rectPt.X, rectPt.Y - this.height / 2);
            this.bottom = new ConnectionPoint(rectPt.X, rectPt.Y + this.height / 2);

            connectionPoints.Add(left);
            connectionPoints.Add(right);
            connectionPoints.Add(top);
            connectionPoints.Add(bottom);
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

        public void setText()
        {
            this.text = CreateText();
        }

        public string getText()
        {
            return this.text;
        }

        public override void Draw(SKCanvas canvas)
        {
            CreatePaint();
            createStroke();

            if(box.getShowBox())
            {
                canvas.DrawRect(getRect(), Paint);
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

        public override void TextDraw(SKCanvas canvas)
        {
            setText();
            Text_Paint.TextSize = 10.0f;
            Text_Paint.IsAntialias = true;
            Text_Paint.TextAlign = SKTextAlign.Center;

            SKPoint textOffset = new SKPoint(getRectanglePoint().X, getRectanglePoint().Y - getHeight() / 2 + 15);
            canvas.DrawText(getText(), textOffset, Text_Paint);
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
            return getRect().Contains(pt);
        }

        public override void Move(SKPoint delta)
        {
            setRect(delta);

            left.Move(delta.X - getWidth() / 2, delta.Y);
            right.Move(delta.X + getWidth() / 2, delta.Y);
            top.Move(delta.X, delta.Y - getHeight() / 2);
            bottom.Move(delta.X, delta.Y + getHeight() / 2);

        }

        public void setRect(SKPoint pt)
        {
            setRectanglePoint(pt);

            this.rect = new SKRect(pt.X - this.width / 2, pt.Y - this.height / 2, pt.X + this.width / 2, pt.Y + this.height / 2);

        }

        public SKRect getRect()
        {
            return this.rect;

        }

        public SKPoint getRectanglePoint()
        {
            return this.rectPt;
        }

        public void setRectanglePoint(SKPoint pt)
        {
            this.rectPt = pt;
        }

        public void setHeight(float h)
        {
            this.height = h;

        }

        public float getHeight()
        {
            return this.height;
        }

        public void setWidth(float w)
        {
            this.width = w;

        }

        public float getWidth()
        {
            return this.width;
        }

        public override void Resize(int delta)
        {
            const float scale_per_delta = 0.1f / 20;
            float w = getWidth();
            float h = getHeight();
            w += delta * scale_per_delta;
            h += delta * scale_per_delta;

            if(w < 40)
            {
                setWidth(40);
                setHeight(30);
            }
            else
            {
                setWidth(w);
                setHeight(h);

            }

            setRect(getRectanglePoint());

            left.Move(getRectanglePoint().X - getWidth() / 2, getRectanglePoint().Y);
            right.Move(getRectanglePoint().X + getWidth() / 2, getRectanglePoint().Y);
            top.Move(getRectanglePoint().X, getRectanglePoint().Y - getHeight() / 2);
            bottom.Move(getRectanglePoint().X, getRectanglePoint().Y + getHeight() / 2);

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

    }
}
