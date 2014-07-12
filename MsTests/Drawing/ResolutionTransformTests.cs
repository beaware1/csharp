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
    class ResolutionTransformTests
    {
        float[] resolutions = new float[]
        {
            75, 150, 300, 600
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
        public void testRectangleTransform()
        {
            foreach (float xResolution in resolutions)
            {
                foreach (float yResolution in resolutions)
                {
                    matrix = new Matrix();
                    Rectangle rect = new Rectangle(150, 150, 50, 50);
                    Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                    Graphics g = prepareBitmap(actualBitmap, xResolution, yResolution);
                    AddScaleTransform(g, scaleX1, scaleY1);
                    AddRotateTransform(g, angle1);
                    AddTranslateTransform(g, offsetX1, offsetY1);
                    g.DrawRectangle(new Pen(Color.Aqua), rect);
                    actualBitmap.Save("D:\\_" + xResolution +"_"+ yResolution +"_Rectangle.tiff");
                }
            }
        }

        [Test]
        public void TestEllipseTransform()
        {
            foreach (float xResolution in resolutions)
            {
                foreach (float yResolution in resolutions)
                {
                    matrix = new Matrix();
                    Rectangle rect = new Rectangle(150, 150, 50, 50);
                    Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                    Graphics g = prepareBitmap(actualBitmap, xResolution, yResolution);
                    AddScaleTransform(g, scaleX1, scaleY1);
                    AddRotateTransform(g, angle1);
                    AddTranslateTransform(g, offsetX1, offsetY1);
                    g.DrawEllipse(new Pen(Color.Aqua), rect);
                    actualBitmap.Save("D:\\_" + xResolution + "_" + yResolution + "_Ellipse.tiff");
                }
            }
        }

        [Test]
        public void TestCurveTransform()
        {
            foreach (float xResolution in resolutions)
            {
                foreach (float yResolution in resolutions)
                {
                    matrix = new Matrix();
                    Point[] points = new Point[]
                    {new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100)};
                    Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                    Graphics g = prepareBitmap(actualBitmap, xResolution, yResolution);
                    AddScaleTransform(g, scaleX1, scaleY1);
                    AddRotateTransform(g, angle1);
                    AddTranslateTransform(g, offsetX1, offsetY1);
                    g.DrawCurve(new Pen(Color.Aqua), points);
                    actualBitmap.Save("D:\\_" + xResolution + "_" + yResolution + "_Curve.tiff");
                }
            }
        }

        [Test]
        public void TestClosedCurveTransform()
        {
            foreach (float xResolution in resolutions)
            {
                foreach (float yResolution in resolutions)
                {
                    matrix = new Matrix();
                    Point[] points = new Point[]
                    {new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100)};
                    Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                    Graphics g = prepareBitmap(actualBitmap, xResolution, yResolution);
                    AddScaleTransform(g, scaleX1, scaleY1);
                    AddRotateTransform(g, angle1);
                    AddTranslateTransform(g, offsetX1, offsetY1);
                    g.DrawClosedCurve(new Pen(Color.Aqua), points);
                    actualBitmap.Save("D:\\_" + xResolution + "_" + yResolution + "_ClosedCurve.tiff");
                }
            }
        }

        [Test]
        public void TestBezierTransform()
        {
            foreach (float xResolution in resolutions)
            {
                foreach (float yResolution in resolutions)
                {
                    matrix = new Matrix();
                    Point start = new Point(100, 100);
                    Point control1 = new Point(200, 10);
                    Point control2 = new Point(350, 50);
                    Point end = new Point(500, 100);
                    Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                    Graphics g = prepareBitmap(actualBitmap, xResolution, yResolution);
                    AddScaleTransform(g, scaleX1, scaleY1);
                    AddRotateTransform(g, angle1);
                    AddTranslateTransform(g, offsetX1, offsetY1);
                    g.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
                    actualBitmap.Save("D:\\_" + xResolution + "_" + yResolution + "_Bezier.tiff");
                }
            }
        }

        [Test]
        public void TestArcTransform()
        {
            foreach (float xResolution in resolutions)
            {
                foreach (float yResolution in resolutions)
                {
                    matrix = new Matrix();
                    float startAngle = 45.0F;
                    float sweepAngle = 270.0F;
                    Rectangle rect = new Rectangle(150, 150, 50, 50);
                    Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                    Graphics g = prepareBitmap(actualBitmap, xResolution, yResolution);
                    AddScaleTransform(g, scaleX1, scaleY1);
                    g.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
                    AddRotateTransform(g, angle1);
                    g.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
                    AddTranslateTransform(g, offsetX1, offsetY1);
                    g.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
                    actualBitmap.Save("D:\\_" + xResolution + "_" + yResolution + "_Arc.tiff");
                }
            }
        }

        private Graphics prepareBitmap(Bitmap bmp, float xResolution, float yResolution)
        {
            bmp.SetResolution(xResolution, yResolution);
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
    }
}
