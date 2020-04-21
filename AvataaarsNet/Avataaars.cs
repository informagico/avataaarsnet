using AvataaarsNet.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace AvataaarsNet
{
	public class Avataaars
	{
		private const string baseUrl = "https://avataaars.io/";

		internal readonly List<string> avatarStyle = new List<string>()
		{
			"Circle",
			"Transparent"
		};

		internal readonly List<string> skinColor = new List<String>()
		{
			"Tanned",
			"Yellow",
			"Pale",
			"Light",
			"Brown",
			"DarkBrown",
			"Black"
		};

		internal readonly List<string> eyeType = new List<String>()
		{
			"Close",
			"Cry",
			"Default",
			"Dizzy",
			"EyeRoll",
			"Happy",
			"Hearts",
			"Side",
			"Squint",
			"Surprised",
			"Wink",
			"WinkWacky"
		};

		internal readonly List<string> eyeBrowType = new List<String>()
		{
			"Angry",
			"AngryNatural",
			"Default",
			"DefaultNatural",
			"FlatNatural",
			"RaisedExcited",
			"RaisedExcitedNatural",
			"SadConcerned",
			"SadConcernedNatural",
			"UnibrowNatural",
			"UpDown",
			"UpDownNatural"
		};

		internal readonly List<string> mouthType = new List<String>()
		{
			"Concerned",
			"Default",
			"Disbelief",
			"Eating",
			"Grimace",
			"Sad",
			"ScreamOpen",
			"Serious",
			"Smile",
			"Tongue",
			"Twinkle",
			"Vomit"
		};

		internal readonly List<string> topTypes = new List<string>()
		{
			"NoHair",
			"Eyepatch",
			"Hat",
			"Hijab",
			"Turban",
			"WinterHat1",
			"WinterHat2",
			"WinterHat3",
			"WinterHat4",
			"LongHairBigHair",
			"LongHairBob",
			"LongHairBun",
			"LongHairCurly",
			"LongHairCurvy",
			"LongHairDreads",
			"LongHairFrida",
			"LongHairFro",
			"LongHairFroBand",
			"LongHairNotTooLong",
			"LongHairShavedSides",
			"LongHairMiaWallace",
			"LongHairStraight",
			"LongHairStraight2",
			"LongHairStraightStrand",
			"ShortHairDreads01",
			"ShortHairDreads02",
			"ShortHairFrizzle",
			"ShortHairShaggyMullet",
			"ShortHairShortCurly",
			"ShortHairShortFlat",
			"ShortHairShortRound",
			"ShortHairShortWaved",
			"ShortHairSides",
			"ShortHairTheCaesar",
			"ShortHairTheCaesarSidePart"
		};

		internal readonly List<string> hatColors = new List<String>()
		{
			"Black",
			"Blue01",
			"Blue02",
			"Blue03",
			"Gray01",
			"Gray02",
			"Heather",
			"PastelBlue",
			"PastelGreen",
			"PastelOrange",
			"PastelRed",
			"PastelYellow",
			"Pink",
			"Red",
			"White"
		};

		internal readonly List<string> hairColors = new List<String>()
		{
			"Auburn",
			"Black",
			"Blonde",
			"BlondeGolden",
			"Brown",
			"BrownDark",
			"PastelPink",
			"Platinum",
			"Red",
			"SilverGray"
		};


		internal readonly List<string> accessories = new List<string>()
		{
			"Blank",
			"Kurt",
			"Prescription01",
			"Prescription02",
			"Round",
			"Sunglasses",
			"Wayfarers"
		};

		internal readonly List<string> facialHairTypes = new List<string>()
		{
			"Blank",
			"BeardMedium",
			"BeardLight",
			//"BeardMagestic",
			"MoustacheFancy",
			"MoustacheMagnum"
		};

		internal readonly List<string> facialHairColors = new List<String>()
		{
			"Auburn",
			"Black",
			"Blonde",
			"BlondeGolden",
			"Brown",
			"BrownDark",
			"Platinum",
			"Red"
		};

		internal readonly List<string> clothingType = new List<String>()
		{
			"BlazerShirt",
			"BlazerSweater",
			"CollarSweater",
			"GraphicShirt",
			"Hoodie",
			"Overall",
			"ShirtCrewNeck",
			"ShirtScoopNeck",
			"ShirtVNeck"
		};

		internal readonly List<string> clothColor = new List<String>()
		{
			"Black",
			"Blue01",
			"Blue02",
			"Blue03",
			"Gray01",
			"Gray02",
			"Heather",
			"PastelBlue",
			"PastelGreen",
			"PastelOrange",
			"PastelRed",
			"PastelYellow",
			"Pink",
			"Red",
			"White"
		};

		internal readonly List<string> clothGraph = new List<string>()
		{
			"Bat",
			"Cumbia",
			"Deer",
			"Diamond",
			"Hola",
			"Pizza",
			"Resist",
			"Selena",
			"Bear",
			"SkullOutline",
			"Skull"
		};

		private string GetUrl(string avatarStyle, string skinColor, string eyebrows, string eyes, string mouth, string top, string hatColor, string accessory, string hairColor, string facialHair, string facialHairColor, string clothingType, string clothingColor, string clothingGraphic)
		{
			return $"{baseUrl}png/512" +
				$"?avatarStyle={avatarStyle}" +
				$"&topType={top}" +
				$"&hatColor={hatColor}" +
				$"&accessoriesType={accessory}" +
				$"&hairColor={hairColor}" +
				$"&facialHairType={facialHair}" +
				$"&facialHairColor={facialHairColor}" +
				$"&clotheType={clothingType}" +
				$"&clotheColor={clothingColor}" +
				$"&graphicType={clothingGraphic}" +
				$"&eyeType={eyes}" +
				$"&eyebrowType={eyebrows}" +
				$"&mouthType={mouth}" +
				$"&skinColor={skinColor}";
		}

		public Avataaars()
		{ }

		internal async Task<Bitmap> GetNew(string avatarStyle, string skinColor, string eyebrows, string eyes, string mouth, string top, string hatColor, string accessory, string hairColor, string facialHair, string facialHairColor, string clothingType, string clothingColor, string clothingGraphic)
		{
			return await RequestHelper.GetImageBitmapFromUrl(GetUrl(avatarStyle, skinColor, eyebrows, eyes, mouth, top, hatColor, accessory, hairColor, facialHair, facialHairColor, clothingType, clothingColor, clothingGraphic));
		}
	}
}
