using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class TransformStringTests
    {
        
      

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
        public void TestRotateString()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            PointF rotateCenter = new PointF(400, 400);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 400));
            rotateTransform(subGraphics, angle1);
            subGraphics.DrawString("AAA", new Font("Arial", 100), new SolidBrush(Color.Aqua), rect);
            rotateTransform(subGraphics, angle2);
            subGraphics.DrawString("BBB", new Font("Arial", 100), new SolidBrush(Color.Aqua), rect);
            graphics.DrawImage(subBitmap, 400,400);
            sourceBitmap.Save("D:\\RotateString.bmp");
        }

        [Test]
        public void TestTranslateString()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            PointF rotateCenter = new PointF(400, 400);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 400));
            translateTransform(subGraphics, offsetX1, offsetY1);
            subGraphics.DrawString("AAA", new Font("Arial", 100), new SolidBrush(Color.Aqua), rect);
            translateTransform(subGraphics, offsetX2, offsetY2);
            subGraphics.DrawString("BBB", new Font("Arial", 100), new SolidBrush(Color.Aqua), rect);
            graphics.DrawImage(subBitmap, 400,400);
            sourceBitmap.Save("D:\\TranslateString.bmp");
        }

        [Test]
        public void TestScaleString()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            PointF rotateCenter = new PointF(400, 400);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 400));
            scaleTransform(subGraphics, scaleX1, scaleY1);
            subGraphics.DrawString("AAA", new Font("Arial", 100), new SolidBrush(Color.Aqua), rect);
            scaleTransform(subGraphics, scaleX2, scaleY2);
            subGraphics.DrawString("BBB", new Font("Arial", 100), new SolidBrush(Color.Aqua), rect);
            graphics.DrawImage(subBitmap, 400,400);
            sourceBitmap.Save("D:\\ScaleString.bmp");
        }

        [Test]
        public void testWarp1()
        {
            Bitmap actualBitmap = new Bitmap(800, 200);
            Graphics graphics = Graphics.FromImage(actualBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(10, 10, 400, 400);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.AddString("AAA", new FontFamily("Arial"), (int) FontStyle.Italic, 100, rect, new StringFormat());
            int parallelogramShift = 50;
            PointF[] parallelogramPoints = new PointF[] {rect.Location, new PointF(rect.Location.X + rect.Width, rect.Location.Y),
                    new PointF(rect.Location.X + parallelogramShift, rect.Location.Y + rect.Height), new PointF(rect.Location.X + rect.Width + parallelogramShift, rect.Location.Y + rect.Height)};
            path.Warp(parallelogramPoints, rect);
            graphics.DrawPath(new Pen(Color.Aqua), path);
            actualBitmap.Save("D:\\warp_c.jpg");
        }

        [Test]
        public void testWarp2()
        {
            Bitmap actualBitmap = new Bitmap(800, 200);
            Graphics graphics = Graphics.FromImage(actualBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(10, 10, 400, 400);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.AddString("AAA", new FontFamily("Arial"), (int)FontStyle.Italic, 100, rect, new StringFormat());
            int parallelogramShift = 50;
            PointF[] parallelogramPoints = new PointF[] {rect.Location, new PointF(rect.Location.X + rect.Width, rect.Location.Y),
                    new PointF(rect.Location.X + parallelogramShift, rect.Location.Y + rect.Height), new PointF(rect.Location.X + rect.Width + parallelogramShift, rect.Location.Y + rect.Height)};
            path.Warp(parallelogramPoints, rect, new Matrix());
            graphics.DrawPath(new Pen(Color.Aqua), path);
            actualBitmap.Save("D:\\warp_c1.jpg");
        }

        [Test]
        public void testWarpBilinear()
        {
            Bitmap actualBitmap = new Bitmap(800, 200);
            Graphics graphics = Graphics.FromImage(actualBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(10, 10, 400, 400);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.AddString("AAA", new FontFamily("Arial"), (int)FontStyle.Italic, 100, rect, new StringFormat());
            int parallelogramShift = 50;
            PointF[] parallelogramPoints = new PointF[] {rect.Location, new PointF(rect.Location.X + rect.Width, rect.Location.Y),
                    new PointF(rect.Location.X + parallelogramShift, rect.Location.Y + rect.Height), new PointF(rect.Location.X + rect.Width + parallelogramShift, rect.Location.Y + rect.Height)};
            path.Warp(parallelogramPoints, rect, new Matrix(), WarpMode.Bilinear);
            graphics.DrawPath(new Pen(Color.Aqua), path);
            actualBitmap.Save("D:\\warp_c2.jpg");
        }

        [Test]
        public void testWarpPerspective()
        {
            Bitmap actualBitmap = new Bitmap(800, 200);
            Graphics graphics = Graphics.FromImage(actualBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(10, 10, 400, 400);
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            path.AddString("AAA", new FontFamily("Arial"), (int)FontStyle.Italic, 100, rect, new StringFormat());
            int parallelogramShift = 50;
            PointF[] parallelogramPoints = new PointF[] {rect.Location, new PointF(rect.Location.X + rect.Width, rect.Location.Y),
                    new PointF(rect.Location.X + parallelogramShift, rect.Location.Y + rect.Height), new PointF(rect.Location.X + rect.Width + parallelogramShift, rect.Location.Y + rect.Height)};
            path.Warp(parallelogramPoints, rect, new Matrix(), WarpMode.Perspective);
            graphics.DrawPath(new Pen(Color.Aqua), path);
            actualBitmap.Save("D:\\warp_c3.jpg");
        }

        [Test]
        public void TestScaleArc()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            PointF rotateCenter = new PointF(400, 400);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 200));
            scaleTransform(subGraphics, scaleX1, scaleY1);
            float startAngle = 45.0F;
            float sweepAngle = 270.0F;
            subGraphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            scaleTransform(subGraphics, scaleX2, scaleY2);
            subGraphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\ScaleArc.bmp");
        }

      

        [Test]
        public void TestRotateArc()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            PointF rotateCenter = new PointF(400, 400);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 200));
            rotateTransform(subGraphics, angle1);
            float startAngle = 45.0F;
            float sweepAngle = 270.0F;
            subGraphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            rotateTransform(subGraphics, angle2);
            subGraphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\RotateArc.bmp");
        }

        [Test]
        public void TestTranslateArc()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            PointF rotateCenter = new PointF(400, 400);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 200));
            translateTransform(subGraphics, offsetX1, offsetY1);
            float startAngle = 45.0F;
            float sweepAngle = 270.0F;
            subGraphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            translateTransform(subGraphics, offsetX2, offsetY2);
            subGraphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\TranslateArc.bmp");
        }

        [Test]
        public void TestScaleBezier()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            scaleTransform(subGraphics, scaleX1, scaleY1);
            Point start = new Point(100, 100);
            Point control1 = new Point(200, 10);
            Point control2 = new Point(350, 50);
            Point end = new Point(500, 100);
            subGraphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            scaleTransform(subGraphics, scaleX2, scaleY2);
            subGraphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\ScaleBezier.bmp");
        }

        [Test]
        public void TestRotateBezier()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            PointF rotateCenter = new PointF(400, 400);
            rotateTransform(subGraphics, angle1);
            Point start = new Point(100, 100);
            Point control1 = new Point(200, 10);
            Point control2 = new Point(350, 50);
            Point end = new Point(500, 100);
            subGraphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            rotateTransform(subGraphics, angle2);
            subGraphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\RotateBezier.bmp");
        }

        [Test]
        public void TestTranslateBezier()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            translateTransform(subGraphics, offsetX1, offsetY1);
            Point start = new Point(100, 100);
            Point control1 = new Point(200, 10);
            Point control2 = new Point(350, 50);
            Point end = new Point(500, 100);
            subGraphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            translateTransform(subGraphics, offsetX2, offsetY2);
            subGraphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\TranslateBezier.bmp");
        }

        [Test]
        public void TestScaleClosedCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            scaleTransform(subGraphics, scaleX1, scaleY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50),new Point(500, 100)};
            subGraphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            scaleTransform(subGraphics, scaleX2, scaleY2);
            subGraphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\ScaleClosedCurve.bmp");
        }

        [Test]
        public void TestRotateClosedCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            PointF rotateCenter = new PointF(400, 400);
            rotateTransform(subGraphics, angle1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            subGraphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            rotateTransform(subGraphics, angle2);
            subGraphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\RotateClosedCurve.bmp");
        }

        [Test]
        public void TestTranslateClosedCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            translateTransform(subGraphics, offsetX1, offsetY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            subGraphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            translateTransform(subGraphics, offsetX2, offsetY2);
            subGraphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\TranslateClosedCurve.bmp");
        }

        [Test]
        public void TestScaleCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            scaleTransform(subGraphics, scaleX1, scaleY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            subGraphics.DrawCurve(new Pen(Color.Aqua), points);
            scaleTransform(subGraphics, scaleX2, scaleY2);
            subGraphics.DrawCurve(new Pen(Color.Aqua), points);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\ScaleCurve.bmp");
        }

        [Test]
        public void TestRotateCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            PointF rotateCenter = new PointF(400, 400);
            rotateTransform(subGraphics, angle1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            subGraphics.DrawCurve(new Pen(Color.Aqua), points);
            rotateTransform(subGraphics, angle2);
            subGraphics.DrawCurve(new Pen(Color.Aqua), points);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\RotateCurve.bmp");
        }

        [Test]
        public void TestTranslateCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            translateTransform(subGraphics, offsetX1, offsetY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            subGraphics.DrawCurve(new Pen(Color.Aqua), points);
            translateTransform(subGraphics, offsetX2, offsetY2);
            subGraphics.DrawCurve(new Pen(Color.Aqua), points);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\TranslateCurve.bmp");
        }

        [Test]
        public void TestScaleEllipse()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            PointF rotateCenter = new PointF(400, 400);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 200));
            scaleTransform(subGraphics, scaleX1, scaleY1);
            subGraphics.DrawEllipse(new Pen(Color.Aqua), rect);
            scaleTransform(subGraphics, scaleX2, scaleY2);
            subGraphics.DrawEllipse(new Pen(Color.Aqua), rect);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\ScaleEllipse.bmp");
        }

        [Test]
        public void TestRotateEllipse()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            PointF rotateCenter = new PointF(400, 400);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 200));
            rotateTransform(subGraphics, angle1);
            subGraphics.DrawEllipse(new Pen(Color.Aqua), rect);
            rotateTransform(subGraphics, angle2);
            subGraphics.DrawEllipse(new Pen(Color.Aqua), rect);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\RotateEllipse.bmp");
        }

        [Test]
        public void TestTranslateEllipse()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            PointF rotateCenter = new PointF(400, 400);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 200));
            translateTransform(subGraphics, offsetX1, offsetY1);
            subGraphics.DrawEllipse(new Pen(Color.Aqua), rect);
            translateTransform(subGraphics, offsetX2, offsetY2);
            subGraphics.DrawEllipse(new Pen(Color.Aqua), rect);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\TranslateEllipse.bmp");
        }

        [Test]
        public void TestScalePolygon()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            scaleTransform(subGraphics, scaleX1, scaleY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            subGraphics.DrawPolygon(new Pen(Color.Aqua), points);
            scaleTransform(subGraphics, scaleX2, scaleY2);
            subGraphics.DrawPolygon(new Pen(Color.Aqua), points);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save("D:\\ScalePolygon.bmp");
        }

        [Test]
        public void TestRotatePolygon()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            rotateTransform(subGraphics, angle1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            subGraphics.DrawPolygon(new Pen(Color.Blue), points);
            rotateTransform(subGraphics, angle2);
            subGraphics.DrawPolygon(new Pen(Color.Blue), points);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save(LocalSettings.FOLDER_IMAGES + "RotatePolygon123.bmp"); 
        }

        [Test]
        public void TestTranslatePolygon()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Bitmap subBitmap = new Bitmap(800, 800);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            Graphics subGraphics = Graphics.FromImage(subBitmap);
            graphics.Clear(Color.White);
            subGraphics.Clear(Color.White);
            translateTransform(subGraphics, offsetX1, offsetY1);
            Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
            subGraphics.DrawPolygon(new Pen(Color.Aqua), points);
            translateTransform(subGraphics, offsetX2, offsetY2);
            subGraphics.DrawPolygon(new Pen(Color.Aqua), points);
            graphics.DrawImage(subBitmap, 400, 400);
            sourceBitmap.Save(FOLDER_IMAGES + "TranslatePolygon.bmp");
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
