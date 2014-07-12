using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class PixelFormatTransformTests
    {
        private static String FOLDER_IMAGES = "C:/Projects/Java.SE/modules/Net.Framework/System.Drawing/lib/src/test/resources/com/aspose/ms/System/Drawing/bitmaps/pixelformat/";

        PixelFormat[] pixelFormats = new PixelFormat[]
        {
            PixelFormat.Format16bppRgb555,
            PixelFormat.Format16bppRgb565,
            PixelFormat.Format24bppRgb,
            PixelFormat.Format32bppArgb,
            PixelFormat.Format32bppPArgb,
            PixelFormat.Format32bppRgb,    
        };
        float scaleX1 = 0.5f;
        float scaleY1 = 0.5f;
        float angle1 = 30;
        float offsetX1 = 0;
        float offsetY1 = 100;
        private Matrix matrix;
        private int bitmapWidth = 400;
        private int bitmapHeight = 400;
        
        [Test]
        public void testRectangleFormat()
        {
            Console.WriteLine("PixelFormat NET");
            Console.WriteLine("expected      -         actual ");
            foreach (PixelFormat pixelFormat in pixelFormats)
            {
                matrix = new Matrix();
                Rectangle rect = new Rectangle(150, 150, 50, 50);
                Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight, pixelFormat);
                Graphics g = prepareBitmap(actualBitmap);
                g.DrawRectangle(new Pen(Color.Aqua), rect);
                String fullPath = FOLDER_IMAGES + "PixelFormat_" + pixelFormat + "_Rectangle.bmp";
                actualBitmap.Save(fullPath);
                Bitmap bitmap1 = new Bitmap(fullPath);
               PixelFormat actualFormat = bitmap1.PixelFormat;

              
                Console.WriteLine(pixelFormat + "   -    " + actualFormat);
            }
        }

        [Test]
        public void testEllipseFormat()
        {
            foreach (var pixelFormat in pixelFormats)
            {
                matrix = new Matrix();
                Rectangle rect = new Rectangle(150, 150, 50, 50);
                Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight, pixelFormat);
                Graphics g = prepareBitmap(actualBitmap);
                g.DrawEllipse(new Pen(Color.Aqua), rect);
                actualBitmap.Save(FOLDER_IMAGES + "PixelFormat_" + pixelFormat + "_Ellipse.bmp");
            }
        }

        [Test]
        public void testCurveFormat()
        {
            foreach (var pixelFormat in pixelFormats)
            {
                matrix = new Matrix();
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
                Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight, pixelFormat);
                Graphics g = prepareBitmap(actualBitmap);
                g.DrawCurve(new Pen(Color.Aqua), points);
                actualBitmap.Save(FOLDER_IMAGES + "PixelFormat_" + pixelFormat + "_Curve.bmp");
            }
        }

        [Test]
        public void testClosedCurveFormat()
        {
            foreach (var pixelFormat in pixelFormats)
            {
                matrix = new Matrix();
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
                Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight, pixelFormat);
                Graphics graphics = prepareBitmap(actualBitmap);
                graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
                actualBitmap.Save(FOLDER_IMAGES + "PixelFormat_" + pixelFormat + "_ClosedCurve.bmp");
            }
        }

        [Test]
        public void testBezierFormat()
        {
            foreach (var pixelFormat in pixelFormats)
            {
                matrix = new Matrix();
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight, pixelFormat);
                Graphics graphics = prepareBitmap(actualBitmap);
                graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
                actualBitmap.Save(FOLDER_IMAGES + "PixelFormat_" + pixelFormat + "_Bezier.bmp");
            }
        }

        [Test]
        public void testArcFormat()
        {
            foreach (var pixelFormat in pixelFormats)
            {
                matrix = new Matrix();
                float startAngle = 45.0F;
                float sweepAngle = 270.0F;
                Rectangle rect = new Rectangle(150, 150, 50, 50);
                Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight, pixelFormat);
                Graphics graphics = prepareBitmap(actualBitmap);
                graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
                actualBitmap.Save(FOLDER_IMAGES + "PixelFormat_" + pixelFormat + "_Arc.bmp");
            }
        }

        private Graphics prepareBitmap(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            return g;
        }

        private void AddScaleTransform(Graphics g, float scaleX, float scaleY)
        {
            matrix.Scale(scaleX, scaleY);
            g.Transform = matrix;
        }

        private void AddRotateTransform(Graphics g, float angle)
        {
            PointF rotateCenter = new PointF(400, 400);
            matrix.RotateAt(angle, rotateCenter);
            g.Transform = matrix;
        }

        private void AddTranslateTransform(Graphics g, float offsetX, float offsetY)
        {
            matrix.Translate(offsetX, offsetY);
            g.Transform = matrix;
        }

        private float GetTransformCoefficient(float value, GraphicsUnit graphicsUnit)
        {
            switch (graphicsUnit)
            {
                case GraphicsUnit.Display:
                    return value;
                case GraphicsUnit.Document:
                    return value * 2;
                case GraphicsUnit.Inch:
                    return value / 100;
                case GraphicsUnit.Millimeter:
                    return value / 4;
                case GraphicsUnit.Pixel:
                    return value;
                case GraphicsUnit.Point:
                    return value;
                default:
                    return value;
            }
        }
    }
}
