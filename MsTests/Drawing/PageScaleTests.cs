
using System;
using System.Collections.Generic;
using System.Deployment.Internal.Isolation;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class PageScaleTests
    {

        float scaleX = 1.2f;
        float scaleY =1.3f;
        float angle = 30;
        float offsetX = 50;
        float offsetY = 100;
        private Matrix matrix;
        PointF rotateCenter = new PointF(400,400);
        private float fontSize = 10;
        PointF leftTopPoint = new PointF(400, 100);
        private SizeF rectSize = new SizeF(100, 200);
        Point[] points = new Point[] { new Point(100, 100), new Point(200, 10), new Point(300, 50), new Point(300, 100) };
        Point start = new Point(100, 100);
        Point control1 = new Point(200, 10);
        Point control2 = new Point(320, 50);
        Point end = new Point(300, 100);
        float startAngle = 45.0F;
        float sweepAngle = 270.0F;


        [SetUp]
        public void SetUp()
        {
            matrix = new Matrix();
        }

        private static String FOLDER_IMAGES = "C:/Projects/Java.SE/modules/Net.Framework/System.Drawing/lib/src/test/resources/com/aspose/ms/System/Drawing/bitmaps/";

        [Test]
        public void TestPageScaleAndRotatePolygon()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            graphics.DrawPolygon(new Pen(Color.Blue), points);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                rotateTransform(graphics,rotateCenter,30);
                graphics.DrawPolygon(new Pen(Color.Red), points);
            }
             sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndRotatePolygon.bmp");
        }

        

        [Test]
        public void TestPageScaleAndTranslatePolygon()
        {
             Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            graphics.DrawPolygon(new Pen(Color.Blue), points);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                translateTransform(graphics,offsetX, offsetY);
                graphics.DrawPolygon(new Pen(Color.Red), points);
            }
             sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndTranslatePolygon.bmp");
        }


        [Test]
        public void TestPageScaleAndScalePolygon()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            graphics.DrawPolygon(new Pen(Color.Blue), points);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                scaleTransform(graphics, scaleX,scaleY);
               graphics.DrawPolygon(new Pen(Color.Red), points);
            }
             sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndScalePolygon.bmp");
        }


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
                rotateTransform(graphics,rotateCenter,30);
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
            graphics.PageUnit = GraphicsUnit.Pixel;
            graphics.PageScale = 2;
            scaleTransform(graphics, scaleX, scaleY);
            graphics.DrawString(findText(2), new Font("Arial", fontSize), new SolidBrush(Color.Blue), rect);
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                matrix = new Matrix();
                scaleTransform(graphics, scaleX, scaleY);
                graphics.DrawString(findText(pageScaleIndex), new Font("Arial", fontSize), new SolidBrush(Color.Blue), rect);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndScaleString.bmp");
        }

        [Test]
        public void TestPageScaleAndRotateEllipse()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(leftTopPoint, rectSize);
            graphics.DrawEllipse(new Pen(Color.Aqua), rect);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                rotateTransform(graphics, rotateCenter, angle);
                graphics.DrawEllipse(new Pen(Color.Aqua), rect);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndRotateEllipse.bmp");
        }



        [Test]
        public void TestPageScaleAndTranslateEllipse()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);

            RectangleF rect = new RectangleF(leftTopPoint, rectSize);
            graphics.DrawEllipse(new Pen(Color.Aqua), rect);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                translateTransform(graphics, offsetX, offsetY);
                graphics.DrawEllipse(new Pen(Color.Aqua), rect);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndTranslateEllipse.bmp");
        }


        [Test]
        public void TestPageScaleAndScaleEllipse()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(leftTopPoint, rectSize);
            graphics.DrawEllipse(new Pen(Color.Aqua), rect);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                scaleTransform(graphics, scaleX, scaleY);
                graphics.DrawEllipse(new Pen(Color.Aqua), rect);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndScaleEllipse.bmp");
        }


       [Test]
        public void TestPageScaleAndRotateCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            graphics.DrawCurve(new Pen(Color.Aqua), points);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                rotateTransform(graphics, rotateCenter, angle);
                graphics.DrawCurve(new Pen(Color.Aqua), points);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndRotateCurve.bmp");
        }



        [Test]
       public void TestPageScaleAndTranslateCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);

            RectangleF rect = new RectangleF(leftTopPoint, rectSize);
            graphics.DrawCurve(new Pen(Color.Aqua), points);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                translateTransform(graphics, offsetX, offsetY);
                graphics.DrawCurve(new Pen(Color.Aqua), points);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndTranslateCurve.bmp");
        }


        [Test]
        public void TestPageScaleAndScaleCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            graphics.DrawCurve(new Pen(Color.Aqua), points);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                scaleTransform(graphics, scaleX, scaleY);
                graphics.DrawCurve(new Pen(Color.Aqua), points);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndScaleCurve.bmp");
        }


     [Test]
        public void TestPageScaleAndRotateClosedCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
      
            graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                rotateTransform(graphics, rotateCenter, angle);
                graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndRotateClosedCurve.bmp");
        }



        [Test]
     public void TestPageScaleAndTranslateClosedCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);

            graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                translateTransform(graphics, offsetX, offsetY);
                graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndTranslateClosedCurve.bmp");
        }



        [Test]
        public void TestPageScaleAndScaleClosedCurve()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                scaleTransform(graphics, scaleX, scaleY);
                graphics.DrawClosedCurve(new Pen(Color.Aqua), points);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndScaleClosedCurve.bmp");
        }

   [Test]
        public void TestPageScaleAndRotateBezier()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                rotateTransform(graphics, rotateCenter, angle);
                graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndRotateBezier.bmp");
        }



        [Test]
   public void TestPageScaleAndTranslateBezier()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);

            RectangleF rect = new RectangleF(leftTopPoint, rectSize);
            graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                translateTransform(graphics, offsetX, offsetY);
                graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndTranslateBezier.bmp");
        }



        [Test]
        public void TestPageScaleAndScaleBezier()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(leftTopPoint, rectSize);
            graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                scaleTransform(graphics, scaleX, scaleY);
                graphics.DrawBezier(new Pen(Color.Aqua), start, control1, control2, end);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndScaleBezier.bmp");
        }

  [Test]
        public void TestPageScaleAndRotateArc()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);

           RectangleF rect = new RectangleF(leftTopPoint, rectSize);
           graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
           graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                rotateTransform(graphics, rotateCenter, angle);
                graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndRotateArc.bmp");
        }



        [Test]
   public void TestPageScaleAndTranslateArc()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);

            RectangleF rect = new RectangleF(leftTopPoint, rectSize);
            graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                translateTransform(graphics, offsetX, offsetY);
                graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndTranslateArc.bmp");
        }



        [Test]
        public void TestPageScaleAndScaleArc()
        {
            Bitmap sourceBitmap = new Bitmap(1600, 1600);
            Graphics graphics = Graphics.FromImage(sourceBitmap);
            graphics.Clear(Color.White);
            RectangleF rect = new RectangleF(leftTopPoint, rectSize);
            graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            graphics.PageUnit = GraphicsUnit.Pixel;
            for (int pageScaleIndex = 1; pageScaleIndex <= 3; pageScaleIndex++)
            {
                graphics.PageScale = pageScaleIndex;
                scaleTransform(graphics, scaleX, scaleY);
                graphics.DrawArc(new Pen(Color.Aqua), rect, startAngle, sweepAngle);
            }
            sourceBitmap.Save(FOLDER_IMAGES + "PageScaleAndScaleArc.bmp");
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


      public void scaleTransform(Graphics g, float scaleX, float scaleY)
      {
          matrix.Scale(scaleX, scaleY);
          g.Transform = matrix;
      }

      public void rotateTransform(Graphics g, PointF rotateCenterm, float angle)
      {
          matrix.RotateAt(angle, rotateCenterm);
          g.Transform = (matrix);
      }

      public void translateTransform(Graphics g, float offsetX, float offsetY)
      {
          matrix.Translate(offsetX, offsetY);
          g.Transform = matrix;
      }

    }
}
