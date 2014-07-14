using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using NUnit.Framework;
  
namespace MsTests.Drawing
{
    class MetafileImageTests
    {

        private String pathMetafiles = LocalSettings.METAFILES_PATH + Utils.IMAGES_SPATH + Utils.CS_MF_SPATH;
        private String pathPng = LocalSettings.METAFILES_PATH + Utils.IMAGES_SPATH + Utils.CS_PNG_SPATH;

        [Test]
        public void TestDrawImageEMF()
        {
            String imageName = "Image";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                Bitmap bitmap = new Bitmap(100,100);
                Graphics bitmapGraphics = Graphics.FromImage(bitmap);
                PointF[] points = new PointF[] { new PointF(0, 99), new PointF(50, 0), new PointF(99, 99)};
                Pen pen = new Pen(Color.Blue);
                bitmapGraphics.DrawPolygon(pen, points);
                g.DrawImage(bitmap, 5,5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawImageHouseEMF()
        {
            String imageName = "ImageHouse";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                Bitmap bitmap1 = new Bitmap(100,100);
                Graphics bitmapGraphics1 = Graphics.FromImage(bitmap1);
                PointF[] points1 = new PointF[] { new PointF(0, 99), new PointF(50, 0), new PointF(99, 99)};
                Pen pen1 = new Pen(Color.Blue);
                bitmapGraphics1.DrawPolygon(pen1, points1);
                Bitmap bitmap2 = new Bitmap(100,100);
                Graphics bitmapGraphics2 = Graphics.FromImage(bitmap2);
                PointF[] points2 = new PointF[] { new PointF(0, 0), new PointF(99, 0), new PointF(99, 99), new PointF(0, 99)};
                Pen pen2 = new Pen(Color.Red);
                bitmapGraphics2.DrawPolygon(pen2, points2);
                g.DrawImage(bitmap1, 5,5);
                g.DrawImage(bitmap2, 5,bitmap1.Width + 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawImageCrossModeEMF()
        {
            String imageName = "ImageHouseCross";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                Bitmap bitmap1 = new Bitmap(100,100);
                Graphics bitmapGraphics1 = Graphics.FromImage(bitmap1);
                PointF[] points1 = new PointF[] { new PointF(0, 99), new PointF(50, 0), new PointF(99, 99)};
                Pen pen1 = new Pen(Color.Blue);
                bitmapGraphics1.DrawPolygon(pen1, points1);
                Bitmap bitmap2 = new Bitmap(100,100);
                Graphics bitmapGraphics2 = Graphics.FromImage(bitmap2);
                PointF[] points2 = new PointF[] { new PointF(0, 0), new PointF(99, 0), new PointF(99, 99), new PointF(0, 99)};
                Pen pen2 = new Pen(Color.Red);
                bitmapGraphics2.DrawPolygon(pen2, points2);
                g.DrawImage(bitmap1, 5,5);
                g.DrawImage(bitmap2, 5,bitmap1.Width/ 2 + 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawImageTransformModeEMF()
        {
            String imageName = "ImageTransform";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                Bitmap bitmap1 = new Bitmap(100,100);
                Graphics bitmapGraphics1 = Graphics.FromImage(bitmap1);
                PointF[] points1 = new PointF[] { new PointF(0, 99), new PointF(50, 0), new PointF(99, 99)};
                Pen pen1 = new Pen(Color.Blue);
                Matrix matrix1 = new Matrix();
                matrix1.RotateAt(30, new PointF(5,5));
                bitmapGraphics1.Transform = matrix1;
                bitmapGraphics1.DrawPolygon(pen1, points1);
                Bitmap bitmap2 = new Bitmap(100, 100);
                Graphics bitmapGraphics2 = Graphics.FromImage(bitmap2);
                Matrix matrix2 = new Matrix();
                matrix2.RotateAt(270, new PointF(5,5));
                bitmapGraphics2.Transform = matrix2;
                PointF[] points2 = new PointF[] { new PointF(0, 0), new PointF(99, 0), new PointF(99, 99), new PointF(0, 99)};
                Pen pen2 = new Pen(Color.Red);
                bitmapGraphics2.DrawPolygon(pen2, points2);
                g.DrawImage(bitmap1, 5,5);
                g.DrawImage(bitmap2, 5,bitmap1.Width/ 2 + 5);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestFillImageEMF()
        {
            String imageName = "FillImage";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                Bitmap bitmap1 = new Bitmap(100, 100);
                Graphics bitmapGraphics1 = Graphics.FromImage(bitmap1);
                Rectangle rect1 = new Rectangle(0,0,100,50);
                Brush brush1 = new SolidBrush(Color.Blue);
                bitmapGraphics1.FillEllipse(brush1, rect1);
                Bitmap bitmap2 = new Bitmap(100, 100);
                Graphics bitmapGraphics2 = Graphics.FromImage(bitmap2);
                Rectangle rect2 = new Rectangle(0, 0, 100, 100);
                Brush brush2 = new SolidBrush(Color.Red);
                bitmapGraphics2.FillRectangle(brush2, rect2);
                Bitmap bitmap3 = new Bitmap(100, 100);
                Graphics bitmapGraphics3 = Graphics.FromImage(bitmap3);
                Rectangle rect3 = new Rectangle(0, 0, 100, 50);
                Brush brush3 = new SolidBrush(Color.Red);
                bitmapGraphics3.FillEllipse(brush3, rect3);
                g.DrawImage(bitmap2, 5, rect1.Height);
                g.DrawImage(bitmap1, 5, 20);
                g.DrawImage(bitmap3, 5, 120);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }
    }
}
