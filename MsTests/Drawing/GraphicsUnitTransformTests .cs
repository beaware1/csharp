using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class GraphicsUnitTransformTests
    {


        float scaleX1 = 0.5f;
        float scaleY1 = 0.5f;
        float angle1 = 30;
        float offsetX1 = 0;
        float offsetY1 = 100;
        private Matrix matrix;
        private int bitmapWidth = 400;
        private int bitmapHeight = 400;
        GraphicsUnit[] graphicsUnits = new GraphicsUnit[]{GraphicsUnit.Display, GraphicsUnit.Document, GraphicsUnit.Inch,GraphicsUnit.Millimeter,GraphicsUnit.Pixel,GraphicsUnit.Point};
        

        [Test]
        public void testRectangleTransform()
        {
            foreach (var graphicsUnit in graphicsUnits)
            {
                matrix = new Matrix();
                Rectangle rect = new Rectangle(150, 150, 50, 50);
                Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                Graphics g = prepareBitmap(actualBitmap, graphicsUnit);
                AddScaleTransform(g, GetTransformCoefficient(scaleX1, graphicsUnit), GetTransformCoefficient(scaleY1, graphicsUnit));
                AddRotateTransform(g, angle1);
                AddTranslateTransform(g, offsetX1, offsetY1);
                g.DrawRectangle(new Pen(Color.Aqua), rect);
                actualBitmap.Save("D:\\GraphicsUnit_"+ graphicsUnit +"_Rectangle.bmp");
            }
        }

        [Test]
        public void TestEllipseTransform()
        {
            foreach (var graphicsUnit in graphicsUnits)
            {
                matrix = new Matrix();
                Rectangle rect = new Rectangle(150, 150, 50, 50);
                Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                Graphics g = prepareBitmap(actualBitmap, graphicsUnit);
                AddScaleTransform(g, GetTransformCoefficient(scaleX1, graphicsUnit), GetTransformCoefficient(scaleY1, graphicsUnit));
                AddRotateTransform(g, angle1);
                AddTranslateTransform(g, offsetX1, offsetY1);
                g.DrawEllipse(new Pen(Color.Aqua), rect);
                actualBitmap.Save("D:\\GraphicsUnit_" + graphicsUnit + "_Ellipse.bmp");
            }
        }

        [Test]
        public void TestCurveTransform()
        {
            foreach (var graphicsUnit in graphicsUnits)
            {
                matrix = new Matrix();
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
                Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                Graphics g = prepareBitmap(actualBitmap, graphicsUnit);
                AddScaleTransform(g, GetTransformCoefficient(scaleX1, graphicsUnit), GetTransformCoefficient(scaleY1, graphicsUnit));
                AddRotateTransform(g, angle1);
                AddTranslateTransform(g, offsetX1, offsetY1);
                g.DrawCurve(new Pen(Color.Aqua), points);
                actualBitmap.Save("D:\\GraphicsUnit_" + graphicsUnit + "_Curve.bmp");
            }
        }

        [Test]
        public void TestClosedCurveTransform()
        {
            foreach (var graphicsUnit in graphicsUnits)
            {
                matrix = new Matrix();
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
                Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                Graphics g = prepareBitmap(actualBitmap, graphicsUnit);
                AddScaleTransform(g, GetTransformCoefficient(scaleX1, graphicsUnit), GetTransformCoefficient(scaleY1, graphicsUnit));
                AddRotateTransform(g, angle1);
                AddTranslateTransform(g, offsetX1, offsetY1);
                g.DrawClosedCurve(new Pen(Color.Aqua), points);
                actualBitmap.Save("D:\\GraphicsUnit_" + graphicsUnit + "_ClosedCurve.bmp");
            }
        }

        [Test]
        public void TestBezierTransform()
        {
            foreach (var graphicsUnit in graphicsUnits)
            {
                matrix = new Matrix();
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                Graphics g = prepareBitmap(actualBitmap, graphicsUnit);
//                AddScaleTransform(g, GetTransformCoefficient(scaleX1, graphicsUnit), GetTransformCoefficient(scaleY1, graphicsUnit));
//                AddRotateTransform(g, angle1);
//                AddTranslateTransform(g, offsetX1, offsetY1);
                g.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
                actualBitmap.Save("D:\\GraphicsUnit_" + graphicsUnit + "_Bezier.bmp");
            }
        }

        [Test]
        public void TestArcTransform()
        {
            foreach (var graphicsUnit in graphicsUnits)
            {
                matrix = new Matrix();
                float startAngle = 45.0F;
                float sweepAngle = 270.0F;
                Rectangle rect = new Rectangle(150, 150, 50, 50);
                Bitmap actualBitmap = new Bitmap(bitmapWidth, bitmapHeight);
                Graphics g = prepareBitmap(actualBitmap, graphicsUnit);
//                AddScaleTransform(g, GetTransformCoefficient(scaleX1, graphicsUnit), GetTransformCoefficient(scaleY1, graphicsUnit));
//                AddRotateTransform(g, angle1);
//                AddTranslateTransform(g, offsetX1, offsetY1);
                g.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
                actualBitmap.Save("D:\\GraphicsUnit_" + graphicsUnit + "_Arc.jpg");
            }
        }

        private Graphics prepareBitmap(Bitmap bmp, GraphicsUnit graphicsUnit)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.PageUnit = graphicsUnit;
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
                    return value/100;
                case GraphicsUnit.Millimeter:
                    return value/4;
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
