using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvataaarsNet.Models
{
	public static class AvataaarsSettings
	{
		public static readonly List<uint> WidthList = new List<uint>()
		{
			32,
			64,
			128,
			256,
			512,
			1024,
			2048
		};

		public static readonly List<string> AvatarStyleList = new List<string>()
		{
			"Circle",
			"Transparent"
		};

		public static readonly List<string> SkinColorList = new List<String>()
		{
			"Tanned",
			"Yellow",
			"Pale",
			"Light",
			"Brown",
			"DarkBrown",
			"Black"
		};

		public static readonly List<string> EyeTypeList = new List<String>()
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

		public static readonly List<string> EyebrowTypeList = new List<String>()
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

		public static readonly List<string> MouthTypeList = new List<String>()
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

		public static readonly List<string> TopTypeList = new List<string>()
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

		public static readonly List<string> HatColorList = new List<String>()
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

		public static readonly List<string> HairColorList = new List<String>()
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

		public static readonly List<string> AccessoriesTypeList = new List<string>()
		{
			"Blank",
			"Kurt",
			"Prescription01",
			"Prescription02",
			"Round",
			"Sunglasses",
			"Wayfarers"
		};

		public static readonly List<string> FacialHairTypeList = new List<string>()
		{
			"Blank",
			"BeardMedium",
			"BeardLight",
			//"BeardMagestic", // 2020-04-29 not available at this time
			"MoustacheFancy",
			"MoustacheMagnum"
		};

		public static readonly List<string> FacialHairColorList = new List<String>()
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

		public static readonly List<string> ClotheTypeList = new List<String>()
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

		public static readonly List<string> ClotheColorList = new List<String>()
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

		public static readonly List<string> GraphicTypeList = new List<string>()
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

		public static AvataaarsConfiguration Randomize(uint width)
		{
			Random rnd = new Random();

			if (!WidthList.Contains(width))
				return null;

			var configuration = new AvataaarsConfiguration();

			configuration.AvatarWidth = width;

			int index = rnd.Next(AvatarStyleList.Count);
			configuration.AvatarStyle = AvatarStyleList[index];

			index = rnd.Next(SkinColorList.Count);
			configuration.SkinColor = SkinColorList[index];

			index = rnd.Next(EyeTypeList.Count);
			configuration.EyeType = EyeTypeList[index];

			index = rnd.Next(EyebrowTypeList.Count);
			configuration.EyebrowType = EyebrowTypeList[index];

			index = rnd.Next(MouthTypeList.Count);
			configuration.MouthType = MouthTypeList[index];

			index = rnd.Next(TopTypeList.Count);
			configuration.TopType = TopTypeList[index];

			index = rnd.Next(HatColorList.Count);
			configuration.HatColor = HatColorList[index];

			index = rnd.Next(HairColorList.Count);
			configuration.HairColor = HairColorList[index];

			index = rnd.Next(AccessoriesTypeList.Count);
			configuration.AccessoriesType = AccessoriesTypeList[index];

			index = rnd.Next(FacialHairTypeList.Count);
			configuration.FacialHairType = FacialHairTypeList[index];

			index = rnd.Next(FacialHairColorList.Count);
			configuration.FacialHairColor = FacialHairColorList[index];

			index = rnd.Next(ClotheTypeList.Count);
			configuration.ClotheType = ClotheTypeList[index];

			index = rnd.Next(ClotheColorList.Count);
			configuration.ClotheColor = ClotheColorList[index];

			index = rnd.Next(GraphicTypeList.Count);
			configuration.GraphicType = GraphicTypeList[index];

			return configuration;
		}
	}
}
