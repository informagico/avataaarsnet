using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace AvataaarsNet.Helpers
{
	static class ImageConverterHelper
	{
		internal static BitmapImage BitmapToBitmapImage(Bitmap bitmap)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
				stream.Position = 0;
				BitmapImage result = new BitmapImage();
				result.BeginInit();
				result.CacheOption = BitmapCacheOption.OnLoad;
				result.StreamSource = stream;
				result.EndInit();
				result.Freeze();
				return result;
			}
		}
	}
}
