using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class MetafileTransformTests
    {
      private String pathMetafiles = Utils.METAFILES_PATH + Utils.IMAGES_SPATH + Utils.CS_MF_SPATH;
        private String pathPng = Utils.METAFILES_PATH + Utils.IMAGES_SPATH + Utils.CS_PNG_SPATH;

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
            String imageName = "ScaleAndTranslateArc";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                PointF leftTopPoint = new PointF(400, 400);
                RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
                scaleTransform(graphics, scaleX1, scaleY1);
                float startAngle = 45.0F;
                float sweepAngle = 270.0F;
                graphics.DrawArc(new Pen(Color.Red), rect, startAngle, sweepAngle);
                scaleTransform(graphics, scaleX2, scaleY2);
                graphics.DrawArc(new Pen(Color.Red), rect, startAngle, sweepAngle);
                translateTransform(graphics, offsetX1, offsetY1);
                graphics.DrawArc(new Pen(Color.Red), rect, startAngle, sweepAngle);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestScaleAndRotateArc()
        {
            String imageName = "ScaleAndRotateArc";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                PointF leftTopPoint = new PointF(400, 400);
                RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
                scaleTransform(graphics, scaleX1, scaleY1);
                float startAngle = 45.0F;
                float sweepAngle = 270.0F;
                graphics.DrawArc(new Pen(Color.Red), rect, startAngle, sweepAngle);
                rotateTransform(graphics, angle2);
                graphics.DrawArc(new Pen(Color.Red), rect, startAngle, sweepAngle);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestTranslateAndRotateArc()
        {
            String imageName = "TranslateAndRotateArc";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                PointF leftTopPoint = new PointF(400, 400);
                RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
                translateTransform(graphics, offsetX1, offsetY1);
                float startAngle = 45.0F;
                float sweepAngle = 270.0F;
                graphics.DrawArc(new Pen(Color.Red), rect, startAngle, sweepAngle);
                rotateTransform(graphics, angle2);
                graphics.DrawArc(new Pen(Color.Red), rect, startAngle, sweepAngle);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestScaleAndTranslateBezier()
        {
            String imageName = "ScaleAndTranslateBezier";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                scaleTransform(graphics, scaleX1, scaleY1);
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                graphics.DrawBezier(new Pen(Color.Red), start, control1, control2, end);
                translateTransform(graphics, offsetX1, offsetY1);
                graphics.DrawBezier(new Pen(Color.Red), start, control1, control2, end);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestScaleAndRotateBezier()
        {
            String imageName = "ScaleAndRotateBezier";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                scaleTransform(graphics, scaleX1, scaleY1);
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                graphics.DrawBezier(new Pen(Color.Red), start, control1, control2, end);
                rotateTransform(graphics, angle2);
                graphics.DrawBezier(new Pen(Color.Red), start, control1, control2, end);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestTranslateAndRotateBezier()
        {
            String imageName = "TranslateAndRotateBezier";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                PointF leftTopPoint = new PointF(400, 400);
                RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
                translateTransform(graphics, offsetX1, offsetY1);
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                graphics.DrawBezier(new Pen(Color.Red), start, control1, control2, end);
                rotateTransform(graphics, angle2);
                graphics.DrawBezier(new Pen(Color.Red), start, control1, control2, end);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestScaleAndTranslateClosedCurve()
        {
            String imageName = "ScaleAndTranslateClosedCurve";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                scaleTransform(graphics, scaleX1, scaleY1);
                Point[] points = new Point[]
                {new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100)};
                graphics.DrawClosedCurve(new Pen(Color.Red), points);
                translateTransform(graphics, offsetX1, offsetY1);
                graphics.DrawClosedCurve(new Pen(Color.Red), points);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestScaleAndRotateClosedCurve()
        {
            String imageName = "ScaleAndRotateClosedCurve";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                scaleTransform(graphics, scaleX1, scaleY1);
                Point[] points = new Point[]
                {new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100)};
                graphics.DrawClosedCurve(new Pen(Color.Red), points);
                rotateTransform(graphics, angle2);
                graphics.DrawClosedCurve(new Pen(Color.Red), points);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestTranslateAndRotateClosedCurve()
        {
            String imageName = "TranslateAndRotateClosedCurve";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                translateTransform(graphics, offsetX1, offsetY1);
                Point[] points = new Point[]
                {new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100)};
                graphics.DrawClosedCurve(new Pen(Color.Red), points);
                rotateTransform(graphics, angle2);
                graphics.DrawClosedCurve(new Pen(Color.Red), points);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }


        [Test]
        public void TestScaleAndTranslateCurve()
        {
            String imageName = "ScaleAndTranslateCurve";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                scaleTransform(graphics, scaleX1, scaleY1);
                Point[] points = new Point[]
                {new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100)};
                graphics.DrawCurve(new Pen(Color.Red), points);
                translateTransform(graphics, offsetX1, offsetY1);
                graphics.DrawCurve(new Pen(Color.Red), points);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestScaleAndRotateCurve()
        {
            String imageName = "ScaleAndRotateCurve";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                scaleTransform(graphics, scaleX1, scaleY1);
                Point[] points = new Point[]
                {new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100)};
                graphics.DrawCurve(new Pen(Color.Red), points);
                rotateTransform(graphics, angle2);
                graphics.DrawCurve(new Pen(Color.Red), points);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestTranslateAndRotateCurve()
        {
            String imageName = "TranslateAndRotateCurve";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                translateTransform(graphics, offsetX1, offsetY1);
                Point[] points = new Point[]
                {new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100)};
                graphics.DrawCurve(new Pen(Color.Red), points);
                rotateTransform(graphics, angle2);
                graphics.DrawCurve(new Pen(Color.Red), points);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestScaleAndTranslateEllipse()
        {
            String imageName = "ScaleAndTranslateEllipse";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                PointF leftTopPoint = new PointF(400, 400);
                RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
                scaleTransform(graphics, scaleX1, scaleY1);
                graphics.DrawEllipse(new Pen(Color.Red), rect);
                translateTransform(graphics, offsetX1, offsetY1);
                graphics.DrawEllipse(new Pen(Color.Red), rect);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestScaleAndRotateEllipse()
        {
            String imageName = "ScaleAndRotateEllipse";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                PointF leftTopPoint = new PointF(400, 400);
                RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
                scaleTransform(graphics, scaleX1, scaleY1);
                graphics.DrawEllipse(new Pen(Color.Red), rect);
                rotateTransform(graphics, angle1);
                graphics.DrawEllipse(new Pen(Color.Red), rect);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestTranslateAndRotateEllipse()
        {
            String imageName = "TranslateAndRotateEllipse";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                PointF leftTopPoint = new PointF(400, 400);
                RectangleF rect = new RectangleF(leftTopPoint, new SizeF(400, 200));
                translateTransform(graphics, offsetX1, offsetY1);
                graphics.DrawEllipse(new Pen(Color.Red), rect);
                rotateTransform(graphics, angle1);
                graphics.DrawEllipse(new Pen(Color.Red), rect);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestScaleAndTranslatePolygon()
        {
            String imageName = "ScaleAndTranslatePolygon";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                scaleTransform(graphics, scaleX1, scaleY1);
                Point[] points = new Point[]
                {new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100)};
                graphics.DrawPolygon(new Pen(Color.Blue), points);
                translateTransform(graphics, offsetX1, offsetY1);
                graphics.DrawPolygon(new Pen(Color.Red), points);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestScaleAndRotatePolygon()
        {
            String imageName = "ScaleAndRotatePolygon";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                scaleTransform(graphics, scaleX1, scaleY1);
                Point[] points = new Point[]
                {new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100)};
                graphics.DrawPolygon(new Pen(Color.Red), points);
                rotateTransform(graphics, angle1);
                graphics.DrawPolygon(new Pen(Color.Red), points);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestTranslateAndRotatePolygon()
        {
            String imageName = "TranslateAndRotatePolygon";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                translateTransform(graphics, offsetX1, offsetY1);
                Point[] points = new Point[]
                {new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100)};
                graphics.DrawPolygon(new Pen(Color.Red), points);
                rotateTransform(graphics, angle1);
                graphics.DrawPolygon(new Pen(Color.Red), points);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestScaleAndTranslateString()
        {
            String imageName = "ScaleAndTranslateString";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                scaleTransform(graphics, scaleX1, scaleY1);
                PointF rotateCenter = new PointF(400, 400);
                RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 400));
                graphics.DrawString("AAA", new Font("Arial", 100), new SolidBrush(Color.Blue), rect);
                translateTransform(graphics, offsetX1, offsetY1);
                graphics.DrawString("BBB", new Font("Arial", 100), new SolidBrush(Color.Blue), rect);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestScaleAndRotateString()
        {
            String imageName = "ScaleAndRotateString";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                scaleTransform(graphics, scaleX1, scaleY1);
                PointF rotateCenter = new PointF(400, 400);
                RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 400));
                graphics.DrawString("AAA", new Font("Arial", 100), new SolidBrush(Color.Blue), rect);
                rotateTransform(graphics, angle1);
                graphics.DrawString("BBB", new Font("Arial", 100), new SolidBrush(Color.Blue), rect);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestTranslateAndRotateString()
        {
            String imageName = "TranslateAndRotateString";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                translateTransform(graphics, offsetX1, offsetY1);
                PointF rotateCenter = new PointF(400, 400);
                RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 400));
                graphics.DrawString("AAA", new Font("Arial", 100), new SolidBrush(Color.Blue), rect);
                rotateTransform(graphics, angle1);
                graphics.DrawString("BBB", new Font("Arial", 100), new SolidBrush(Color.Blue), rect);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
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
