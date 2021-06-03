using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team19SKiaR12
{

    public class ShapeController
    {
        public List<Shape> shapes;
        public List<Shape> selectedShapes;
        
        public SKPaint LinePaint { get; set; }

        public Export text;

        protected Shape source;
        protected Shape target;
        protected ConnectionPoint sourceConnPt;
        protected ConnectionPoint targetConnPt;

        protected List<Connection> validConnections;

        protected string connectSourceType = "";
        protected string connectedTargetType = "";

        protected SKPoint end;
        protected SKPoint start;
        


        public List<Shape> multiSelectShape;
        public ShapeController()
        {
            this.shapes = new List<Shape>();
            this.selectedShapes = new List<Shape>();
            this.multiSelectShape = new List<Shape>();
            this.validConnections = new List<Connection>();
            

            LinePaint = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                StrokeWidth = 1,
                Style = SKPaintStyle.Stroke
            };
        }


        public void add(Shape shp)
        {
            shapes.Add(shp);
        }

        public void delete(Shape shp)
        {
            shapes.Remove(shp);
            
        }

        public void deselectShape()
        {
            if (selectedShapes.Count() != 0)
            {
                selectedShapes.First().Deselect();

                selectedShapes.Clear();
            }
        }


        public Shape getShape(SKPoint pt)
        {
            foreach (var shp in shapes)
            {
                if (shp.Contains(pt))
                {
                    return shp;
                }
            }
            return null;
        }
    
        public void selectConnectorSource(SKPoint pt)
        {
            if (shapes.Count() > 1)
            {
                foreach (var shp in shapes)
                {
                    if (shp.Contains(pt))
                    {
                        multiSelectShape.Add(shp);
                        source = shp;
                        //FIND NEAREST CONNECTION PT AND SET START POINT TO IT
                        start = source.getNearConnectionPoint(pt).getPoint();
                        sourceConnPt = source.getNearConnectionPoint(pt);

                        source.setValidPaint(false);

                        if (sourceInput(source.GetType().ToString()) == getConnectionSourceType() || getConnectionSourceType().Equals("Default"))
                        {
                            source.setValidPaint(true);
                            source.setInvalidPaint(false);
                        }
                        else
                        {
                            source.setValidPaint(false);
                            source.setInvalidPaint(true);
                        }
                      
                    }
                }
            }

        }
        public void selectShape(SKPoint p)
        {
            if (shapes.Count() != 0)
            {
                foreach (var shp in shapes)
                {
                    if (shp.Contains(p))
                    {
                        shp.Select();
                        selectedShapes.Add(shp);

                    }
                }

            }
        }

   
        public void dragSelectedShape(SKPoint delta)
        {
            if (selectedShapes.Count() == 0)
                return;

            MoveSelectedElements(delta);
        }

        public void dragConnector(SKPoint delta)
        {
            if (multiSelectShape.Count() == 0)
                return;


            

            end = new SKPoint(delta.X, delta.Y);
        }

        public void dropConnector(SKPoint delta)
        {
            foreach (var shp in shapes)
            {
                if (shp.Contains(delta) && source != null)
                {
                    target = shp;
                    if(target != source) //JUST ADDED THIS IN
                    {
                        end = target.getNearConnectionPoint(delta).getPoint();
                        targetConnPt = target.getNearConnectionPoint(delta);

                        if (sourceInput(target.GetType().ToString()) == getConnectionTargetType() && sourceInput(source.GetType().ToString()) == getConnectionSourceType() || getConnectionTargetType().Equals("Default"))
                        {
                            Connection validConnection = new Connection(source, sourceConnPt, target, targetConnPt);
                            validConnections.Add(validConnection);
                            target.setValidPaint(true);
                            target.setInvalidPaint(false);
                        }
                        else
                        {
                            target.setInvalidPaint(true);
                            target.setValidPaint(false);
                        }
                    }
        
                    source = null;
                    target = null;
                    break;
                }
            }

            //we didnt connect to a target shape, therefore the source shape should be set to null as well
            if (target == null)
            {
                //set source to null
                source = null;
            }

            multiSelectShape.Clear();
        }

        public void Draw(SKCanvas canvas)
        {
            foreach (var shp in shapes)
            {
                shp.Draw(canvas);
            }

            if (source != null)
            {
              
                canvas.DrawLine(start, end, LinePaint);
            }


            if (validConnections.Count() > 0)
            {
                foreach (var conn in validConnections)
                {
                    conn.DrawConnection(canvas);
                }

            }
        }

        private void MoveSelectedElements(SKPoint delta)
        {
            if (selectedShapes.Count() == 0)
                return;

            selectedShapes.First().Move(delta);

            //check to see if a selected shape is in a connection list
            foreach(var conn in validConnections)
            {
                if(conn.getTarget() == selectedShapes.First())
                {
                    conn.moveEndCap(delta);
                }
            }


        }

        public void showAllConnections()
        {
            foreach (var shp in shapes)
            {
                shp.setShowConnections(true);
            }
        }

        public void hideAllConnections()
        {
            foreach (var shp in shapes)
            {
                shp.setShowConnections(false);
            }
        }

        public void detach(Shape shp)
        {
            foreach (var validConn in validConnections)
            {
                if (validConn.contains(shp))
                {
                    validConn.detach();
                }
            }
        }

        
        public void setConnectionType(string connectionType)
        {
            if (connectionType.Equals("Circle - Circle"))
            {
                connectSourceType = "Circle";
                connectedTargetType = "Circle";

            }

            else if (connectionType.Equals("Circle - Triangle"))
            {
                connectSourceType = "Circle";
                connectedTargetType = "Triangle";

            }

            else if (connectionType.Equals("Rectangle - Rectangle"))
            {
                connectSourceType = "Rectangle";
                connectedTargetType = "Rectangle";

            }

            else if (connectionType.Equals("Rectangle - Triangle"))
            {
                connectSourceType = "Rectangle";
                connectedTargetType = "Triangle";

            }

            else if (connectionType.Equals("Circle - Rectangle"))
            {
                connectSourceType = "Circle";
                connectedTargetType = "Rectangle";

            }

            else if (connectionType.Equals("Triangle - Triangle"))
            {
                connectSourceType = "Triangle";
                connectedTargetType = "Triangle";

            }

            else if (connectionType.Equals("Default"))
            {
                connectSourceType = "Default";
                connectedTargetType = "Default";

            }
            else
            {
                connectSourceType = "NA";
                connectedTargetType = "Error";
            }
                
        }
        

        public string getConnectionSourceType()
        {
            return connectSourceType;
        }

        public string getConnectionTargetType()
        {
            return connectedTargetType;
        }

        public string sourceInput(string input)
        {
            string str = "";
            if(input.Contains("Rectangle"))
            {
                return "Rectangle";
            }
            else if(input.Contains("Circle"))
            {
                return "Circle";
            }
           else if(input.Contains("Triangle"))
            {
                return "Triangle";
            }
            else
                return str;
            
        }

        public void invalidatePaint()
        {
            foreach(var shp in shapes)
            {
                shp.setValidPaint(false);
                shp.setDefaultPaint(true);
                shp.setInvalidPaint(false);
            }
        }

        public void connectedShape(Shape target, SKPoint delta)
        {
            foreach(var conn in validConnections)
            {
                if(target == conn.getTarget())
                {
                    conn.moveEndCap(delta);
                }
            }
        }

    }
}
