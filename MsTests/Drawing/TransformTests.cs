using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class TransformTests
    {
        private static String FOLDER_IMAGES = "C:/Projects/Java.SE/modules/Net.Framework/System.Drawing/lib/src/test/resources/com/aspose/ms/System/Drawing/bitmaps/";
        [Test]
        public void TestHorizontalShift()
        {
            Bitmap sourceBitmap = new Bitmap(800, 200);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(10,10, 400, 400);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.AddString("AAA", new FontFamily("Arial"), (int)FontStyle.Italic, 100, rect, new StringFormat());
            Matrix matrix = new Matrix();
            matrix.Translate(200, 0);
            path.Transform(matrix);
            graphics.DrawPath(new Pen(Color.Aqua), path);
            sourceBitmap.Save("C:/Images/tt.bmp");
        }
        [Test]
        public void TestSmallHorizontalShift()
        {
            Bitmap sourceBitmap = new Bitmap(800, 200);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(10,10, 400, 400);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.AddString("AAA", new FontFamily("Arial"), (int)FontStyle.Italic, 100, rect, new StringFormat());
            Matrix matrix = new Matrix();
            matrix.Translate(4, 0);
            path.Transform(matrix);
            graphics.DrawPath(new Pen(Color.Aqua), path);
            sourceBitmap.Save("C:/Images/shift3.bmp");
        }

        [Test]
        public void TestVerticalShift()
        {
            Bitmap sourceBitmap = new Bitmap(400, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(10,10, 200, 400);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.AddString("AA", new FontFamily("Arial"), (int)FontStyle.Italic, 100, rect, new StringFormat());
            Matrix matrix = new Matrix();
            matrix.Translate(0, 200);
            path.Transform(matrix);
            graphics.DrawPath(new Pen(Color.Aqua), path);
            sourceBitmap.Save("C:/Images/tt.bmp");
        }

        [Test]
        public void TestSmallVerticalShift()
        {
            Bitmap sourceBitmap = new Bitmap(400, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(10,10, 200, 400);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.AddString("AA", new FontFamily("Arial"), (int)FontStyle.Italic, 100, rect, new StringFormat());
            Matrix matrix = new Matrix();
            matrix.Translate(0, 4);
            path.Transform(matrix);
            graphics.DrawPath(new Pen(Color.Aqua), path);
            sourceBitmap.Save("C:/Images/shift4.bmp");
        }

        [Test]
        public void TestRotateAt()
        {
            for (int i = 0; i < 360; i += 30)
            {
                Bitmap sourceBitmap = new Bitmap(400, 400);
                Graphics graphics = Graphics.FromImage(sourceBitmap);
                graphics.Clear(Color.White);
                Rectangle rect = new Rectangle(0, 0, 20, 40);
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(rect);
                path.AddString("A", new FontFamily("Arial"), (int)FontStyle.Italic, 25, rect, new StringFormat());
                Matrix matrix = new Matrix();
                matrix.RotateAt(i, new PointF(200, 200));
                matrix.Translate(200, 200);
                path.Transform(matrix);
                graphics.DrawPath(new Pen(Color.Black), path);
                sourceBitmap.Save("C:/Images/rotate" + i + ".bmp");
            }
        }

        [Test]
        public void TestRotate()
        {
            for (int i = 30; i < 360; i += 300)
            {
                Bitmap sourceBitmap = new Bitmap(800, 800);
                Graphics graphics = Graphics.FromImage(sourceBitmap);
                graphics.Clear(Color.White);
                Rectangle rect = new Rectangle(0, 0, 20, 40);
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(rect);
                path.AddString("A", new FontFamily("Arial"), (int)FontStyle.Italic, 25, rect, new StringFormat());
                Matrix matrix = new Matrix();
                matrix.Rotate(i, MatrixOrder.Append);
                matrix.Translate(400, 400);
                path.Transform(matrix);
                graphics.DrawPath(new Pen(Color.Black), path);
                sourceBitmap.Save(FOLDER_IMAGES + "rotate1_" + i + ".bmp");
            }
        }

        [Test]
        public void TestScale1()
        {
            Bitmap sourceBitmap = new Bitmap(800, 200);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(10, 10, 400, 400);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.AddString("AAA", new FontFamily("Arial"), (int)FontStyle.Italic, 100, rect, new StringFormat());
            Matrix matrix = new Matrix();
            matrix.Scale(0.1f, 0.1f);
            path.Transform(matrix);
            graphics.DrawPath(new Pen(Color.Aqua), path);
            sourceBitmap.Save("C:/Images/scale0_1.bmp");
        }

        [Test]
        public void TestScale2()
        {
            Bitmap sourceBitmap = new Bitmap(800, 200);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(10, 10, 400, 400);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.AddString("AAA", new FontFamily("Arial"), (int)FontStyle.Italic, 100, rect, new StringFormat());
            Matrix matrix = new Matrix();
            matrix.Scale(2f, 2f);
            path.Transform(matrix);
            graphics.DrawPath(new Pen(Color.Aqua), path);
            sourceBitmap.Save("C:/Images/scale0_2.bmp");
        }

        [Test]
        public void TestInvert()
        {
            Bitmap sourceBitmap = new Bitmap(800, 200);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.Red);
            RectangleF rect = new RectangleF(10, 10, 400, 400);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.AddString("AAA", new FontFamily("Arial"), (int)FontStyle.Italic, 100, rect, new StringFormat());

//            SolidBrush solidBrush = new SolidBrush(
//            Color.FromArgb(255, 255, 0, 0));
//            graphics.FillEllipse(solidBrush, 0, 0, 100, 60);

            
            Matrix matrix = new Matrix();
            matrix.Invert();
            path.Transform(matrix);
            graphics.DrawPath(new Pen(Color.Aqua), path);
            sourceBitmap.Save(FOLDER_IMAGES + "bitmap_invert1.bmp");
        }

        [Test]
        public void TestMultiply()
        {
            Bitmap sourceBitmap = new Bitmap(800, 200);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(0, 0, 500, 500);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.AddString("AAA", new FontFamily("Arial"), (int)FontStyle.Italic, 100, rect, new StringFormat());

            Pen pen1 = new Pen(Color.Blue, 1);
            Pen pen2 = new Pen(Color.Red, 1);
            Pen pen3 = new Pen(Color.DarkCyan, 1);

            Matrix matrix1 = new Matrix(2.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f);
            path.Transform(matrix1);
            graphics.DrawPath(pen1, path);
            sourceBitmap.Save(FOLDER_IMAGES + "matrix1.bmp");


            Matrix matrix2 = new Matrix(0.0f, 1.0f, -1.0f, 0.0f, 200.0f, 120.0f);
            matrix1.Multiply(matrix2, MatrixOrder.Append);
            path.Transform(matrix1);
            graphics.DrawPath(pen2, path);
            sourceBitmap.Save(FOLDER_IMAGES + "matrix2.bmp");

            Matrix matrix3 = new Matrix(1.0f, 0.0f, 0.0f, 1.0f, 250.0f, 50.0f);
            matrix1.Multiply(matrix3, MatrixOrder.Append);
            path.Transform(matrix1);
            graphics.DrawPath(pen3, path);
            sourceBitmap.Save(FOLDER_IMAGES + "matrix3.bmp");
       }
        
        [Test]
        public void TestTransformPoints()
        {
            Bitmap sourceBitmap = new Bitmap(800, 200);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
           
            GraphicsPath path = new GraphicsPath();
           
            Pen pen1 = new Pen(Color.Blue, 1);
            Pen pen2 = new Pen(Color.Red, 1);

            // Create an array of points.
            Point[] points =
             {
                 new Point(20, 20),
                 new Point(120, 20),
                 new Point(120, 120),
                 new Point(20, 120),
                 new Point(20,20)
             };

            graphics.DrawLines(pen1, points);
            sourceBitmap.Save(FOLDER_IMAGES + "transform-points1.bmp");

            Matrix matrix = new Matrix();
            matrix.Scale(3, 2, MatrixOrder.Append);
            matrix.TransformPoints(points);

            graphics.DrawLines(pen2, points);
            sourceBitmap.Save(FOLDER_IMAGES + "transform-points2.bmp");
       }

    }
}
