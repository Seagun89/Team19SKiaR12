using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
    public interface IShape
    {
        void Draw(SKCanvas canvas);
        void Move(SKPoint pt);
        bool IsSelectable(SKPoint pt);
        void Select();
        void Deselect();
        void Resize(int delta);

    }
}
