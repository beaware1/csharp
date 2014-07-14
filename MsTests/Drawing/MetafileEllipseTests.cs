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
    class MetafileEllipseTests
    {
        private String pathMetafiles = LocalSettings.METAFILES_PATH + Utils.SHAPES_SPATH + Utils.CS_MF_SPATH;
        private String pathPng = LocalSettings.METAFILES_PATH + Utils.SHAPES_SPATH + Utils.CS_PNG_SPATH;

        [Test]
        public void TestDrawEllipseEMF()
        {
            String imageName = "Ellipse";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.DrawEllipse(new Pen(Color.Red), 5, 5, 10, 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(pathPng + pngName, ImageFormat.Png);
        }

        [Test]
        public void TestDrawEllipseWMF()
        {
            String imageName = "Ellipse";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.DrawEllipse(new Pen(Color.Red), 5, 5, 10, 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawEllipseEMFClearMode()
        {
            String imageName = "EllipseClearMode";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                g.DrawEllipse(new Pen(Color.Red), 5, 5, 10, 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawEllipseWMFClearMode()
        {
            String imageName = "EllipseClearMode";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                g.DrawEllipse(new Pen(Color.Red), 5, 5, 10, 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawEllipseEMFWidthPenMode()
        {
            String imageName = "EllipseWidthPenMode";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                int penWidth = 3;
                g.DrawEllipse(new Pen(Color.Red, penWidth), 5, 5, 10, 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawEllipseWMFWidthPenMode()
        {
            String imageName = "EllipseWidthPenMode";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                int penWidth = 3;
                g.DrawEllipse(new Pen(Color.Red, penWidth), 5, 5, 10, 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawEllipseEMFWidthPenRotateMode()
        {
            String imageName = "EllipseWidthPenRotateMode";
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
                g.DrawEllipse(new Pen(Color.Red, penWidth), 5, 5, 10, 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawEllipseWMFWidthPenRotateMode()
        {
            String imageName = "EllipseWidthPenRotateMode";
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
                g.DrawEllipse(new Pen(Color.Red, penWidth), 5, 5, 10, 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestFillEllipseEMFRotateMode() //TODO в дотнете красный не отрисовался
        {
            String imageName = "FilledEllipseRotateMode";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                Matrix matrix = new Matrix();
                matrix.RotateAt(30, new PointF(5, 5));
                g.Transform = matrix;
                HatchBrush hBrush = new HatchBrush(HatchStyle.Horizontal, Color.Red, Color.FromArgb(255, 128, 255, 255));
                g.FillEllipse(hBrush, 5, 5, 10, 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestFillEllipseWMFRotateMode() //TODO в дотнете красный не отрисовался
        {
            String imageName = "FilledEllipseRotateMode";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                Matrix matrix = new Matrix();
                matrix.RotateAt(30, new PointF(5, 5));
                g.Transform = matrix;
                HatchBrush hBrush = new HatchBrush(HatchStyle.Horizontal, Color.Red, Color.FromArgb(255, 128, 255, 255));
                g.FillEllipse(hBrush, 5, 5, 10, 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }
    }
}
