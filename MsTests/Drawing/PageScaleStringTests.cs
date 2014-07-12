using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class PageScaleStringTests
    {
        float scaleX = 1.2f;
        float scaleY = 1.3f;
        float angle = 30;
        float offsetX = 50;
        float offsetY = 100;
        private Matrix matrix;
        PointF rotateCenter = new PointF(400, 400);
        private float fontSize = 10;
        private SizeF rectSize = new SizeF(100, 200);


        [SetUp]
        public void SetUp()
        {
            matrix = new Matrix();
        }

        private static String FOLDER_IMAGES = "YOUR/METAFILES_PATH";


        [Test]
        public void TestPageScaleString()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(rotateCenter, rectSize);
            graphics.DrawString(findText(0), new Font("Arial", fontSize), new SolidBrush(Color.Blue), rect);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 2; pageScaleIndex <= 5; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                graphics.DrawString(findText(pageScaleIndex), new Font("Arial", fontSize), new SolidBrush(Color.Blue), rect);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleString.bmp");
        }



        [Test]
        public void TestPageScaleAndRotateString()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(rotateCenter, rectSize);
            graphics.DrawString(findText(0), new Font("Arial", fontSize), new SolidBrush(Color.Blue), rect);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                rotateTransform(graphics, rotateCenter, 30);
                graphics.DrawString(findText(pageScaleIndex), new Font("Arial", fontSize), new SolidBrush(Color.Blue), rect);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndRotateString.bmp");
        }





        [Test]
        public void TestPageScaleAndTranslateString()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(rotateCenter, rectSize);
            graphics.DrawString(findText(0), new Font("Arial", fontSize), new SolidBrush(Color.Blue), rect);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                matrix = new Matrix();
                translateTransform(graphics, offsetX, offsetY);
                graphics.DrawString(findText(pageScaleIndex), new Font("Arial", fontSize), new SolidBrush(Color.Blue), rect);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndTranslateString.bmp");
        }




        [Test]
        public void TestPageScaleAndScaleString()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(rotateCenter, new SizeF(400, 400));
            graphics.DrawString(findText(0), new Font("Arial", fontSize), new SolidBrush(Color.Blue), rect);
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                matrix = new Matrix();
                scaleTransform(graphics, scaleX, scaleY);
                graphics.DrawString(findText(pageScaleIndex), new Font("Arial", fontSize), new SolidBrush(Color.Blue), rect);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndScaleString.bmp");
        }

        private String findText(int i)
        {
            switch (i)
            {
                case 0:
                    return "AAA";
                case 1:
                    return "BBB";
                case 2:
                    return "CCC";
                case 3:
                    return "DDD";
                case 4:
                    return "EEE";
                case 5:
                    return "FFF";
                default:
                    return "AAA";
            }
        }


        private void scaleTransform(Graphics g, float scaleX, float scaleY)
        {
            matrix.Scale(scaleX, scaleY);
            g.Transform = matrix;
        }

        private void rotateTransform(Graphics g, PointF rotateCenterm, float angle)
        {
            matrix.RotateAt(angle, rotateCenterm);
            g.Transform = (matrix);
        }

        private void translateTransform(Graphics g, float offsetX, float offsetY)
        {
            matrix.Translate(offsetX, offsetY);
            g.Transform = matrix;
        }
    }
}
