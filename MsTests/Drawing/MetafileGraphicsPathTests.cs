using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class MetafileGraphicsPathTests
    {
        private String pathMetafiles = LocalSettings.METAFILES_PATH + Utils.GRAPHICSPATH_SPATH + Utils.CS_MF_SPATH;
        private String pathPng = LocalSettings.METAFILES_PATH + Utils.GRAPHICSPATH_SPATH + Utils.CS_PNG_SPATH;

        [Test]
        public void TestDrawGraphicsPathEMF()
        {
            String imageName = "GraphicsPath";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                PointF[] points1 = new PointF[] { new PointF(100, 100), new PointF(200, 10), new PointF(350, 50), new PointF(500, 100) };
                PointF[] points2 = new PointF[] { new PointF(100, 100), new PointF(100, 10), new PointF(250, 50), new PointF(500, 100) };
                GraphicsPath path1 = new GraphicsPath();
                GraphicsPath path2 = new GraphicsPath();
                path1.AddLines(points1);
                path2.AddLines(points2);
                Pen pen1 = new Pen(Color.Red);
                Pen pen2 = new Pen(Color.Blue);
                pen1.DashStyle = DashStyle.DashDotDot;
                pen1.DashStyle = DashStyle.DashDot;
                g.DrawPath(pen1, path1);
                g.DrawPath(pen2, path2);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawGraphicsPathWMF()
        {
            String imageName = "GraphicsPath";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                PointF[] points1 = new PointF[] { new PointF(100, 100), new PointF(200, 10), new PointF(350, 50), new PointF(500, 100) };
                PointF[] points2 = new PointF[] { new PointF(100, 100), new PointF(100, 10), new PointF(250, 50), new PointF(500, 100) };
                GraphicsPath path1 = new GraphicsPath();
                GraphicsPath path2 = new GraphicsPath();
                path1.AddLines(points1);
                path2.AddLines(points2);
                Pen pen1 = new Pen(Color.Red);
                Pen pen2 = new Pen(Color.Blue);
                pen1.DashStyle = DashStyle.DashDotDot;
                pen1.DashStyle = DashStyle.DashDot;
                g.DrawPath(pen1, path1);
                g.DrawPath(pen2, path2);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawGraphicsPathCrossModeEMF()
        {
            String imageName = "GraphicsPathCrossMode";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                PointF[] points1 = new PointF[] { new PointF(100, 100), new PointF(200, 10), new PointF(350, 50), new PointF(500, 400) };
                PointF[] points2 = new PointF[] { new PointF(100, 100), new PointF(100, 10), new PointF(250, 50), new PointF(500, 100) };
                GraphicsPath path1 = new GraphicsPath();
                GraphicsPath path2 = new GraphicsPath();
                path1.AddLines(points1);
                path2.AddLines(points2);
                Pen pen1 = new Pen(Color.Red);
                Pen pen2 = new Pen(Color.Blue);
                pen1.DashStyle = DashStyle.Dash;
                pen2.DashStyle = DashStyle.Dot;
                g.DrawPath(pen1, path1);
                g.DrawPath(pen2, path2);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawGraphicsPathCrossModeWMF()
        {
            String imageName = "GraphicsPathCrossPenWidthMode";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                PointF[] points1 = new PointF[] { new PointF(100, 100), new PointF(200, 10), new PointF(350, 50), new PointF(500, 400) };
                PointF[] points2 = new PointF[] { new PointF(100, 100), new PointF(100, 10), new PointF(250, 50), new PointF(500, 100) };
                GraphicsPath path1 = new GraphicsPath();
                GraphicsPath path2 = new GraphicsPath();
                path1.AddLines(points1);
                path2.AddLines(points2);
                Pen pen1 = new Pen(Color.Red);
                Pen pen2 = new Pen(Color.Blue);
                pen1.DashStyle = DashStyle.Dash;
                pen2.DashStyle = DashStyle.Dot;
                g.DrawPath(pen1, path1);
                g.DrawPath(pen2, path2);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawGraphicsPathCrossPenWidthModeEMF()
        {
            String imageName = "GraphicsPathCrossPenWidthMode";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                PointF[] points1 = new PointF[] { new PointF(100, 100), new PointF(200, 10), new PointF(350, 50), new PointF(500, 400) };
                PointF[] points2 = new PointF[] { new PointF(100, 100), new PointF(100, 10), new PointF(250, 50), new PointF(500, 100) };
                GraphicsPath path1 = new GraphicsPath();
                GraphicsPath path2 = new GraphicsPath();
                path1.AddLines(points1);
                path2.AddLines(points2);
                Pen pen1 = new Pen(Color.Red);
                Pen pen2 = new Pen(Color.Blue);
                pen1.DashStyle = DashStyle.Dash;
                pen2.DashStyle = DashStyle.Dot;
                pen1.Width = 3;
                pen2.Width = 5;
                g.DrawPath(pen1, path1);
                g.DrawPath(pen2, path2);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawGraphicsPathCrossPenWidthModeWMF()
        {
            String imageName = "GraphicsPathCrossMode";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                PointF[] points1 = new PointF[] { new PointF(100, 100), new PointF(200, 10), new PointF(350, 50), new PointF(500, 400) };
                PointF[] points2 = new PointF[] { new PointF(100, 100), new PointF(100, 10), new PointF(250, 50), new PointF(500, 100) };
                GraphicsPath path1 = new GraphicsPath();
                GraphicsPath path2 = new GraphicsPath();
                path1.AddLines(points1);
                path2.AddLines(points2);
                Pen pen1 = new Pen(Color.Red);
                Pen pen2 = new Pen(Color.Blue);
                pen1.DashStyle = DashStyle.Dash;
                pen2.DashStyle = DashStyle.Dot;
                pen1.Width = 3;
                pen2.Width = 5;
                g.DrawPath(pen1, path1);
                g.DrawPath(pen2, path2);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawGraphicsPathHouseEMF()
        {
            String imageName = "GraphicsPathHouse";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                GraphicsPath graphicsPath1 = new GraphicsPath();
                PointF[] points1 = new PointF[] { new PointF(0, 99), new PointF(50, 0), new PointF(99, 99) };
                Pen pen1 = new Pen(Color.Blue);
                graphicsPath1.AddPolygon(points1);
                GraphicsPath graphicsPath2 = new GraphicsPath();
                PointF[] points2 = new PointF[] { new PointF(0, 198), new PointF(0, 99), new PointF(99, 99), new PointF(99, 198) };
                Pen pen2 = new Pen(Color.Red);
                graphicsPath2.AddPolygon(points2);
                g.DrawPath(pen1, graphicsPath1);
                g.DrawPath(pen2, graphicsPath2);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawGraphicsPathCrossHouseModeEMF()
        {
            String imageName = "GraphicsPathHouseCross";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                GraphicsPath graphicsPath1 = new GraphicsPath();
                PointF[] points1 = new PointF[] { new PointF(0, 99), new PointF(50, 0), new PointF(99, 99) };
                Pen pen1 = new Pen(Color.Blue);
                graphicsPath1.AddPolygon(points1);
                GraphicsPath graphicsPath2 = new GraphicsPath();
                PointF[] points2 = new PointF[] { new PointF(0, 0), new PointF(99, 0), new PointF(99, 99), new PointF(0, 99) };
                Pen pen2 = new Pen(Color.Red);
                graphicsPath2.AddPolygon(points2);
                g.DrawPath(pen1, graphicsPath1);
                g.DrawPath(pen2, graphicsPath2);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawGraphicsPathTransformModeEMF()
        {
            String imageName = "GraphicsPathTransform";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                GraphicsPath graphicsPath1 = new GraphicsPath();
                PointF[] points1 = new PointF[] { new PointF(0, 99), new PointF(50, 0), new PointF(99, 99) };
                Pen pen1 = new Pen(Color.Blue);
                graphicsPath1.AddPolygon(points1);
                Matrix matrix1 = new Matrix();
                matrix1.RotateAt(30, new PointF(5, 5));
                graphicsPath1.Transform(matrix1);
                GraphicsPath graphicsPath2 = new GraphicsPath();
                PointF[] points2 = new PointF[] { new PointF(0, 0), new PointF(99, 0), new PointF(99, 99), new PointF(0, 99) };
                Pen pen2 = new Pen(Color.Red);
                graphicsPath2.AddPolygon(points2);
                Matrix matrix2 = new Matrix();
                matrix2.RotateAt(270, new PointF(5, 5));
                graphicsPath2.Transform(matrix2);
                g.DrawPath(pen1, graphicsPath1);
                g.DrawPath(pen2, graphicsPath2);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestFillGraphicsPathEMF()
        {
            String imageName = "FillGraphicsPath";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                GraphicsPath graphicsPath1 = new GraphicsPath();
                Rectangle rect1 = new Rectangle(0, 0, 100, 50);
                Brush brush1 = new SolidBrush(Color.Blue);
                graphicsPath1.AddEllipse(rect1);
                GraphicsPath graphicsPath2 = new GraphicsPath();
                Rectangle rect2 = new Rectangle(0, 25, 100, 100);
                Brush brush2 = new SolidBrush(Color.Red);
                graphicsPath2.AddRectangle(rect2);
                GraphicsPath graphicsPath3 = new GraphicsPath();
                Rectangle rect3 = new Rectangle(0, 100, 100, 50);
                Brush brush3 = new SolidBrush(Color.Red);
                graphicsPath3.AddEllipse(rect3);
                g.FillPath(brush2, graphicsPath2);
                g.FillPath(brush1, graphicsPath1);
                g.FillPath(brush3, graphicsPath3);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }
    }
}
