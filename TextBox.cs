using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
    public class LineString
    {
        public string Value { get; set; }
        public float Width { get; set; }
    }

    public class TextBox : Shape
    {
        protected SKPoint rectPt;
        protected string text;
        protected SKPaint textPaint;

        public TextBox(SKPoint pt)
        {
            this.rectPt = pt;
            this.width = 160;
            this.height = 60;
            this.rect = new SKRect(this.rectPt.X - this.width / 2, this.rectPt.Y - this.height / 2, this.rectPt.X + this.width / 2, this.rectPt.Y + this.height / 2);
            this.text = "Text Box";

        }


        public override void Draw(SKCanvas canvas)
        {
            TextDraw(canvas);
        }


        public void setText()
        {
            if (CreateText().Length != 0)
            {
                this.text = CreateText();
            }
        }

        public string getText()
        {
            return this.text;
        }


        public override void TextDraw(SKCanvas canvas)
        {
            setText();
            textPaint = CreatePaint();
            textPaint.TextSize = 10.0f;
            textPaint.IsAntialias = true;
            textPaint.TextAlign = SKTextAlign.Left;

            float lineHeight = textPaint.TextSize * 1.2f;
            var lines = splitLines(getText(), 100);
            var height = lines.Count() * lineHeight;

            var y = getRect().MidY - height / 2;

            foreach (var line in lines)
            {
                y += lineHeight;
                var x = rect.MidX - line.Width / 2;
                canvas.DrawText(line.Value, x, y, textPaint);
            }


        }

        public override bool Contains(SKPoint pt)
        {
            return getRect().Contains(pt);
        }

        public override void Move(SKPoint delta)
        {
            setRect(delta);

        }

        public SKRect getRect()
        {
            return this.rect;

        }

        public void setRect(SKPoint pt)
        {
            setRectanglePoint(pt);
            this.rect = new SKRect(pt.X - this.width / 2, pt.Y - this.height / 2, pt.X + this.width / 2, pt.Y + this.height / 2);
        }
    

        public void setRectanglePoint(SKPoint pt)
        {
            this.rectPt = pt;
        }

        private LineString[] splitLines(string text, float maxWidth)
        {
            var spaceWidth = Text_Paint.MeasureText(" ");
            var lines = text.Split('\n');

            return lines.SelectMany((line) =>
            {
                var result = new List<LineString>();

                var words = line.Split(new[] { " " }, StringSplitOptions.None);

                var lineResult = new StringBuilder();
                float width = 0;
                foreach (var word in words)
                {
                    var wordWidth = Text_Paint.MeasureText(word);
                    var wordWithSpaceWidth = wordWidth + spaceWidth;
                    var wordWithSpace = word + " ";

                    if (width + wordWidth > maxWidth)
                    {
                        result.Add(new LineString() { Value = lineResult.ToString(), Width = width });
                        lineResult = new StringBuilder(wordWithSpace);
                        width = wordWithSpaceWidth;
                    }
                    else
                    {
                        lineResult.Append(wordWithSpace);
                        width += wordWithSpaceWidth;
                    }
                }

                result.Add(new LineString() { Value = lineResult.ToString(), Width = width });

                return result.ToArray();
            }).ToArray();

        }

    }
}
