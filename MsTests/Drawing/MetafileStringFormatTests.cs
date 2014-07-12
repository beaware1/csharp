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
    class MetafileStringFormatTests
    {
        private String pathMetafiles = Utils.METAFILES_PATH + Utils.STRINGS_SPATH + Utils.CS_MF_SPATH;
        private String pathPng = Utils.METAFILES_PATH + Utils.STRINGS_SPATH + Utils.CS_PNG_SPATH;


        [Test]
        public void TestVerticalTextEmf()
        {
            String imageName = "VerticalText";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                string text = "Vertical text";
                FontFamily fontFamily = new FontFamily("Lucida Console");

                Font font = new Font(fontFamily,32,FontStyle.Regular,GraphicsUnit.Point);
                PointF point = new PointF(40,10);
                 StringFormat stringFormat = new StringFormat();
                  SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
                 stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                g.DrawString(text, font, solidBrush, point, stringFormat);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

    
        [Test]
        public void TestVerticalTextWmf()
        {
            String imageName = "VerticalText";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                string text = "Vertical text";
                FontFamily fontFamily = new FontFamily("Lucida Console");

                Font font = new Font(fontFamily,32,FontStyle.Regular,GraphicsUnit.Point);
                PointF point = new PointF(40,10);
                 StringFormat stringFormat = new StringFormat();
                  SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
                 stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                g.DrawString(text, font, solidBrush, point, stringFormat);
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

       [Test]
        public void TestCenteredTextEmf()
        {
            String imageName = "CenteredText";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                string text = "Use StringFormat and Rectangle objects to center text in a rectangle.";
                Font font = new Font("Arial", 22, FontStyle.Bold, GraphicsUnit.Point);
                Rectangle rect = new Rectangle(10, 10, 430, 430);

                 StringFormat stringFormat = new StringFormat();
                 stringFormat.Alignment = StringAlignment.Center;
                 stringFormat.LineAlignment = StringAlignment.Center;
                 stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                 g.DrawString(text, font, Brushes.Blue, rect, stringFormat);
                 g.DrawRectangle(Pens.Blue, rect);
                 gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }
       
 [Test]
        public void TestCenteredTextWmf()
        {
            String imageName = "CenteredText";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                string text = "Use StringFormat and Rectangle objects to center text in a rectangle.";
                Font font = new Font("Arial", 22, FontStyle.Bold, GraphicsUnit.Point);
                Rectangle rect = new Rectangle(10, 10, 430, 430);

                 StringFormat stringFormat = new StringFormat();
                 stringFormat.Alignment = StringAlignment.Center;
                 stringFormat.LineAlignment = StringAlignment.Center;
                 stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                 g.DrawString(text, font, Brushes.Blue, rect, stringFormat);
                 g.DrawRectangle(Pens.Blue, rect);
                 gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }
       
        [Test]
        public void TestTabStopsEmf()
        {
            String imageName = "TabStops";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                string text = "";
                text = text + "Joe\t95\t88\t91\n";
                text = text + "Mary\t98\t84\t90\n";
                text = text + "Sam\t42\t76\t98\n";
                text = text + "Jane\t65\t73\t92\n";
                FontFamily fontFamily = new FontFamily("Courier New");
                Font font = new Font(fontFamily,22,FontStyle.Bold,GraphicsUnit.Point);
                Rectangle rect = new Rectangle(10, 10, 700, 700);

                 StringFormat stringFormat = new StringFormat();
                 stringFormat.Alignment = StringAlignment.Near;
                 stringFormat.LineAlignment = StringAlignment.Near;
                 SolidBrush solidBrush = new SolidBrush(Color.Blue);
                 float[] tabs = { 150, 100, 100, 100 };
                 stringFormat.SetTabStops(0, tabs);

                 g.DrawString(text, font, solidBrush, rect, stringFormat);
                 g.DrawRectangle(Pens.Blue, rect);
                 gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }
   
[Test]
        public void TestTabStopsWmf()
        {
            String imageName = "TabStops";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                string text = "";
                text = text + "Joe\t95\t88\t91\n";
                text = text + "Mary\t98\t84\t90\n";
                text = text + "Sam\t42\t76\t98\n";
                text = text + "Jane\t65\t73\t92\n";
                FontFamily fontFamily = new FontFamily("Courier New");
                Font font = new Font(fontFamily,22,FontStyle.Bold,GraphicsUnit.Point);
                Rectangle rect = new Rectangle(10, 10, 700, 700);

                 StringFormat stringFormat = new StringFormat();
                 stringFormat.Alignment = StringAlignment.Near;
                 stringFormat.LineAlignment = StringAlignment.Near;
                 SolidBrush solidBrush = new SolidBrush(Color.Blue);
                 float[] tabs = { 150, 100, 100, 100 };
                 stringFormat.SetTabStops(0, tabs);

                 g.DrawString(text, font, solidBrush, rect, stringFormat);
                 g.DrawRectangle(Pens.Blue, rect);
                 gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }
   
        
        [Test]
        public void TestWrappedTextEmf()
        {
            String imageName = "WrappedText";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                string text = "Draw Wrapped text in a rectangle";
               
                Font font = new Font("Arial", 22, FontStyle.Bold, GraphicsUnit.Point);
                Rectangle rect = new Rectangle(10, 10,200, 200);
                
                 StringFormat stringFormat = new StringFormat();
                 stringFormat.Alignment = StringAlignment.Near;
                 stringFormat.LineAlignment = StringAlignment.Near;
                 SolidBrush solidBrush = new SolidBrush(Color.Blue);

                 g.DrawString(text, font, solidBrush, rect, stringFormat);
                 g.DrawRectangle(Pens.Blue, Rectangle.Round(rect));
                 gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

         
        [Test]
        public void TestWrappedTextWmf()
        {
            String imageName = "WrappedText";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                string text = "Draw Wrapped text in a rectangle";
               
                Font font = new Font("Arial", 22, FontStyle.Bold, GraphicsUnit.Point);
                Rectangle rect = new Rectangle(10, 10,200, 200);
                
                 StringFormat stringFormat = new StringFormat();
                 stringFormat.Alignment = StringAlignment.Near;
                 stringFormat.LineAlignment = StringAlignment.Near;
                 SolidBrush solidBrush = new SolidBrush(Color.Blue);

                 g.DrawString(text, font, solidBrush, rect, stringFormat);
                 g.DrawRectangle(Pens.Blue, Rectangle.Round(rect));
                 gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

      [Test]
        public void TestTextInSpecificPositionEmf()
        {
            String imageName = "TextInSpecificPosition";
            String metafileName = imageName + Utils.CS_EMF_EXT;
            String pngName = imageName + Utils.CS_EMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                string text = "Draw text in a specific position";

                Font font = new Font("Times New Roman", 20, FontStyle.Bold, GraphicsUnit.Pixel);

                 StringFormat stringFormat = new StringFormat();
                 stringFormat.Alignment = StringAlignment.Near;
                 stringFormat.LineAlignment = StringAlignment.Near;
                 SolidBrush solidBrush = new SolidBrush(Color.Blue);
                for (int i = 1; i < 20; i+=3)
                {
                    PointF point = new PointF(40*i, 10*i);

                    g.DrawString(text, font, solidBrush, point);
                }
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

 [Test]
        public void TestTextInSpecificPositionWmf()
        {
            String imageName = "TextInSpecificPosition";
            String metafileName = imageName + Utils.CS_WMF_EXT;
            String pngName = imageName + Utils.CS_WMF_PNG_EXT;
            String imagePath = Path.Combine(pathMetafiles, metafileName);
            Graphics gr = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = gr.GetHdc();
            using (Metafile metafile = new Metafile(imagePath, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                string text = "Draw text in a specific position";

                Font font = new Font("Times New Roman", 20, FontStyle.Bold, GraphicsUnit.Pixel);

                 StringFormat stringFormat = new StringFormat();
                 stringFormat.Alignment = StringAlignment.Near;
                 stringFormat.LineAlignment = StringAlignment.Near;
                 SolidBrush solidBrush = new SolidBrush(Color.Blue);
                for (int i = 1; i < 20; i+=3)
                {
                    PointF point = new PointF(40*i, 10*i);

                    g.DrawString(text, font, solidBrush, point);
                }
                gr.ReleaseHdc(hdc);
            }
            Image image = new Metafile(imagePath);
            image.Save(Path.Combine(pathPng, pngName), ImageFormat.Png);
        }

    }
}
