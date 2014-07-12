using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class MetafileBezierTests
    {
        private String pathMetafiles = Utils.METAFILES_PATH + Utils.SHAPES_SPATH + Utils.CS_MF_SPATH;
        private String pathPng = Utils.METAFILES_PATH + Utils.SHAPES_SPATH + Utils.CS_PNG_SPATH;

        [Test]
        public void TestDrawBezierEMF()
        {
            String imageName = "Bezier";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                g.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawBezierWMF()
        {
            String imageName = "Bezier";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                g.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawBezierEMFClearMode()
        {
            String imageName = "BezierClearMode";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                g.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawBezierWMFClearMode()
        {
            String imageName = "BezierClearMode";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                g.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawBezierEMFWidthPenMode()
        {
            String imageName = "BezierWidthPenMode";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                int penWidth = 3;
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                g.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawBezierWMFWidthPenMode()
        {
            String imageName = "BezierWidthPenMode";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                int penWidth = 3;
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                g.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawBezierEMFWidthPenRotateMode()
        {
            String imageName = "BezierWidthPenRotateMode";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                int penWidth = 3;
                Matrix matrix = new Matrix();
                matrix.RotateAt(30, new PointF(5, 5));
                g.Transform = matrix;
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                g.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawBezierWMFWidthPenRotateMode()
        {
            String imageName = "BezierWidthPenRotateMode";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                int penWidth = 3;
                Matrix matrix = new Matrix();
                matrix.RotateAt(30, new PointF(5, 5));
                g.Transform = matrix;
                Point start = new Point(100, 100);
                Point control1 = new Point(200, 10);
                Point control2 = new Point(350, 50);
                Point end = new Point(500, 100);
                g.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }
    }
}
