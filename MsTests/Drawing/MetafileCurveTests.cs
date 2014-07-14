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
    class MetafileCurveTests
    {
        private String pathMetafiles = LocalSettings.METAFILES_PATH + Utils.LINES_SPATH + Utils.CS_MF_SPATH;
        private String pathPng = LocalSettings.METAFILES_PATH + Utils.LINES_SPATH + Utils.CS_PNG_SPATH;


        [Test]
        public void TestDrawCurveEMF()
        {
            String imageName = "Curve";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
                g.DrawCurve(new Pen(Color.Red), points);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawCurveWMF()
        {
            String imageName = "Curve";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
                g.DrawCurve(new Pen(Color.Red), points);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawCurveEMFClearMode()
        {
            String imageName = "CurveClearMode";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
                g.DrawCurve(new Pen(Color.Red), points);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawCurveWMFClearMode()
        {
            String imageName = "CurveClearMode";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
                g.DrawCurve(new Pen(Color.Red), points);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawCurveEMFWidthPenMode()
        {
            String imageName = "CurveWidthPenMode";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                int penWidth = 3;
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
                g.DrawCurve(new Pen(Color.Red), points);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawCurveWMFWidthPenMode()
        {
            String imageName = "CurveWidthPenMode";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                int penWidth = 3;
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
                g.DrawCurve(new Pen(Color.Red), points);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawCurveEMFWidthPenRotateMode()
        {
            String imageName = "CurveWidthPenRotateMode";
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
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
                g.DrawCurve(new Pen(Color.Red), points);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawCurveWMFWidthPenRotateMode()
        {
            String imageName = "CurveWidthPenRotateMode";
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
                Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(350, 50), new Point(500, 100) };
                g.DrawCurve(new Pen(Color.Red), points);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }
    }
}
