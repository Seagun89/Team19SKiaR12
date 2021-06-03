using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{
    public class Connection
    {
        protected Shape source;
        protected Shape target;
        protected ConnectionPoint sourceCP;
        protected ConnectionPoint targetCP;
        protected SKPaint LinePaint;
        protected RightEndCap rightEndCap;
        protected LeftEndCap leftEndCap;
        protected TopEndCap topEndCap;
        protected BottomEndCap bottomEndCap;


        public Connection(Shape source, ConnectionPoint sourceCP, Shape target, ConnectionPoint targetCP)
        {
            this.source = source;
            this.target = target;
            this.sourceCP = sourceCP;
            this.targetCP = targetCP;

            LinePaint = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                StrokeWidth = 1,
                Style = SKPaintStyle.Stroke
            };

            this.rightEndCap = new RightEndCap(targetCP.getPoint());
            this.leftEndCap = new LeftEndCap(targetCP.getPoint());
            this.topEndCap = new TopEndCap(targetCP.getPoint());
            this.bottomEndCap = new BottomEndCap(targetCP.getPoint());

        }


        public void setSource(Shape shp)
        {
            this.source = shp;
        }

        public void setTarget(Shape shp)
        {
            this.target = shp;
        }

        public Shape getSource()
        {
            return this.source;
        }

        public Shape getTarget()
        {
            return this.target;
        }

        public ConnectionPoint getSourceCP()
        {
            return this.sourceCP;
        }

        public ConnectionPoint getTargetCP()
        {
            return this.targetCP;
        }

        public void setSourceCP(ConnectionPoint cp)
        {
            this.sourceCP = cp;
        }

        public void setTargetCP(ConnectionPoint cp)
        {
            this.targetCP = cp;
        }

        public void DrawConnection(SKCanvas canvas)
        {
            if (source != null)
            {
                List<SKPoint> drawPoints = calculatePath();

                canvas.DrawLine(getSourceCP().getPoint(), drawPoints[0], LinePaint);
                canvas.DrawLine(drawPoints[0], drawPoints[1], LinePaint);
                canvas.DrawLine(drawPoints[1], drawPoints[2], LinePaint);
                canvas.DrawLine(drawPoints[2], getTargetCP().getPoint(), LinePaint);

                //canvas.DrawLine(getTargetCP().getPoint(), getSourceCP().getPoint(), LinePaint);

                if (getTargetCP() == target.getLeftConn())
                {
                    rightEndCap.Draw(canvas);
                }
                else if(getTargetCP() == target.getRightConn())
                {
                    leftEndCap.Draw(canvas);
                }
                else if(getTargetCP() == target.getTopConn())
                {
                    topEndCap.Draw(canvas);
                }
                else if (getTargetCP() == target.getBottomConn())
                {
                    bottomEndCap.Draw(canvas);
                }

            }
        }

        public void detach()
        {
            this.source = null;
            this.target = null;
            this.sourceCP = null;
            this.targetCP = null;

        }

        public bool contains(Shape shp)
        {
            if (shp == source || shp == target)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Updates the position of the end cap when a shape is resized
        /// </summary>
        /// <param name="delta"></param>
        public void moveEndCap(SKPoint delta)
        {
            if (getTargetCP() == target.getLeftConn())
            {
                rightEndCap.Move(getTargetCP().getPoint());
            }
            else if (getTargetCP() == target.getRightConn())
            {
                leftEndCap.Move(getTargetCP().getPoint());
            }
            else if (getTargetCP() == target.getTopConn())
            {
                topEndCap.Move(getTargetCP().getPoint());
            }
            else if (getTargetCP() == target.getBottomConn())
            {
                bottomEndCap.Move(getTargetCP().getPoint());
            }

        }

        /// <summary>
        /// B.TWOMEY - FUTURE UPDATES COULD INCLUDE COLLISION DETECTION WITH OTHER SHAPES FOR ROUTING
        /// </summary>
        /// <returns></returns>
        protected List<SKPoint> calculatePath()
        {
            List<SKPoint> linePath = new List<SKPoint>();
            SKPoint mid1 = new SKPoint();
            SKPoint mid2 = new SKPoint();
            SKPoint mid3 = new SKPoint();

            // DETERMINE IF THERE IS AN OFFSET BETWEEN THE SOURCE AND TARGET SHAPE
            float deltaX = Math.Abs(sourceCP.getPoint().X - targetCP.getPoint().X);
            float deltaY = Math.Abs(sourceCP.getPoint().Y - targetCP.getPoint().Y);
           
            //VALID CONNECTIONS FOR THE DYANMIC CONNECTORS ARE AS FOLLOWS:
            // 1 LEFT TO RIGHT
            // 2 RIGHT TO LEFT
            // 3 LEFT TO TOP
            // 4 LEFT TO BOTTOM
            // 5 RIGHT TO TOP
            // 6 RIGHT TO BOTTOM
            // 7 BOTTOM TO TOP
            // 8 BOTTOM TO RIGHT
            // 9 BOTTOM TO LEFT
            // 10 TOP TO BOTTOM
            // 11 TOP TO LEFT
            // 12 TOP TO RIGHT
            // 13 TOP TO TOP
            // 14 TOP TO BOTTOM
            

            //LEFT TO RIGHT CONNECTION
            if (getSourceCP() == source.getLeftConn() && getTargetCP() == target.getRightConn())
            {
                //we draw a horizontal line
                if(deltaY != 0)
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X - deltaX / 2, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                }
                else
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                }

                mid2 = new SKPoint(mid1.X, targetCP.getPoint().Y);
                linePath.Add(mid2);
                mid3 = new SKPoint(mid1.X, targetCP.getPoint().Y);
                linePath.Add(mid3);


            }
            //RIGHT TO LEFT CONNECTION
            else if (getSourceCP() == source.getRightConn() && getTargetCP() == target.getLeftConn())
            {
                //we draw a horizontal line
                if (deltaY != 0)
                {
                    mid1 = new SKPoint(targetCP.getPoint().X - deltaX / 2, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                }
                else
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                }
                mid2 = new SKPoint(mid1.X, targetCP.getPoint().Y);
                linePath.Add(mid2);
                mid3 = new SKPoint(mid1.X, targetCP.getPoint().Y);
                linePath.Add(mid3);


            }

            //LEFT TO TOP
            else if (getSourceCP() == source.getLeftConn() && getTargetCP() == target.getTopConn())
            {
                if (sourceCP.getPoint().Y > targetCP.getPoint().Y) //if the source is lower on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X - deltaX / 2, sourceCP.getPoint().Y);
                    linePath.Add(mid1);

                    mid2 = new SKPoint(sourceCP.getPoint().X - deltaX / 2, targetCP.getPoint().Y - 40);
                    linePath.Add(mid2);

                    mid3 = new SKPoint(targetCP.getPoint().X, mid2.Y);
                    linePath.Add(mid3);
                }
                else if (sourceCP.getPoint().Y < targetCP.getPoint().Y) //if the source is higher on the canvas than the target
                {
                    mid1 = new SKPoint(targetCP.getPoint().X, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                else
                {
                    mid1 = new SKPoint(targetCP.getPoint().X, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }

            }
            //LEFT TO BOTTOM
            else if (getSourceCP() == source.getLeftConn() && getTargetCP() == target.getBottomConn())
            {
                if (sourceCP.getPoint().Y < targetCP.getPoint().Y) //if the source is higher on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X - deltaX / 2, sourceCP.getPoint().Y);
                    linePath.Add(mid1);

                    mid2 = new SKPoint(sourceCP.getPoint().X - deltaX / 2, targetCP.getPoint().Y + 40);
                    linePath.Add(mid2);

                    mid3 = new SKPoint(targetCP.getPoint().X, mid2.Y);
                    linePath.Add(mid3);
                }
                else if (sourceCP.getPoint().Y > targetCP.getPoint().Y) //if the source is lower on the canvas than the target
                {
                    mid1 = new SKPoint(targetCP.getPoint().X, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);

                }
                else
                {
                    mid1 = new SKPoint(targetCP.getPoint().X, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }

            }

            //RIGHT TO TOP
            else if (getSourceCP() == source.getRightConn() && getTargetCP() == target.getTopConn())
            {
                if (sourceCP.getPoint().Y > targetCP.getPoint().Y) //if the source is lower on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X + deltaX / 2, sourceCP.getPoint().Y);
                    linePath.Add(mid1);

                    mid2 = new SKPoint(sourceCP.getPoint().X + deltaX / 2, targetCP.getPoint().Y - 40);
                    linePath.Add(mid2);


                    mid3 = new SKPoint(targetCP.getPoint().X, mid2.Y);
                    linePath.Add(mid3);
                }
                else if (sourceCP.getPoint().Y < targetCP.getPoint().Y) //if the source is higher on the canvas than the target
                {
                    mid1 = new SKPoint(targetCP.getPoint().X, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                else
                {
                    mid1 = new SKPoint(targetCP.getPoint().X, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }


            }
            //RIGHT TO BOTTOM
            else if (getSourceCP() == source.getRightConn() && getTargetCP() == target.getBottomConn())
            {
                if (sourceCP.getPoint().Y < targetCP.getPoint().Y) //if the source is higher on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X + deltaX / 2, sourceCP.getPoint().Y);
                    linePath.Add(mid1);

                    mid2 = new SKPoint(sourceCP.getPoint().X + deltaX / 2, targetCP.getPoint().Y + 40);
                    linePath.Add(mid2);

                    mid3 = new SKPoint(targetCP.getPoint().X, mid2.Y);
                    linePath.Add(mid3);
                }
                else if (sourceCP.getPoint().Y > targetCP.getPoint().Y) //if the source is lower on the canvas than the target
                {
                    mid1 = new SKPoint(targetCP.getPoint().X, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                else
                {
                    mid1 = new SKPoint(targetCP.getPoint().X, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }

            }

            //BOTTOM TO TOP CONNECTION
            else if (getSourceCP() == source.getBottomConn() && getTargetCP() == target.getTopConn())
            {
                //we draw a vertical line
                //we draw a vertical line
                if (deltaX != 0)
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y + deltaY / 2);
                    linePath.Add(mid1);
                }
                else
                {
                    mid1 = mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                }

                mid2 = new SKPoint(targetCP.getPoint().X, mid1.Y);
                linePath.Add(mid2);
                mid3 = new SKPoint(targetCP.getPoint().X, mid1.Y);
                linePath.Add(mid3);
            }

            //BOTTOM TO RIGHT CONNECTION
            else if (getSourceCP() == source.getBottomConn() && getTargetCP() == target.getRightConn())
            {
                if (sourceCP.getPoint().Y < targetCP.getPoint().Y) //if the source is higher on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                else if (sourceCP.getPoint().Y > targetCP.getPoint().Y) //if the source is lower on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y + 40);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X - deltaX / 2, sourceCP.getPoint().Y + 40);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X + deltaX / 2, targetCP.getPoint().Y);
                    linePath.Add(mid3);

                }
                
                else
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                

            }

            //BOTTOM TO LEFT CONNECTION
            else if (getSourceCP() == source.getBottomConn() && getTargetCP() == target.getLeftConn())
            {
                if (sourceCP.getPoint().Y < targetCP.getPoint().Y) //if the source is higher on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                else if (sourceCP.getPoint().Y > targetCP.getPoint().Y) //if the source is lower on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y + 40);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X + deltaX / 2, sourceCP.getPoint().Y + 40);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X - deltaX / 2, targetCP.getPoint().Y);
                    linePath.Add(mid3);

                }
                else
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);

                }

            }

          
            //TOP TO BOTTOM CONNECTION
            else if (getSourceCP() == source.getTopConn() && getTargetCP() == target.getBottomConn())
            {
                //we draw a vertical line
                if(deltaX != 0)
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y - deltaY / 2);
                    linePath.Add(mid1);
                }
                else
                {
                    mid1 = mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y);
                    linePath.Add(mid1);
                }

                mid2 = new SKPoint(targetCP.getPoint().X, mid1.Y);
                linePath.Add(mid2);
                mid3 = new SKPoint(targetCP.getPoint().X, mid1.Y);
                linePath.Add(mid3);

            }

            //TOP TO LEFT
            else if (getSourceCP() == source.getTopConn() && getTargetCP() == target.getLeftConn())
            {
                if (sourceCP.getPoint().Y < targetCP.getPoint().Y) //if the source is higher on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y - 40);
                    linePath.Add(mid1);

                    mid2 = new SKPoint(sourceCP.getPoint().X + deltaX / 2, sourceCP.getPoint().Y - 40);
                    linePath.Add(mid2);


                    mid3 = new SKPoint(targetCP.getPoint().X - deltaX / 2, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                else if (sourceCP.getPoint().Y > targetCP.getPoint().Y) //if the source is lower on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);

                }
                else
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }

            }

            //TOP TO RIGHT
            else if (getSourceCP() == source.getTopConn() && getTargetCP() == target.getRightConn())
            {
                if (sourceCP.getPoint().Y < targetCP.getPoint().Y) //if the source is higher on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y - 40);
                    linePath.Add(mid1);

                    mid2 = new SKPoint(sourceCP.getPoint().X - deltaX / 2, sourceCP.getPoint().Y - 40);
                    linePath.Add(mid2);

                    mid3 = new SKPoint(targetCP.getPoint().X + deltaX / 2, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                else if (sourceCP.getPoint().Y > targetCP.getPoint().Y) //if the source is lower on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                else
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
            }

            //TOP TO TOP
            else if (getSourceCP() == source.getTopConn() && getTargetCP() == target.getTopConn())
            {
                if (sourceCP.getPoint().X < targetCP.getPoint().X) //if the source is further left on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y - 40);
                    linePath.Add(mid1);

                    mid2 = new SKPoint(sourceCP.getPoint().X + deltaX, targetCP.getPoint().Y - 40);
                    linePath.Add(mid2);

                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                else if (sourceCP.getPoint().X > targetCP.getPoint().X) //if the source is further right on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y - 40);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X - deltaX, targetCP.getPoint().Y - 40);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                else
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
            }

            //BOTTOM TO BOTTOM
            else if (getSourceCP() == source.getBottomConn() && getTargetCP() == target.getBottomConn())
            {
                if (sourceCP.getPoint().X < targetCP.getPoint().X) //if the source is further left on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y + 40);
                    linePath.Add(mid1);

                    mid2 = new SKPoint(sourceCP.getPoint().X + deltaX, targetCP.getPoint().Y + 40);
                    linePath.Add(mid2);

                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                else if (sourceCP.getPoint().X > targetCP.getPoint().X) //if the source is further right on the canvas than the target
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y + 40);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X - deltaX, targetCP.getPoint().Y + 40);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
                else
                {
                    mid1 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid1);
                    mid2 = new SKPoint(sourceCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid2);
                    mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                    linePath.Add(mid3);
                }
            }

            else 
            {
                mid1 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y);
                linePath.Add(mid1);
                mid2 = new SKPoint(sourceCP.getPoint().X, sourceCP.getPoint().Y);
                linePath.Add(mid2);
                mid3 = new SKPoint(targetCP.getPoint().X, targetCP.getPoint().Y);
                linePath.Add(mid3);

            }

            return linePath;

        }

    }
}
