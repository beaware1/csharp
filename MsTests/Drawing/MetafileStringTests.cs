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
    class MetafileStringTests
    {
        private String pathMetafiles = LocalSettings.METAFILES_PATH + Utils.STRINGS_SPATH + Utils.CS_MF_SPATH;
        private String pathPng = LocalSettings.METAFILES_PATH + Utils.STRINGS_SPATH + Utils.CS_PNG_SPATH;

        [Test]
        public void TestDrawStringEMF()  //TODO CSPORT-ODS-34673
        {
            String imageName = "String";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                PointF point = new PointF(5, 5);
                g.DrawString("Hello", new Font("Arial", 20), new SolidBrush(Color.Aqua), point);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawStringWMF() //TODO полоски  
        {
            String imageName = "String";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                PointF point = new PointF(5, 5);
                g.DrawString("Hello", new Font("Arial", 20), new SolidBrush(Color.Aqua), point);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawStringEMFClearMode() //TODO сложная кисть
        {
            String imageName = "StringClearMode";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                PointF point = new PointF(5, 5);
                g.DrawString("Hello", new Font("Arial", 20), new SolidBrush(Color.Aqua), point);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawStringWMFClearMode() //TODO clear -  CSPORT-ODS-34674 
        {
            String imageName = "StringClearMode";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                PointF point = new PointF(5, 5);
                g.DrawString("Hello", new Font("Arial", 20), new SolidBrush(Color.Aqua), point);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawStringEMFWidthPenMode() //TODO сложная кисть проверить с Solid
        {
            String imageName = "StringWidthPenMode";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                HatchBrush hBrush = new HatchBrush(HatchStyle.Horizontal, Color.Red, Color.FromArgb(255, 128, 255, 255));
                PointF point = new PointF(5, 5);
                g.DrawString("Hello", new Font("Arial", 20), hBrush, point);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawStringWMFWidthPenMode() //TODO сложная кисть
        {
            String imageName = "StringWidthPenMode";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile); 
                HatchBrush hBrush = new HatchBrush(HatchStyle.Horizontal,Color.Red,Color.FromArgb(255, 128, 255, 255));
                PointF point = new PointF(5, 5);
                g.DrawString("Hello", new Font("Arial", 20), hBrush, point);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawStringEMFWidthPenRotateMode() //TODO сложная кисть с 2 цветами
        {
            String imageName = "StringWidthPenRotateMode";
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
                PointF point = new PointF(5, 5);
                g.DrawString("Hello", new Font("Arial", 20), hBrush, point);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawStringWMFWidthPenRotateMode() //TODO сложная кисть
        {
            String imageName = "StringWidthPenRotateMode";
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
                PointF point = new PointF(5, 5);
                g.DrawString("Hello", new Font("Arial", 20), hBrush, point);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawStringWrappedText()
        {
            String imageName = "StringWrappedText";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile); 
                string text1 = "Draw text in a rectangle by passing a RectF to the DrawString method.";
                using (Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
                {
                    RectangleF rectF1 = new RectangleF(30, 10, 100, 122);
                    g.DrawString(text1, font1, Brushes.Blue, rectF1);
                    g.DrawRectangle(Pens.Black, Rectangle.Round(rectF1));
                }
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

        [Test]
        public void TestDrawStringFontStyles()
        {
            FontStyle[] fontStyles = (FontStyle[]) Enum.GetValues(typeof (FontStyle));
            GraphicsUnit[] graphicsUnits = new GraphicsUnit[] { GraphicsUnit.Document,  GraphicsUnit.Millimeter, GraphicsUnit.Pixel, GraphicsUnit.Point};
            foreach (FontStyle fontStyle in fontStyles)
            {
                foreach (GraphicsUnit graphicsUnit in graphicsUnits)
                {
                    String imageName = "StringFontStyle" + fontStyle + "GraphicsUnit" + graphicsUnit;
                    String metafileName = imageName + Utils.CS_EMF_EXT;
                    String pngName = imageName + Utils.CS_EMF_PNG_EXT;
                    String imagePath = Path.Combine(pathMetafiles, metafileName);
                    Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
                    IntPtr hdc = gr.GetHdc();
                    using (Metafile metafile = new Metafile(imagePath, hdc))
                    {
                        Graphics g = Graphics.FromImage(metafile);
                        string text1 = "Draw text in a rectangle by passing a RectF to the DrawString method.";
                        using (Font font1 = new Font("Arial", 12, fontStyle, graphicsUnit))
                        {
                            RectangleF rectF1 = new RectangleF(30, 10, 100, 122);
                            g.DrawString(text1, font1, Brushes.Blue, rectF1);
                            g.DrawRectangle(Pens.Black, Rectangle.Round(rectF1));
                        }
                        gr.ReleaseHdc(hdc);
                    }
                    Image image = new Metafile(imagePath);
                    image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
                }
            }
        }
    }
}
