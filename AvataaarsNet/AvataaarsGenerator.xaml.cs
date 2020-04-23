using AvataaarsNet.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AvataaarsNet
{
	/// <summary>
	/// Interaction logic for AvataaarsGenerator.xaml
	/// </summary>
	public partial class AvataaarsGenerator : UserControl, INotifyPropertyChanged
	{
		public static readonly DependencyProperty AvataaarsImageProperty = 
			DependencyProperty.Register(
				"AvataaarsImage",
				typeof(Bitmap),
				typeof(AvataaarsGenerator)
			);
		public Bitmap AvataaarsImage
		{
			get { return (Bitmap)this.GetValue(AvataaarsImageProperty); }
			set { this.SetValue(AvataaarsImageProperty, value); }
		}

		private static Avataaars avataaars;

		private string _SelectedAvatarStyle = "";
		public string SelectedAvatarStyle
		{
			get
			{
				return _SelectedAvatarStyle;
			}
			set
			{
				_SelectedAvatarStyle = value;
				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedSkinColor = "";
		public string SelectedSkinColor
		{
			get
			{
				return _SelectedSkinColor;
			}
			set
			{
				_SelectedSkinColor = value;
				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedEyebrows = "";
		public string SelectedEyebrows
		{
			get
			{
				return _SelectedEyebrows;
			}
			set
			{
				_SelectedEyebrows = value;
				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedEyes = "";
		public string SelectedEyes
		{
			get
			{
				return _SelectedEyes;
			}
			set
			{
				_SelectedEyes = value;
				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedMouth = "";
		public string SelectedMouth
		{
			get
			{
				return _SelectedMouth;
			}
			set
			{
				_SelectedMouth = value;
				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedTopType = "";
		public string SelectedTopType
		{
			get
			{
				return _SelectedTopType;
			}
			set
			{
				_SelectedTopType = value;
				if (_SelectedTopType == "Eyepatch")
				{
					SelectedAccessory = "";
					AccessoryVisibility = Visibility.Collapsed;
				}
				else
				{
					AccessoryVisibility = Visibility.Visible;
				}

				if (_SelectedTopType == "Hijab")
				{
					SelectedFacialHair = "";
					SelectedFacialHairColor = "";
					FacialHairVisibility = Visibility.Collapsed;
				}
				else
				{
					FacialHairVisibility = Visibility.Visible;
				}

				if (_SelectedTopType == "Hijab" ||
					_SelectedTopType == "Turban" ||
					_SelectedTopType == "WinterHat1" ||
					_SelectedTopType == "WinterHat2" ||
					_SelectedTopType == "WinterHat3" ||
					_SelectedTopType == "WinterHat4")
				{
					HatColorVisibility = Visibility.Visible;
				}
				else
				{
					SelectedHatColor = "";
					HatColorVisibility = Visibility.Collapsed;
				}

				if (_SelectedTopType == "Hat" ||
					_SelectedTopType == "NoHair" ||
					_SelectedTopType == "Eyepatch" ||
					_SelectedTopType == "Hijab" ||
					_SelectedTopType == "Turban" ||
					_SelectedTopType == "WinterHat1" ||
					_SelectedTopType == "WinterHat2" ||
					_SelectedTopType == "WinterHat3" ||
					_SelectedTopType == "WinterHat4" ||
					_SelectedTopType == "LongHairFrida" ||
					_SelectedTopType == "LongHairShavedSides")
				{
					SelectedHairColor = "";
					HairColorVisibility = Visibility.Collapsed;
				}
				else
				{
					HairColorVisibility = Visibility.Visible;
				}

				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedHatColor = "";
		public string SelectedHatColor
		{
			get
			{
				return _SelectedHatColor;
			}
			set
			{
				_SelectedHatColor = value;
				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedAccessory = "";
		public string SelectedAccessory
		{
			get
			{
				return _SelectedAccessory;
			}
			set
			{
				_SelectedAccessory = value;
				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedHairColor = "";
		public string SelectedHairColor
		{
			get
			{
				return _SelectedHairColor;
			}
			set
			{
				_SelectedHairColor = value;
				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedFacialHair = "";
		public string SelectedFacialHair
		{
			get
			{
				return _SelectedFacialHair;
			}
			set
			{
				_SelectedFacialHair = value;
				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedFacialHairColor = "";
		public string SelectedFacialHairColor
		{
			get
			{
				return _SelectedFacialHairColor;
			}
			set
			{
				_SelectedFacialHairColor = value;
				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedClothingType = "";
		public string SelectedClothingType
		{
			get
			{
				return _SelectedClothingType;
			}
			set
			{
				_SelectedClothingType = value;

				if (_SelectedClothingType == "BlazerShirt" ||
					_SelectedClothingType == "BlazerSweater")
				{
					SelectedClothingColor = "";
					ClothingColorVisibility = Visibility.Collapsed;
				}
				else
				{
					ClothingColorVisibility = Visibility.Visible;
				}

				if (_SelectedClothingType == "GraphicShirt")
				{
					ClothingGraphicsVisibility = Visibility.Visible;
				}
				else
				{
					SelectedClothingGraphic = "";
					ClothingGraphicsVisibility = Visibility.Collapsed;
				}

				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedClothingColor = "";
		public string SelectedClothingColor
		{
			get
			{
				return _SelectedClothingColor;
			}
			set
			{
				_SelectedClothingColor = value;
				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private string _SelectedClothingGraphic = "";
		public string SelectedClothingGraphic
		{
			get
			{
				return _SelectedClothingGraphic;
			}
			set
			{
				_SelectedClothingGraphic = value;
				if (!string.IsNullOrEmpty(value))
					GenerateNewAvataaars();
				OnPropertyChanged();
			}
		}

		private Visibility _AccessoryVisibility = Visibility.Collapsed;
		public Visibility AccessoryVisibility
		{
			get
			{
				return _AccessoryVisibility;
			}
			set
			{
				_AccessoryVisibility = value;
				OnPropertyChanged();
			}
		}

		private Visibility _FacialHairVisibility = Visibility.Collapsed;
		public Visibility FacialHairVisibility
		{
			get
			{
				return _FacialHairVisibility;
			}
			set
			{
				_FacialHairVisibility = value;
				OnPropertyChanged();
			}
		}

		private Visibility _HatColorVisibility = Visibility.Collapsed;
		public Visibility HatColorVisibility
		{
			get
			{
				return _HatColorVisibility;
			}
			set
			{
				_HatColorVisibility = value;
				OnPropertyChanged();
			}
		}

		private Visibility _HairColorVisibility = Visibility.Collapsed;
		public Visibility HairColorVisibility
		{
			get
			{
				return _HairColorVisibility;
			}
			set
			{
				_HairColorVisibility = value;
				OnPropertyChanged();
			}
		}

		private Visibility _ClothingColorVisibility = Visibility.Collapsed;
		public Visibility ClothingColorVisibility
		{
			get
			{
				return _ClothingColorVisibility;
			}
			set
			{
				_ClothingColorVisibility = value;
				OnPropertyChanged();
			}
		}

		private Visibility _ClothingGraphicsVisibility = Visibility.Collapsed;
		public Visibility ClothingGraphicsVisibility
		{
			get
			{
				return _ClothingGraphicsVisibility;
			}
			set
			{
				_ClothingGraphicsVisibility = value;
				OnPropertyChanged();
			}
		}

		public AvataaarsGenerator()
		{
			InitializeComponent();
			DataContext = this;

			avataaars = new Avataaars();
			AvatarStyle.ItemsSource = avataaars.avatarStyle;
			SkinColor.ItemsSource = avataaars.skinColor;
			Eyesbrows.ItemsSource = avataaars.eyeBrowType;
			Eyes.ItemsSource = avataaars.eyeType;
			Mouth.ItemsSource = avataaars.mouthType;
			TopType.ItemsSource = avataaars.topTypes;
			HatColor.ItemsSource = avataaars.hatColors;
			Accessory.ItemsSource = avataaars.accessories;
			HairColor.ItemsSource = avataaars.hairColors;
			FacialHair.ItemsSource = avataaars.facialHairTypes;
			FacialHairColor.ItemsSource = avataaars.facialHairColors;
			ClothingType.ItemsSource = avataaars.clothingType;
			ClothingColor.ItemsSource = avataaars.clothColor;
			ClothingGraphic.ItemsSource = avataaars.clothGraph;

			GenerateNewAvataaars();
		}

		private async void GenerateNewAvataaars()
		{
			Bitmap bmp = await avataaars.GetNew(_SelectedAvatarStyle, _SelectedSkinColor, _SelectedEyebrows, _SelectedEyes, _SelectedMouth, _SelectedTopType, _SelectedHatColor, _SelectedAccessory, _SelectedHairColor, _SelectedFacialHair, _SelectedFacialHairColor, _SelectedClothingType, _SelectedClothingColor, _SelectedClothingGraphic);
			AvataaarsPreview.Source = ImageConverterHelper.BitmapToBitmapImage(bmp);
			AvataaarsImage = bmp;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				var e = new PropertyChangedEventArgs(propertyName);
				handler(this, e);
			}
		}
	}
}
