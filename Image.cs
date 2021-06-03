using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
    
    public class Image : Shape
    {
        protected SKImage image;
        protected SKPoint imagePt;

        protected SKBitmap bitmap;
        public SKPaint Paint_transparency;

        public Image(SKBitmap bitmap)
        {
            this.bitmap = bitmap;
            imagePt = new SKPoint(0, 0);

            /*
            Paint_transparency = new SKPaint
            {
                Color = Paint.Color.WithAlpha((byte)(0xFF * .4)) //UPDATE ALPHA VALUE TO CHANGE TRANSPARENCY

            };

            this.rect = new SKRect(this.imagePt.X, this.imagePt.Y, this.imagePt.X + this.bitmap.Width, this.imagePt.Y + this.bitmap.Height);
            */

        }

        //UNCOMMENT TO LOAD AN IMAGE 
        /*
        public Image(SKImage image)
        {
            this.image = image;
            imagePt = new SKPoint(200, 200);

        }
        */

        public override void Draw(SKCanvas canvas)
        {
            //UNCOMMENT TO DRAW AN IMAGE
            //canvas.DrawImage(image, imagePt);


            canvas.DrawBitmap(bitmap, imagePt, Paint_transparency);

            if (getShowRectangle())
            {
                drawRectangle(canvas);
            }

        }

        public override void drawRectangle(SKCanvas canvas)
        {
            canvas.DrawRect(this.rect, RectPaint);
        }

        public override void Move(SKPoint pt)
        {
            
            setImagePt(pt);

            this.rect = new SKRect(pt.X, pt.Y, pt.X + this.bitmap.Width, pt.Y + this.bitmap.Height);
        }

        public override bool Contains(SKPoint pt)
        {
            if (Math.Abs(getImagePt().X - pt.X) < 20 && Math.Abs(getImagePt().Y - pt.Y) < 20)
            {
                return true;
            }
            else
                return false;
        }

        protected SKPoint getImagePt()
        {
            return this.imagePt;
        }

        protected void setImagePt(SKPoint delta)
        {
            this.imagePt = delta;
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
