using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkiaSharp.Views;
using System.IO;

namespace Team19SKiaR12
{
    public partial class MainAPP : Form
    {
        Grid grid;
        ShapeController controller;
        SKSurface surface;
        protected string exportPath;
        protected string importPath;

        protected bool export = false;
        protected bool importVal = false;

        public MainAPP()
        {
            InitializeComponent();
            grid = new Grid();
            controller = new ShapeController();
            
        }
   
        private void skControl1_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            
            surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear(SKColors.LightGray);
            grid.Draw(canvas);
            
            controller.Draw(canvas);
                

            //WRITE TO A FILE
            if (export == true && exportPath != null)
            {
                SKImage image = surface.Snapshot();
                SKData data = image.Encode(SKEncodedImageFormat.Png, 80);
                byte[] imageStream = data.ToArray();
                FileStream stm = File.Create(exportPath);
                stm.Write(imageStream, 0, imageStream.Length);
                stm.Close();
            }
            export = false;

        }

        private void skControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pointer_radio.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    controller.dragSelectedShape(e.Location.ToSKPoint());
                }
            }

            if (connector_radio.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    controller.dragConnector(e.Location.ToSKPoint());

                }
            }

            skControl1.Invalidate();
        }

     
   
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1400, 1000);
            skControl1.PaintSurface += skControl1_PaintSurface;
            skControl1.MouseWheel += SkControl1_MouseWheel;
        }

        private void SkControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (controller.getShape(e.Location.ToSKPoint()) != null)
            {
                Shape target = controller.getShape(e.Location.ToSKPoint());
                controller.connectedShape(target, e.Location.ToSKPoint());
                target.Resize(e.Delta);
            }

            skControl1.Invalidate();
        }




        /*
        private void SkControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (controller.getShape(e.Location.ToSKPoint()) != null)
            {
                Shape target = controller.getShape(e.Location.ToSKPoint());
                target.Resize(e.Delta);
            }

            skControl1.Invalidate();
        }
        */

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            Export exp = new Export();
            exp.Show();

            exportPath = exp.GetFilePath();
            export = true;
        }

        private void import_btn_Click(object sender, EventArgs e)
        {
            Import import = new Import();
            import.Show();
            importPath = import.GetFilePath();
            import.Close();
            
            importVal = true;

            Stream openImage = File.OpenRead(importPath);

            SKBitmap bitmap = SKBitmap.Decode(openImage);
            Image image = new Image(bitmap);

            /*
            SKImage dataImage = SKImage.FromEncodedData(openImage);
            Image image = new Image(dataImage);
            */
           
            controller.add(image);
                
            openImage.Close();
            
        }

        private void skControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (pointer_radio.Checked)
            {
                Shape target = controller.getShape(e.Location.ToSKPoint());

                if (target != null)
                {
                    target.setShowRectangle(false);
                    controller.deselectShape();
                }
            }

            if (connector_radio.Checked)
            {
                if (e.Button == MouseButtons.Right)
                {
                    controller.dropConnector(e.Location.ToSKPoint());
                }

            }
            skControl1.Invalidate();
        }

        private void skControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pointer_radio.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    controller.selectShape(e.Location.ToSKPoint());
                    Shape target = controller.getShape(e.Location.ToSKPoint());
                    if (target != null)
                    {
                        target.setShowRectangle(true);
                    }
                }

                if (e.Button == MouseButtons.Right)
                {
                    if (controller.getShape(e.Location.ToSKPoint()) != null)
                    {
                        Shape target = controller.getShape(e.Location.ToSKPoint());
                        controller.detach(target);
                        controller.delete(target);
                    }
                }
            }

            if (connector_radio.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    controller.selectConnectorSource(e.Location.ToSKPoint());
                }
            }
        }


        private void skControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && controller.getShape(e.Location.ToSKPoint()) != null)
            {
                controller.getShape(e.Location.ToSKPoint()).showPropertiesBox();
            }
        }


        private void CircleBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (pointer_radio.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Circle circle = new Circle(new SKPoint(e.Location.ToSKPoint().X, e.Location.ToSKPoint().Y));
                    controller.add(circle);
                    CircleBtn.DoDragDrop(circle, DragDropEffects.Move);
                    skControl1.Invalidate();

                }
            }
        }

        private void RectangleBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (pointer_radio.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Rectangle rectangle = new Rectangle(new SKPoint(e.Location.ToSKPoint().X, e.Location.ToSKPoint().Y));
                    controller.add(rectangle);
                    RectangleBtn.DoDragDrop(rectangle, DragDropEffects.Move);
                    skControl1.Invalidate();

                }
            }
        }

        private void TriBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (pointer_radio.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Triangle triangle = new Triangle(new SKPoint(e.Location.ToSKPoint().X, e.Location.ToSKPoint().Y));
                    controller.add(triangle);
                    TriBtn.DoDragDrop(triangle, DragDropEffects.Move);
                    skControl1.Invalidate();

                }
            }
        }

        private void diamond_MouseDown(object sender, MouseEventArgs e)
        {
            if (pointer_radio.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Diamond diamond = new Diamond(new SKPoint(e.Location.ToSKPoint().X, e.Location.ToSKPoint().Y));
                    controller.add(diamond);
                    diamondBtn.DoDragDrop(diamond, DragDropEffects.Move);
                    skControl1.Invalidate();

                }
            }
        }

        private void TextBtn_MouseDown(object sender, MouseEventArgs e)
        {
            if (pointer_radio.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    TextBox textbox = new TextBox(new SKPoint(e.Location.ToSKPoint().X, e.Location.ToSKPoint().Y));
                    controller.add(textbox);
                    TextBtn.DoDragDrop(textbox, DragDropEffects.Move);
                    skControl1.Invalidate();

                }
            }
        }

        private void skControl1_DragDrop(object sender, DragEventArgs e)
        {
            skControl1.Invalidate();
        }

 
        private void skControl1_DragOver(object sender, DragEventArgs e)
        {

            Point mousePoint = new Point(e.X, e.Y);
            if (e.Data.GetDataPresent(typeof(Circle)))
            {
                Circle c = (Circle)e.Data.GetData(typeof(Circle));
                c.setCirclePoint(mousePoint.ToSKPoint());
                skControl1.Invalidate();

            }
            else if (e.Data.GetDataPresent(typeof(Rectangle)))
            {
                Rectangle r = (Rectangle)e.Data.GetData(typeof(Rectangle));
                r.setRect(mousePoint.ToSKPoint());
                skControl1.Invalidate();

            }
            else if (e.Data.GetDataPresent(typeof(Triangle)))
            {
                Triangle tri = (Triangle)e.Data.GetData(typeof(Triangle));
                tri.setTrianglePoint(mousePoint.ToSKPoint());
                skControl1.Invalidate();

            }
            
            else if (e.Data.GetDataPresent(typeof(TextBox)))
            {
                TextBox text1 = (TextBox)e.Data.GetData(typeof(TextBox));
                text1.setRect(mousePoint.ToSKPoint());
                skControl1.Invalidate();

            }
            else if(e.Data.GetDataPresent(typeof(Diamond)))
            {
                Diamond diamond = (Diamond)e.Data.GetData(typeof(Diamond));
                diamond.setDiamondPoint(mousePoint.ToSKPoint());
                skControl1.Invalidate();
            }
            else
            {

            }
        }
        

        private void aboutBoxBtn_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        private void Help_Btn_Click(object sender, EventArgs e)
        {
            HelpBox help = new HelpBox();
            help.Show();
        }

        private void pointer_radio_Click(object sender, EventArgs e)
        {
            controller.hideAllConnections();

        }

        private void connector_radio_Click(object sender, EventArgs e)
        {
            controller.showAllConnections();
          
        }

        private void connectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.setConnectionType(connectionType.Text);
            controller.invalidatePaint();
        }

        private void pointer_radio_CheckedChanged(object sender, EventArgs e)
        {
            controller.invalidatePaint();
        }

        private void connector_radio_CheckedChanged(object sender, EventArgs e)
        {
            controller.invalidatePaint();
        }

        
    }
}


      

