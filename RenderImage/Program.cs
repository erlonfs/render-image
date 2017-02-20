using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace RenderImage
{
	class Program
	{
		static Bitmap _myBitMap;

		static void Main(string[] args)
		{
			//_myBitMap = (Bitmap)(Image.FromFile("d:/img/google.bmp"));
			//_myBitMap = (Bitmap)(Image.FromFile("d:/img/chome.png"));
			//_myBitMap = (Bitmap)(Image.FromFile("d:/img/img.jpg"));
			//_myBitMap = (Bitmap)(Image.FromFile("d:/img/img1.jpg"));
			//_myBitMap = (Bitmap)(Image.FromFile("d:/img/vlc.jpg"));
			_myBitMap = (Bitmap)(Image.FromFile("e:/img/images.png"));
			//_myBitMap = (Bitmap)(Image.FromFile("d:/img/chomestore.jpg"));
			//_myBitMap = (Bitmap)(Image.FromFile("d:/img/chome.jpg"));
			//_myBitMap = (Bitmap)(Image.FromFile("d:/img/windows.jpg"));
			//_myBitMap = (Bitmap)(Image.FromFile("d:/img/google2.jpg"));
			//_myBitMap = (Bitmap)(Image.FromFile("d:/img/hangout.jpg"));
			//_myBitMap = (Bitmap)(Image.FromFile("d:/img/tc.jpg"));
			//_myBitMap = (Bitmap)(Image.FromFile("d:/img/cogumelo.jpg"));

			SizeF tam = _myBitMap.PhysicalDimension;

			int width = (int)tam.Width;
			int height = (int)tam.Height;

			width = width <= 100 ? 100 : width;
			height = height <= 100 ? 100 : height;

			Console.SetBufferSize(width, height);
			Draw(tam.Width, tam.Height);

		}

		static void Draw(float width, float height)
		{
			int indexChar = 0;

			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					Color pixelColor = _myBitMap.GetPixel(x, y);

					Console.ForegroundColor = ClosestConsoleColor(pixelColor.R, pixelColor.G, pixelColor.B);
					Console.SetCursorPosition(x, y);
					Console.Write(Convert.ToChar(indexChar));

					if (indexChar == char.MaxValue) { indexChar = 0; continue; }
					indexChar++;
				}

			}
		}

		static ConsoleColor ClosestConsoleColor(byte r, byte g, byte b)
		{
			ConsoleColor ret = 0;
			double rr = r, gg = g, bb = b, delta = double.MaxValue;

			foreach (ConsoleColor cc in Enum.GetValues(typeof(ConsoleColor)))
			{
				var n = Enum.GetName(typeof(ConsoleColor), cc);
				var c = System.Drawing.Color.FromName(n == "DarkYellow" ? "Orange" : n); // bug fix
				var t = Math.Pow(c.R - rr, 2.0) + Math.Pow(c.G - gg, 2.0) + Math.Pow(c.B - bb, 2.0);

				if (t == 0.0)
				{
					return cc;
				}

				if (t < delta)
				{
					delta = t;
					ret = cc;
				}
			}

			return ret;

		}

	}
}
