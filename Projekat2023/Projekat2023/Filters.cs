using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2023
{
    public class Filters
    {

		public Filters() { }
		public void Contrast(Bitmap b, sbyte nContrast)
		{
			if (nContrast < -100) return;
			if (nContrast > 100) return;

			double pixel = 0, contrast = (100.0 + nContrast) / 100.0;

			contrast *= contrast;

			int red, green, blue;

			// GDI+ still lies to us - the return format is BGR, NOT RGB.
			BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int stride = bmData.Stride;
			System.IntPtr Scan0 = bmData.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;

				int nOffset = stride - b.Width * 3;

				for (int y = 0; y < b.Height; ++y)
				{
					for (int x = 0; x < b.Width; ++x)
					{
						blue = p[0];
						green = p[1];
						red = p[2];

						pixel = red / 255.0;
						pixel -= 0.5;
						pixel *= contrast;
						pixel += 0.5;
						pixel *= 255;
						if (pixel < 0) pixel = 0;
						if (pixel > 255) pixel = 255;
						p[2] = (byte)pixel;

						pixel = green / 255.0;
						pixel -= 0.5;
						pixel *= contrast;
						pixel += 0.5;
						pixel *= 255;
						if (pixel < 0) pixel = 0;
						if (pixel > 255) pixel = 255;
						p[1] = (byte)pixel;

						pixel = blue / 255.0;
						pixel -= 0.5;
						pixel *= contrast;
						pixel += 0.5;
						pixel *= 255;
						if (pixel < 0) pixel = 0;
						if (pixel > 255) pixel = 255;
						p[0] = (byte)pixel;

						p += 3;
					}
					p += nOffset;
				}
			}

			b.UnlockBits(bmData);

			return;
		}

		public void Sharpen(Bitmap bmp, int nWeight)
		{
			ConvolutionMatrix m = new ConvolutionMatrix();
			m.Apply(0);
			m.Pixel = nWeight;
			m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = -2;
			m.Factor = nWeight - 8;

			Convolution C = new Convolution();
			C.Matrix = m;
			C.Convolution3x3(ref bmp);
		}
		public void RandomJitter(ref Bitmap b, short nDegree)
		{
			Point[,] ptRandJitter = new Point[b.Width, b.Height];

			int nWidth = b.Width;
			int nHeight = b.Height;

			int newX, newY;

			short nHalf = (short)Math.Floor((double)nDegree / 2);
			Random rnd = new Random();

			for (int x = 0; x < nWidth; ++x)
				for (int y = 0; y < nHeight; ++y)
				{
					newX = rnd.Next(nDegree) - nHalf;

					if (x + newX > 0 && x + newX < nWidth)
						ptRandJitter[x, y].X = newX;
					else
						ptRandJitter[x, y].X = 0;

					newY = rnd.Next(nDegree) - nHalf;

					if (y + newY > 0 && y + newY < nWidth)
						ptRandJitter[x, y].Y = newY;
					else
						ptRandJitter[x, y].Y = 0;
				}
			OffsetFilter(b, ptRandJitter);

			return;
		}
		public static bool OffsetFilter(Bitmap b, Point[,] offset)
		{
			Bitmap bSrc = (Bitmap)b.Clone();

			BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

			int scanline = bmData.Stride;

			System.IntPtr Scan0 = bmData.Scan0;
			System.IntPtr SrcScan0 = bmSrc.Scan0;

			unsafe
			{
				byte* p = (byte*)(void*)Scan0;
				byte* pSrc = (byte*)(void*)SrcScan0;

				int nOffset = bmData.Stride - b.Width * 3;
				int nWidth = b.Width;
				int nHeight = b.Height;

				int xOffset, yOffset;

				for (int y = 0; y < nHeight; ++y)
				{
					for (int x = 0; x < nWidth; ++x)
					{
						xOffset = offset[x, y].X;
						yOffset = offset[x, y].Y;

						if (y + yOffset >= 0 && y + yOffset < nHeight && x + xOffset >= 0 && x + xOffset < nWidth)
						{
							p[0] = pSrc[((y + yOffset) * scanline) + ((x + xOffset) * 3)];
							p[1] = pSrc[((y + yOffset) * scanline) + ((x + xOffset) * 3) + 1];
							p[2] = pSrc[((y + yOffset) * scanline) + ((x + xOffset) * 3) + 2];
						}
						p += 3;
					}
					p += nOffset;
				}
			}
			b.UnlockBits(bmData);
			bSrc.UnlockBits(bmSrc);

			return true;
		}

		public void ApplyEdgeDetection(ref Bitmap b)
		{
			{
				int nThreshold = new Random().Next(10, 51);

				Bitmap b2 = (Bitmap)b.Clone();

				BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
				BitmapData bmData2 = b2.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

				int stride = bmData.Stride;
				System.IntPtr Scan0 = bmData.Scan0;
				System.IntPtr Scan02 = bmData2.Scan0;

				unsafe
				{
					byte* p = (byte*)(void*)Scan0;
					byte* p2 = (byte*)(void*)Scan02;

					int nOffset = stride - b.Width * 3;
					int nWidth = b.Width * 3;

					int nPixel = 0, nPixelMax = 0;

					p += stride;
					p2 += stride;

					for (int y = 1; y < b.Height - 1; ++y)
					{
						p += 3;
						p2 += 3;

						for (int x = 3; x < nWidth - 3; ++x)
						{
							nPixelMax = Math.Abs((p2 - stride + 3)[0] - (p2 + stride - 3)[0]);
							nPixel = Math.Abs((p2 + stride + 3)[0] - (p2 - stride - 3)[0]);
							if (nPixel > nPixelMax) nPixelMax = nPixel;

							nPixel = Math.Abs((p2 - stride)[0] - (p2 + stride)[0]);
							if (nPixel > nPixelMax) nPixelMax = nPixel;

							nPixel = Math.Abs((p2 + 3)[0] - (p2 - 3)[0]);
							if (nPixel > nPixelMax) nPixelMax = nPixel;

							if (nPixelMax < nThreshold) nPixelMax = 0;

							p[0] = (byte)nPixelMax;

							++p;
							++p2;
						}

						p += 3 + nOffset;
						p2 += 3 + nOffset;
					}
				}

				b.UnlockBits(bmData);
				b2.UnlockBits(bmData2);

				return;
			}
		}

	}

}

