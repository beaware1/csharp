using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MsTests.Drawing
{
    internal class MetafileLinesTests
    {

        private String pathMetafiles = Utils.METAFILES_PATH + Utils.LINES_SPATH + Utils.CS_MF_SPATH;
        private String pathPng = Utils.METAFILES_PATH + Utils.LINES_SPATH + Utils.CS_PNG_SPATH;

        private Color color = Color.Blue;
        private float f1 = 10f;
        private float f2 = 20f;
        private float f3 = 40f;
        private float f4 = 100f;

        private String metafileName;
        private String pngName;
        private Graphics gr;
        private IntPtr hdc;


        private void prepareEmf(String imageName)
        {
            metafileName = imageName + Utils.CS_EMF_EXT;
            pngName = imageName + Utils.CS_EMF_PNG_EXT;
            gr = Graphics.FromHwnd(IntPtr.Zero);
            hdc = gr.GetHdc();
        }

        private void prepareWmf(String imageName)
        {
            metafileName = imageName + Utils.CS_WMF_EXT;
            pngName = imageName + Utils.CS_WMF_PNG_EXT;
            gr = Graphics.FromHwnd(IntPtr.Zero);
            hdc = gr.GetHdc();
        }

        private void save() //TODO
        {
            Image image = new Metafile(pathMetafiles + metafileName);
            image.Save(pathMetafiles + pngName, ImageFormat.Png);
        }


        [Test]
        public void TestDrawLine10Emf()
        {
            prepareEmf("MetafileLine10");
            using (Metafile metafile = new Metafile(pathMetafiles, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                g.DrawLine(new Pen(color, 10f), f1, f2, f3, f4);
                gr.ReleaseHdc(hdc);
            }
            save();
        }

        [Test]
        public void TestDrawLine30Emf()
        {
            prepareEmf("MetafileLine30");
            using (Metafile metafile = new Metafile(pathMetafiles, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                g.DrawLine(new Pen(color, 30f), f1, f2, f3, f4);
                gr.ReleaseHdc(hdc);
            }
            save();
        }

        [Test]
        public void TestDrawLine50Emf()
        {
            prepareEmf("MetafileLine50");
            using (Metafile metafile = new Metafile(pathMetafiles, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                g.DrawLine(new Pen(color, 50f), f1, f2, f3, f4);
                gr.ReleaseHdc(hdc);
            }
            save();
        }

       [Test]
        public void TestDrawLine10Wmf()
        {
            prepareWmf("MetafileLine10");
            using (Metafile metafile = new Metafile(pathMetafiles, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                g.DrawLine(new Pen(color, 10f), f1, f2, f3, f4);
                gr.ReleaseHdc(hdc);
            }
            save();
        }

        [Test]
        public void TestDrawLine30Wmf()
        {
            prepareWmf("MetafileLine30");
            using (Metafile metafile = new Metafile(pathMetafiles, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                g.DrawLine(new Pen(color, 30f), f1, f2, f3, f4);
                gr.ReleaseHdc(hdc);
            }
            save();
        }

        [Test]
        public void TestDrawLine50Wmf()
        {
            prepareWmf("MetafileLine50");
            using (Metafile metafile = new Metafile(pathMetafiles, hdc))
            {
                Graphics g = Graphics.FromImage(metafile);
                g.Clear(Color.White);
                g.DrawLine(new Pen(color, 50f), f1, f2, f3, f4);
                gr.ReleaseHdc(hdc);
            }
            save();
        }

    
  }
}

 

