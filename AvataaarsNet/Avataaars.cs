using AvataaarsNet.Helpers;
using AvataaarsNet.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace AvataaarsNet
{
	public class Avataaars
	{
		private const string baseUrl = "https://avataaars.io/"

		internal AvataaarsConfiguration Configuration { get; set; }

		/// <summary>
		/// Returns a correctly formatted URL to be called to retrieve the image
		/// </summary>
		/// <returns></returns>
		private string GetUrl()
		{
			return $"{ baseUrl }png/{ Configuration.AvatarWidth }" +
				$"?avatarStyle={ Configuration.AvatarStyle }" +
				$"&topType={ Configuration.TopType }" +
				$"&hatColor={ Configuration.HatColor }" +
				$"&accessoriesType={ Configuration.AccessoriesType }" +
				$"&hairColor={ Configuration.HairColor }" +
				$"&facialHairType={ Configuration.FacialHairType }" +
				$"&facialHairColor={ Configuration.FacialHairColor }" +
				$"&clotheType={ Configuration.ClotheType }" +
				$"&clotheColor={ Configuration.ClotheColor }" +
				$"&graphicType={ Configuration.GraphicType }" +
				$"&eyeType={ Configuration.EyeType }" +
				$"&eyebrowType={ Configuration.EyebrowType }" +
				$"&mouthType={ Configuration.MouthType }" +
				$"&skinColor={ Configuration.SkinColor }";
		}

		/// <summary>
		/// Calll the backend to generate a PNG and returns the relative Bitmap image
		/// </summary>
		/// <returns></returns>
		internal async Task<Bitmap> Generate()
		{
			return await RequestHelper.GetImageBitmapFromUrl(GetUrl());
		}

		public Avataaars()
		{
			Configuration = new AvataaarsConfiguration();
		}
	}
}
