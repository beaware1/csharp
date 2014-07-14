
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class MetafileDrawImageTests
    {
        private String pathMetafiles = LocalSettings.METAFILES_PATH + Utils.IMAGES_SPATH + Utils.CS_MF_SPATH;
        private String pathPng = LocalSettings.METAFILES_PATH + Utils.IMAGES_SPATH + Utils.CS_PNG_SPATH;
        private int width = 1600;
        private int height = 1600;

         [Test]
        public void TestDrawStringEMF()
        {

            Bitmap bitmap = new Bitmap(width, height);
            Graphics bitmapGraphics = Graphics.FromImage(bitmap);
            bitmapGraphics.Clear(Color.White);
            PointF point = new PointF(500, 500);
            bitmapGraphics.DrawString("Hello", new Font("Arial", 40), new SolidBrush(Color.Blue), point);
            String imageName = "DrawImageString";
            DrawEMF(imageName, bitmap);
        }

        public void DrawEMF(String imageName, Bitmap bitmap)
        {
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();

            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                graphics.DrawImage(bitmap, 0, 0);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        public void DrawWMF(String imageName, Bitmap bitmap)
        {
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();

            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics graphics = Graphics.FromImage(metafile);
                graphics.DrawImage(bitmap, 0, 0);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }
    }
}
