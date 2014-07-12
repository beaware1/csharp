using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class WidenTests
    {
        private static String FOLDER_IMAGES = "C:/Projects/Java.SE/modules/Net.Framework/System.Drawing/lib/src/test/resources/com/aspose/ms/System/Drawing/bitmaps/";

        [Test]
        public void TestWiden3()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, 100, 100);
            path.AddEllipse(100, 0, 100, 100);

            graphics.DrawPath(Pens.Blue, path);

            // Widen the path.
            Pen widenPen = new Pen(Color.Blue, 10);
            Matrix widenMatrix = new Matrix();
            float flatness = 10.0f;
            widenMatrix.Translate(50, 50);
            path.Widen(widenPen, widenMatrix, flatness);

            graphics.FillPath(new SolidBrush(Color.Blue), path);

            sourceBitmap.Save(FOLDER_IMAGES + "Widen3.bmp");
        }

        [Test]
        public void TestWiden2()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, 100, 100);
            path.AddEllipse(100, 0, 100, 100);

            graphics.DrawPath(Pens.Blue, path);

            // Widen the path.

            Pen widenPen = new Pen(Color.Blue, 10);
            Matrix widenMatrix = new Matrix();
            widenMatrix.Translate(50, 50);
            path.Widen(widenPen, widenMatrix);

            graphics.FillPath(new SolidBrush(Color.Blue), path);

            sourceBitmap.Save(FOLDER_IMAGES + "Widen2.bmp");
        }

    

        [Test]
        public void TestWiden1()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);

            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, 100, 100);
            path.AddEllipse(100, 0, 100, 100);

            graphics.DrawPath(Pens.Blue, path);

            // Widen the path.
            Pen widenPen = new Pen(Color.Blue, 10);
            path.Widen(widenPen);

            graphics.FillPath(new SolidBrush(Color.Blue), path);

            sourceBitmap.Save(FOLDER_IMAGES + "Widen1.bmp");
        }

    }
}
