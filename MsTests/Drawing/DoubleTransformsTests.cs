using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class DoubleTransformsTests
    {
        private static String FOLDER_IMAGES = "C:/Projects/Java.SE/modules/Net.Framework/System.Drawing/lib/src/test/resources/com/aspose/ms/System/Drawing/bitmaps/";

        float scaleX1 = 0.1f;
        float scaleY1 = 0.1f;
        float scaleX2 = 2.0f;
        float scaleY2 = 2.0f;
        float angle1 = 30;
        float angle2 = 270;
        float offsetX1 = 0;
        float offsetY1 = 100;
        float offsetX2 = 100;
        float offsetY2 = 0;
        private Matrix matrix;

        [SetUp]
        public void SetUp()
        {
            matrix = new Matrix();
        }

        [Test]
        public void TestScaleAndTranslateArc()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            PointF leftTopPoint = new PointF(400, 400);
            RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
            scaleTransform(graphics, scaleX1, scaleY1);
            float startAngle = 45.0F;
            float sweepAngle = 270.0F;
            graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            scaleTransform(graphics, scaleX2, scaleY2);
            graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            translateTransform(graphics, offsetX1, offsetY1);
            graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndTranslateArc.bmp");
        }

        [Test]
        public void TestScaleAndRotateArc()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            PointF leftTopPoint = new PointF(400, 400);
            RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
            scaleTransform(graphics, scaleX1, scaleY1);
            float startAngle = 45.0F;
            float sweepAngle = 270.0F;
            graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            rotateTransform(graphics, angle2);
            graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);

            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndRotateArc.bmp");
        }

        [Test]
        public void TestTranslateAndRotateArc()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            PointF leftTopPoint = new PointF(400, 400);
            RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
            translateTransform(graphics, offsetX1, offsetY1);
            float startAngle = 45.0F;
            float sweepAngle = 270.0F;
            graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            rotateTransform(graphics, angle2);
            graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);

            sourceBitmap.Save(FOLDER_IMAGES + "TranslateAndRotateArc.bmp");
        }

        [Test]
        public void TestScaleAndTranslateBezier()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            PointF leftTopPoint = new PointF(400, 400);
            scaleTransform(graphics, scaleX1, scaleY1);
            Point start = new Point(100, 100);
            Point control1 = new Point(200, 10);
            Point control2 = new Point(350, 50);
            Point end = new Point(500, 100);
            graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            translateTransform(graphics, offsetX1, offsetY1);
            graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndTranslateBezier.bmp");
        }

        [Test]
        public void TestScaleAndRotateBezier()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            PointF leftTopPoint = new PointF(400, 400);
            scaleTransform(graphics, scaleX1, scaleY1);
            Point start = new Point(100, 100);
            Point control1 = new Point(200, 10);
            Point control2 = new Point(350, 50);
            Point end = new Point(500, 100);
            graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            rotateTransform(graphics, angle2);
            graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndRotateBezier.bmp");
        }

        [Test]
        public void TestTranslateAndRotateBezier()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            PointF leftTopPoint = new PointF(400, 400);
            RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
            translateTransform(graphics, offsetX1, offsetY1);
            Point start = new Point(100, 100);
            Point control1 = new Point(200, 10);
            Point control2 = new Point(350, 50);
            Point end = new Point(500, 100);
            graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            rotateTransform(graphics, angle2);
            graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            sourceBitmap.Save(FOLDER_IMAGES + "TranslateAndRotateBezier.bmp");
        }

        [Test]
        public void TestScaleAndTranslateClosedCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            scaleTransform(graphics, scaleX1, scaleY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            translateTransform(graphics, offsetX1, offsetY1);
            graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndTranslateClosedCurve.bmp");
        }

        [Test]
        public void TestScaleAndRotateClosedCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            scaleTransform(graphics, scaleX1, scaleY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            rotateTransform(graphics, angle2);
            graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndRotateClosedCurve.bmp");
        }

        [Test]
        public void TestTranslateAndRotateClosedCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            translateTransform(graphics, offsetX1, offsetY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            rotateTransform(graphics, angle2);
            graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            sourceBitmap.Save(FOLDER_IMAGES + "TranslateAndRotateClosedCurve.bmp");
        }
      

        [Test]
        public void TestScaleAndTranslateCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            scaleTransform(graphics, scaleX1, scaleY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            graphics.DrawCurve(new Pen(Color.Aqua), points);
            translateTransform(graphics, offsetX1, offsetY1);
            graphics.DrawCurve(new Pen(Color.Aqua), points);
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndTranslateCurve.bmp");
        }

        [Test]
        public void TestScaleAndRotateCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            scaleTransform(graphics, scaleX1, scaleY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            graphics.DrawCurve(new Pen(Color.Aqua), points);
            rotateTransform(graphics, angle2);
            graphics.DrawCurve(new Pen(Color.Aqua), points);
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndRotateCurve.bmp");
        }

        [Test]
        public void TestTranslateAndRotateCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            translateTransform(graphics, offsetX1, offsetY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            graphics.DrawCurve(new Pen(Color.Aqua), points);
            rotateTransform(graphics, angle2);
            graphics.DrawCurve(new Pen(Color.Aqua), points);
            sourceBitmap.Save(FOLDER_IMAGES + "TranslateAndRotateCurve.bmp");
        }

        [Test]
        public void TestScaleAndTranslateEllipse()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            PointF leftTopPoint = new PointF(400, 400);
            RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
            scaleTransform(graphics, scaleX1, scaleY1);
            graphics.DrawEllipse(new Pen(Color.Aqua), rect);
            translateTransform(graphics, offsetX1, offsetY1);
            graphics.DrawEllipse(new Pen(Color.Aqua), rect);
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndTranslateEllipse.bmp");
        }

        [Test]
        public void TestScaleAndRotateEllipse()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            PointF leftTopPoint = new PointF(400, 400);
            RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
            scaleTransform(graphics, scaleX1, scaleY1);
            graphics.DrawEllipse(new Pen(Color.Aqua), rect);
            rotateTransform(graphics, angle1);
            graphics.DrawEllipse(new Pen(Color.Aqua), rect);
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndRotateEllipse.bmp");
        }

        [Test]
        public void TestTranslateAndRotateEllipse()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            PointF leftTopPoint = new PointF(400, 400);
            RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
            translateTransform(graphics, offsetX1, offsetY1);
            graphics.DrawEllipse(new Pen(Color.Aqua), rect);
            rotateTransform(graphics, angle1);
            graphics.DrawEllipse(new Pen(Color.Aqua), rect);
            sourceBitmap.Save(FOLDER_IMAGES + "TranslateAndRotateEllipse.bmp");
        }

        [Test]
        public void TestScaleAndTranslatePolygon()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            scaleTransform(graphics, scaleX1, scaleY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            graphics.DrawPolygon(new Pen(Color.Blue), points);
            translateTransform(graphics, offsetX1, offsetY1);
            graphics.DrawPolygon(new Pen(Color.Red), points);
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndTranslatePolygon.bmp");
        }

        [Test]
        public void TestScaleAndRotatePolygon()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            scaleTransform(graphics, scaleX1, scaleY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            graphics.DrawPolygon(new Pen(Color.Aqua), points);
            rotateTransform(graphics, angle1);
            graphics.DrawPolygon(new Pen(Color.Aqua), points);
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndRotatePolygon.bmp");
        }

        [Test]
        public void TestTranslateAndRotatePolygon()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            translateTransform(graphics, offsetX1, offsetY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            graphics.DrawPolygon(new Pen(Color.Aqua), points);
            rotateTransform(graphics, angle1);
            graphics.DrawPolygon(new Pen(Color.Aqua), points);
            sourceBitmap.Save(FOLDER_IMAGES + "TranslateAndRotatePolygon.bmp");
        }

        [Test]
        public void TestScaleAndTranslateString()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            scaleTransform(graphics, scaleX1, scaleY1);
            PointF rotateCenter = new PointF(400, 400);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 400));
            graphics.DrawString("AAA", new Font("Arial", 100), new SolidBrush(Color.Blue), rect);
            translateTransform(graphics, offsetX1, offsetY1);
            graphics.DrawString("BBB", new Font("Arial", 100), new SolidBrush(Color.Blue), rect);
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndTranslateString.bmp");
        }

        [Test]
        public void TestScaleAndRotateString()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            scaleTransform(graphics, scaleX1, scaleY1);
            PointF rotateCenter = new PointF(400, 400);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 400));
            graphics.DrawString("AAA", new Font("Arial", 100), new SolidBrush(Color.Blue), rect);
            rotateTransform(graphics, angle1);
            graphics.DrawString("BBB", new Font("Arial", 100), new SolidBrush(Color.Blue), rect);
            sourceBitmap.Save(FOLDER_IMAGES + "ScaleAndRotateString.bmp");
        }

        [Test]
        public void TestTranslateAndRotateString()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            translateTransform(graphics, offsetX1, offsetY1);
            PointF rotateCenter = new PointF(400, 400);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 400));
            graphics.DrawString("AAA", new Font("Arial", 100), new SolidBrush(Color.Blue), rect);
            rotateTransform(graphics, angle1);
            graphics.DrawString("BBB", new Font("Arial", 100), new SolidBrush(Color.Blue), rect);
            sourceBitmap.Save(FOLDER_IMAGES + "TranslateAndRotateString.bmp");
        }




        public void scaleTransform(Graphics g, float scaleX, float scaleY)
        {
            matrix.Scale(scaleX, scaleY);
            g.Transform = matrix;
        }

        public void rotateTransform(Graphics g, float angle)
        {
            PointF rotateCenter = new PointF(400, 400);
            matrix.RotateAt(angle, rotateCenter);
            g.Transform = (matrix);
        }

        public void translateTransform(Graphics g, float offsetX, float offsetY)
        {
            matrix.Translate(offsetX, offsetY);
            g.Transform = matrix;
        }
       
    }
}
