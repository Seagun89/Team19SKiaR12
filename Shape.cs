using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
    public class Shape : IShape
    {
        public PropertiesBox box;
        public SKPaint Paint { get; set; }
        public SKPaint RectPaint { get; set; }
        public SKPaint Text_Paint { get; set; }

        protected SKRect rect;

        protected float width;
        protected float height;
        public virtual bool Selected { get; set; }

        protected bool showConnectionPoints = false;
        protected bool showRectangle = false;

        protected bool defaultPaint = true;
        protected bool validPaint = false;
        protected bool invalidPaint = false;
        protected bool showShape = true;


        protected ConnectionPoint left;
        protected ConnectionPoint right;
        protected ConnectionPoint top;
        protected ConnectionPoint bottom;

     
        public List<ConnectionPoint> connectionPoints = new List<ConnectionPoint>();

        
        public Shape()
        {
            this.box = new PropertiesBox();

            Paint = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                StrokeWidth = 1,
                Style = SKPaintStyle.Stroke
            };

            RectPaint = new SKPaint
            {
                Color = SKColors.Red,
                IsAntialias = true,
                StrokeWidth = 1,
                Style = SKPaintStyle.Stroke,

            };

            Text_Paint = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                StrokeWidth = 1,
                Style = SKPaintStyle.Stroke
            };
        }

        public virtual SKRect getRectangle()
        {
            return this.rect;
        }

        public virtual void setRectangle(SKPoint pt)
        {
            this.rect = new SKRect(pt.X - getWidth() / 2, pt.Y - getHeight() / 2, pt.X + getWidth() / 2, pt.Y + getHeight() / 2);
        }

        public virtual void setHeight(float h)
        {
            this.height = h;
        }

        public virtual void setWidth(float w)
        {
            this.width = w;
        }

        public virtual float getHeight()
        {
            return this.height;
        }

        public virtual float getWidth()
        {
            return this.width;
        }

        public virtual void drawConnectionPoints(SKCanvas canvas) { }


        public virtual void setLeftConn(SKPoint pt)
        {
            this.left.setPoint(pt);
        }

        public virtual void setRightConn(SKPoint pt)
        {
            this.right.setPoint(pt);
        }

        public virtual void setTopConn(SKPoint pt)
        {
            this.top.setPoint(pt);
        }

        public virtual void setBottomConn(SKPoint pt)
        {
            this.bottom.setPoint(pt);
        }

        public virtual ConnectionPoint getLeftConn()
        {
            return this.left;
        }


        public virtual ConnectionPoint getRightConn()
        {
            return this.right;
        }

        public virtual ConnectionPoint getTopConn()
        {
            return this.top;
        }

        public virtual ConnectionPoint getBottomConn()
        {
            return this.bottom;
        }

        public virtual void Select()
        {
            Selected = true;
        }

        public virtual void Deselect()
        {
            Selected = false;
        }


        public virtual bool IsSelectable(SKPoint pt)
        {
            return true;
        }

        public virtual void Draw(SKCanvas canvas) { }


        public virtual void Resize(int delta) { }


        public virtual void Move(SKPoint pt) { }

        public virtual void Move(float x, float y) { }


        public virtual bool Contains(SKPoint pt)
        {
            return false;
        }

        public virtual ConnectionPoint getNearPoint(SKPoint pt)
        {
            return this.left;
        }

        public virtual ConnectionPoint getNearPoint(float x, float y)
        {
            return this.left;
        }

        public virtual List<ConnectionPoint> getConnectionPoints()
        {
            if (connectionPoints.Count() != 0)
                return connectionPoints;
            else
                return null;
        }

        public virtual ConnectionPoint getNearConnectionPoint(SKPoint pt)
        {
            if(connectionPoints != null)
            {
                ConnectionPoint shortestPoint = connectionPoints.First();
                return shortestPoint;
            }
            
            return null;

        }

        public virtual void setShowConnections(bool val) { }


        public virtual bool getShowConnections()
        {
            return showConnectionPoints;
        }

        public virtual void setShowShape(bool val) { }

        public virtual bool getShowShape()
        {
            return showShape;
        }

        public virtual void setShowRectangle(bool val) { }

        public virtual bool getShowRectangle()
        {
            return showRectangle;
        }

        public virtual void drawRectangle(SKCanvas canvas) { }

        public SKPaint CreatePaint()
        {
            string color = box.GetColorChoice();

            if (color.Equals("Blue"))
                Paint.Color = SKColors.Blue;
            if (color.Equals("Black"))
                Paint.Color = SKColors.Black;
            if (color.Equals("Red"))
                Paint.Color = SKColors.Red;
            if (color.Equals("Green"))
                Paint.Color = SKColors.Green;
            if (color.Equals("Purple"))
                Paint.Color = SKColors.Purple;
            if (color.Equals("Yellow"))
                Paint.Color = SKColors.Yellow;

            return Paint;
        }

        public SKPaint createStroke()
        {
            string style = box.getStrokeAndFillChoice();
            

            if(style.Equals("Stroke and Fill"))
            {
                Paint.Style = SKPaintStyle.StrokeAndFill;
            }
            else if(style.Equals("Stroke"))
            {
                Paint.Style = SKPaintStyle.Stroke;
            }

            return Paint;
        }

        public virtual void TextDraw(SKCanvas canvas) { }

        public void showPropertiesBox()
        {
            box.Show();
        }

        public virtual string CreateText()
        {
            return box.GetDeviceName();
        }

        public void setDefaultPaint(bool val)
        {
            defaultPaint = val;
        }

        public void setValidPaint(bool val)
        {
            validPaint = val;
        }

        public void setInvalidPaint(bool val)
        {
            invalidPaint = val;
        }

        public bool getDefaultPaint()
        {
            return defaultPaint;
        }

        public bool getValidPaint()
        {
            return validPaint;
        }

        public bool getInvalidPaint()
        {
            return invalidPaint;
        }


    }
}
