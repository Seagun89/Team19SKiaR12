using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
    public class Diamond : Shape
    {
        protected SKPoint diamondPt;
        protected float diamondHeight;
        protected string text;
        protected SKPath diamondPath;

        public Diamond(SKPoint pt)
        {
            this.diamondPt = pt;
            this.diamondHeight = 60;


            this.left = new ConnectionPoint(diamondPt.X - this.diamondHeight, diamondPt.Y);
            this.right = new ConnectionPoint(diamondPt.X + this.diamondHeight, diamondPt.Y);
            this.top = new ConnectionPoint(diamondPt.X, diamondPt.Y - this.diamondHeight);
            this.bottom = new ConnectionPoint(diamondPt.X, diamondPt.Y + this.diamondHeight);

            this.rect = new SKRect(this.diamondPt.X - this.diamondHeight, this.diamondPt.Y - this.diamondHeight, this.diamondPt.X + this.diamondHeight, this.diamondPt.Y + this.diamondHeight);

            connectionPoints.Add(left);
            connectionPoints.Add(right);
            connectionPoints.Add(top);
            connectionPoints.Add(bottom);


            this.text = "Diamond";
        }

        public override void Draw(SKCanvas canvas)
        {
            CreatePaint();
            createStroke();

            SKPath path = new SKPath
            {
                FillType = SKPathFillType.EvenOdd
            };

            path.MoveTo(diamondPt.X - this.diamondHeight, this.diamondPt.Y); //left
            path.LineTo(diamondPt.X, this.diamondPt.Y - this.diamondHeight); // draw line to the top
            path.LineTo(diamondPt.X + this.diamondHeight, diamondPt.Y); // draw line to the right
            path.LineTo(diamondPt.X, diamondPt.Y + this.diamondHeight); //draw line to the bottom
            path.LineTo(diamondPt.X - this.diamondHeight, this.diamondPt.Y); //draw line to the left

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
            setDiamondPoint(delta);

            left.Move(delta.X - getDiamondHeight(), delta.Y);
            right.Move(delta.X + getDiamondHeight(), delta.Y);
            top.Move(delta.X, delta.Y - getDiamondHeight());
            bottom.Move(delta.X, delta.Y + getDiamondHeight());


            this.rect = new SKRect(delta.X - this.diamondHeight, delta.Y - this.diamondHeight, delta.X + this.diamondHeight, delta.Y + this.diamondHeight);
            
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
            if (Math.Abs(getDiamondPoint().X - pt.X) < getDiamondHeight() && Math.Abs(getDiamondPoint().Y - pt.Y) < getDiamondHeight())
            {
                return true;

            }
            else
                return false;
        }

        public SKPoint getDiamondPoint()
        {
            return this.diamondPt;
        }

        public void setDiamondPoint(SKPoint pt)
        {
            this.diamondPt = pt;
        }

        public float getDiamondHeight()
        {
            return this.diamondHeight;
        }

        public void setDiamondHeight(float h)
        {
            this.diamondHeight = h;
        }

        public override void Resize(int delta)
        {
            const float scale_per_delta = 0.1f / 20;
            float r = getDiamondHeight();

            r += delta * scale_per_delta;

            if (r < 30)
            {
                setDiamondHeight(30);
            }
            else
            {
                setDiamondHeight(r);
            }

            left.Move(getDiamondPoint().X - getDiamondHeight(), getDiamondPoint().Y);
            right.Move(getDiamondPoint().X + getDiamondHeight(), getDiamondPoint().Y);
            top.Move(getDiamondPoint().X, getDiamondPoint().Y - getDiamondHeight());
            bottom.Move(getDiamondPoint().X, getDiamondPoint().Y + getDiamondHeight());

           
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
            canvas.DrawText(text, diamondPt.X, diamondPt.Y - getDiamondHeight() / 2 - 10, Text_Paint);

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

