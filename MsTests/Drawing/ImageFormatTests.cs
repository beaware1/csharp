using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NUnit.Framework;

namespace MsTests.Drawing
{
    class ImageFormatTests
    {

        private int width = 10;
        private int height = 10;
        private String path = "D:\\";
        private Dictionary<ImageFormat, String> imageFormats = new Dictionary<ImageFormat, string>();
        private PixelFormat[] actualPixelFormats = new PixelFormat[]
        {
            PixelFormat.Format16bppArgb1555,
            PixelFormat.Format16bppRgb555,
            PixelFormat.Format16bppRgb565,
            PixelFormat.Format1bppIndexed,
            PixelFormat.Format24bppRgb,
            PixelFormat.Format32bppArgb,
            PixelFormat.Format32bppPArgb,
            PixelFormat.Format32bppRgb,
            PixelFormat.Format48bppRgb,
            PixelFormat.Format4bppIndexed,
            PixelFormat.Format64bppArgb,
            PixelFormat.Format64bppPArgb,
            PixelFormat.Format8bppIndexed
        };

        private static List<TestFormat> expectedImageFormats = new List<TestFormat>();

        [SetUp]
        public void BeforeMethod()
        {
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppArgb1555, PixelFormat.Format24bppRgb, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppArgb1555, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppArgb1555, PixelFormat.Format32bppArgb, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppArgb1555, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppArgb1555, PixelFormat.Format32bppArgb, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppArgb1555, PixelFormat.Format32bppArgb, ImageFormat.Tiff));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppRgb555, PixelFormat.Format32bppRgb, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppRgb555, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppRgb555, PixelFormat.Format32bppArgb, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppRgb555, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppRgb555, PixelFormat.Format32bppArgb, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppRgb555, PixelFormat.Format24bppRgb, ImageFormat.Tiff));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppRgb565, PixelFormat.Format32bppRgb, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppRgb565, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppRgb565, PixelFormat.Format32bppArgb, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppRgb565, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppRgb565, PixelFormat.Format32bppArgb, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format16bppRgb565, PixelFormat.Format24bppRgb, ImageFormat.Tiff));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format1bppIndexed, PixelFormat.Format1bppIndexed, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format1bppIndexed, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format1bppIndexed, PixelFormat.Format1bppIndexed, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format1bppIndexed, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format1bppIndexed, PixelFormat.Format1bppIndexed, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format1bppIndexed, PixelFormat.Format1bppIndexed, ImageFormat.Tiff));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format24bppRgb, PixelFormat.Format24bppRgb, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format24bppRgb, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format24bppRgb, PixelFormat.Format24bppRgb, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format24bppRgb, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format24bppRgb, PixelFormat.Format24bppRgb, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format24bppRgb, PixelFormat.Format24bppRgb, ImageFormat.Tiff));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppArgb, PixelFormat.Format32bppRgb, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppArgb, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppArgb, PixelFormat.Format32bppArgb, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppArgb, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppArgb, PixelFormat.Format32bppArgb, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppArgb, PixelFormat.Format32bppArgb, ImageFormat.Tiff));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppPArgb, PixelFormat.Format32bppRgb, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppPArgb, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppPArgb, PixelFormat.Format32bppArgb, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppPArgb, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppPArgb, PixelFormat.Format32bppArgb, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppPArgb, PixelFormat.Format32bppArgb, ImageFormat.Tiff));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppRgb, PixelFormat.Format32bppRgb, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppRgb, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppRgb, PixelFormat.Format32bppArgb, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppRgb, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppRgb, PixelFormat.Format32bppArgb, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format32bppRgb, PixelFormat.Format32bppArgb, ImageFormat.Tiff));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format48bppRgb, PixelFormat.Format24bppRgb, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format48bppRgb, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format48bppRgb, PixelFormat.Format32bppArgb, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format48bppRgb, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format48bppRgb, PixelFormat.Format32bppArgb, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format48bppRgb, PixelFormat.Format24bppRgb, ImageFormat.Tiff));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format4bppIndexed, PixelFormat.Format4bppIndexed, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format4bppIndexed, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format4bppIndexed, PixelFormat.Format4bppIndexed, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format4bppIndexed, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format4bppIndexed, PixelFormat.Format4bppIndexed, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format4bppIndexed, PixelFormat.Format4bppIndexed, ImageFormat.Tiff));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format64bppArgb, PixelFormat.Format64bppArgb, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format64bppArgb, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format64bppArgb, PixelFormat.Format32bppArgb, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format64bppArgb, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format64bppArgb, PixelFormat.Format32bppArgb, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format64bppArgb, PixelFormat.Format32bppArgb, ImageFormat.Tiff));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format64bppPArgb, PixelFormat.Format64bppArgb, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format64bppPArgb, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format64bppPArgb, PixelFormat.Format32bppArgb, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format64bppPArgb, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format64bppPArgb, PixelFormat.Format32bppArgb, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format64bppPArgb, PixelFormat.Format32bppArgb, ImageFormat.Tiff));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format8bppIndexed, PixelFormat.Format8bppIndexed, ImageFormat.Bmp));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format8bppIndexed, PixelFormat.Format8bppIndexed, ImageFormat.Gif));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format8bppIndexed, PixelFormat.Format32bppArgb, ImageFormat.Icon));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format8bppIndexed, PixelFormat.Format24bppRgb, ImageFormat.Jpeg));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format8bppIndexed, PixelFormat.Format32bppArgb, ImageFormat.Png));
            expectedImageFormats.Add(new TestFormat(PixelFormat.Format8bppIndexed, PixelFormat.Format8bppIndexed, ImageFormat.Tiff));


            imageFormats.Add(ImageFormat.Bmp, "bmp");
            imageFormats.Add(ImageFormat.Gif, "gif");
            imageFormats.Add(ImageFormat.Icon, "ico");
            imageFormats.Add(ImageFormat.Jpeg, "jpg");
            imageFormats.Add(ImageFormat.Png, "png");
            imageFormats.Add(ImageFormat.Tiff, "tiff");
        }

        [Test]
        public void TestTiffImages()
        {
            foreach (PixelFormat pixelFormat in actualPixelFormats)
            {
                Bitmap expectedBitmap = CreateImage(pixelFormat);
                foreach (ImageFormat imageFormat in imageFormats.Keys)
                {
                    String bitmapName = pixelFormat + "_" + imageFormat + "." + imageFormats[imageFormat];
                    expectedBitmap.Save(Path.Combine(path, bitmapName), imageFormat);
                    Bitmap actualBitmap = new Bitmap(Path.Combine(path, bitmapName));
                    PixelFormat expectedPixelFormat = expectedBitmap.PixelFormat;
                    PixelFormat actualPixelFormat = actualBitmap.PixelFormat;
                    Console.WriteLine("expectedImageFormats.add(new TestFormat(PixelFormat." + expectedPixelFormat + ", PixelFormat." + actualPixelFormat + ", ImageFormat.get" + imageFormat + "()));");
//                    if (GetResultPixelFormat(expectedPixelFormat, imageFormat) != actualPixelFormat)
//                    {
//                        throw new NotImplementedException();
//                    }
                }
            }
        }

        public Bitmap CreateImage(PixelFormat pixelFormat)
        {
            Bitmap bitmap = new Bitmap(width, height, pixelFormat);
            try
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.Clear(Color.White);
                g.DrawRectangle(new Pen(Color.Red), new Rectangle(1, 1, 4, 2));
            }
            catch (Exception e)
            {
            }
            return bitmap;
        }

        public static PixelFormat GetResultPixelFormat(PixelFormat sourcePixelFormat, ImageFormat imageFormat)
        {
            foreach (TestFormat testFormat in expectedImageFormats)
            {
                if (testFormat.sourcePixelFormat == sourcePixelFormat && testFormat.imageFormat == imageFormat)
                {
                    return testFormat.resultPixelFormat;
                }
            }
            throw new Exception();
        }

        private class TestFormat
        {
            public PixelFormat sourcePixelFormat;
            public PixelFormat resultPixelFormat;
            public ImageFormat imageFormat;

            public TestFormat(PixelFormat sourcePixelFormat, PixelFormat resultPixelFormat, ImageFormat imageFormat)
            {
                this.sourcePixelFormat = sourcePixelFormat;
                this.resultPixelFormat = resultPixelFormat;
                this.imageFormat = imageFormat;
            }
        }
    }
}
