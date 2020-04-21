using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AvataaarsNet.Helpers
{
	class RequestHelper
	{
		public static async Task<Bitmap> GetImageBitmapFromUrl(string url)
		{
			Bitmap imageBitmap = null;

			try
			{
				using (var webClient = new WebClient())
				{
					webClient.UseDefaultCredentials = true;
					webClient.Proxy = WebRequest.GetSystemWebProxy();

					var imageBytes = await webClient.DownloadDataTaskAsync(url);
					if (imageBytes != null && imageBytes.Length > 0)
					{
						using (var stream = new MemoryStream(imageBytes, 0, imageBytes.Length))
						{
							imageBitmap = new Bitmap(Image.FromStream(stream));
						}
					}
				}
			}
			catch
			{
				return null;
			}

			return imageBitmap;
		}
	}
}
