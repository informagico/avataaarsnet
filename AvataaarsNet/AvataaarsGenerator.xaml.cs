using AvataaarsNet.Helpers;
using AvataaarsNet.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace AvataaarsNet
{
	/// <summary>
	/// Interaction logic for AvataaarsGenerator.xaml
	/// </summary>
	public partial class AvataaarsGenerator : UserControl, INotifyPropertyChanged
	{
		private static Avataaars avataaars;

		#region DEPENDENCY PROPERTIES

		/// <summary>
		/// AvataaarsImage dependency property
		/// </summary>
		public static readonly DependencyProperty AvatarProperty =
			DependencyProperty.Register(
				"Avatar",
				typeof(Bitmap),
				typeof(AvataaarsGenerator)
			);
		public Bitmap Avatar
		{
			get { return (Bitmap)this.GetValue(AvatarProperty); }
			set { this.SetValue(AvatarProperty, value); }
		}

		/// <summary>
		/// AvataaarsConfiguration dependency property
		/// </summary>
		public static DependencyProperty ConfigurationProperty =
			DependencyProperty.Register(
				"Configuration",
				typeof(AvataaarsConfiguration),
				typeof(AvataaarsGenerator),
				new PropertyMetadata(OnConfigurationPropertyChanged)
			);
		public AvataaarsConfiguration Configuration
		{
			get { return (AvataaarsConfiguration)this.GetValue(ConfigurationProperty); }
			set { this.SetValue(ConfigurationProperty, value); }
		}

		/// <summary>
		/// AvataaarsWidthEnabled dependency property
		/// </summary>
		public static readonly DependencyProperty EnableWidthProperty =
			DependencyProperty.Register(
				"EnableWidth",
				typeof(bool),
				typeof(AvataaarsGenerator)
			);
		public bool EnableWidth
		{
			get { return (bool)this.GetValue(EnableWidthProperty); }
			set { this.SetValue(EnableWidthProperty, value); }
		}
		#endregion

		#region BINDING PROPERTIES
		private uint _Width = 0;
		public uint AvatarWidth
		{
			get
			{
				return _Width;
			}
			set
			{
				if (_Width == value)
					return;

				_Width = value;

				if (avataaars.Configuration.AvatarWidth != value)
				{
					avataaars.Configuration.AvatarWidth = _Width;

					GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _AvatarStyle = String.Empty;
		public string AvatarStyle
		{
			get
			{
				return _AvatarStyle;
			}
			set
			{
				if (_AvatarStyle == value)
					return;

				_AvatarStyle = value;

				if (avataaars.Configuration.AvatarStyle != value)
				{
					avataaars.Configuration.AvatarStyle = _AvatarStyle;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _SkinColor = String.Empty;
		public string SkinColor
		{
			get
			{
				return _SkinColor;
			}
			set
			{
				if (_SkinColor == value)
					return;

				_SkinColor = value;

				if (avataaars.Configuration.SkinColor != value)
				{
					avataaars.Configuration.SkinColor = _SkinColor;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _EyebrowType = String.Empty;
		public string EyebrowType
		{
			get
			{
				return _EyebrowType;
			}
			set
			{
				if (_EyebrowType == value)
					return;

				_EyebrowType = value;

				if (avataaars.Configuration.EyebrowType != value)
				{
					avataaars.Configuration.EyebrowType = _EyebrowType;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _EyeType = String.Empty;
		public string EyeType
		{
			get
			{
				return _EyeType;
			}
			set
			{
				if (_EyeType == value)
					return;

				_EyeType = value;

				if (avataaars.Configuration.EyeType != value)
				{
					avataaars.Configuration.EyeType = _EyeType;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _MouthType = String.Empty;
		public string MouthType
		{
			get
			{
				return _MouthType;
			}
			set
			{
				if (_MouthType == value)
					return;

				_MouthType = value;

				if (avataaars.Configuration.MouthType != value)
				{
					avataaars.Configuration.MouthType = _MouthType;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _TopType = String.Empty;
		public string TopType
		{
			get
			{
				return _TopType;
			}
			set
			{
				if (_TopType == value)
					return;

				_TopType = value;

				if (_TopType == "Eyepatch")
				{
					AccessoriesType = "";
					AccessoriesVisibility = Visibility.Collapsed;
				}
				else
				{
					AccessoriesVisibility = Visibility.Visible;
				}

				if (_TopType == "Hijab")
				{
					FacialHairType = "";
					FacialHairColor = "";
					FacialHairVisibility = Visibility.Collapsed;
				}
				else
				{
					FacialHairVisibility = Visibility.Visible;
				}

				if (_TopType == "Hijab" ||
					_TopType == "Turban" ||
					_TopType == "WinterHat1" ||
					_TopType == "WinterHat2" ||
					_TopType == "WinterHat3" ||
					_TopType == "WinterHat4")
				{
					HatColorVisibility = Visibility.Visible;
				}
				else
				{
					HatColor = "";
					HatColorVisibility = Visibility.Collapsed;
				}

				if (_TopType == "Hat" ||
					_TopType == "NoHair" ||
					_TopType == "Eyepatch" ||
					_TopType == "Hijab" ||
					_TopType == "Turban" ||
					_TopType == "WinterHat1" ||
					_TopType == "WinterHat2" ||
					_TopType == "WinterHat3" ||
					_TopType == "WinterHat4" ||
					_TopType == "LongHairFrida" ||
					_TopType == "LongHairShavedSides")
				{
					HairColor = "";
					HairColorVisibility = Visibility.Collapsed;
				}
				else
				{
					HairColorVisibility = Visibility.Visible;
				}

				if (avataaars.Configuration.TopType != value)
				{
					avataaars.Configuration.TopType = _TopType;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _HatColor = String.Empty;
		public string HatColor
		{
			get
			{
				return avataaars.Configuration.HatColor;
			}
			set
			{
				if (_HatColor == value)
					return;

				_HatColor = value;

				if (avataaars.Configuration.HatColor != value)
				{
					avataaars.Configuration.HatColor = _HatColor;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _AccessoriesType = String.Empty;
		public string AccessoriesType
		{
			get
			{
				return _AccessoriesType;
			}
			set
			{
				if (_AccessoriesType == value)
					return;

				_AccessoriesType = value;

				if (avataaars.Configuration.AccessoriesType != value)
				{
					avataaars.Configuration.AccessoriesType = _AccessoriesType;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _HairColor = String.Empty;
		public string HairColor
		{
			get
			{
				return _HairColor;
			}
			set
			{
				if (_HairColor == value)
					return;

				_HairColor = value;

				if (avataaars.Configuration.HairColor != value)
				{
					avataaars.Configuration.HairColor = _HairColor;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _FacialHairType = String.Empty;
		public string FacialHairType
		{
			get
			{
				return _FacialHairType;
			}
			set
			{
				if (_FacialHairType == value)
					return;

				_FacialHairType = value;

				if (avataaars.Configuration.FacialHairType != value)
				{
					avataaars.Configuration.FacialHairType = _FacialHairType;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _FacialHairColor = String.Empty;
		public string FacialHairColor
		{
			get
			{
				return _FacialHairColor;
			}
			set
			{
				if (_FacialHairColor == value)
					return;

				_FacialHairColor = value;

				if (avataaars.Configuration.FacialHairColor != value)
				{
					avataaars.Configuration.FacialHairColor = _FacialHairColor;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _ClotheType = String.Empty;
		public string ClotheType
		{
			get
			{
				return _ClotheType;
			}
			set
			{
				if (_ClotheType == value)
					return;

				_ClotheType = value;

				if (_ClotheType == "BlazerShirt" ||
					_ClotheType == "BlazerSweater")
				{
					ClotheColor = "";
					ClotheColorVisibility = Visibility.Collapsed;
				}
				else
				{
					ClotheColorVisibility = Visibility.Visible;
				}

				if (_ClotheType == "GraphicShirt")
				{
					GraphicTypeVisibility = Visibility.Visible;
				}
				else
				{
					GraphicType = "";
					GraphicTypeVisibility = Visibility.Collapsed;
				}

				if (avataaars.Configuration.ClotheType != value)
				{
					avataaars.Configuration.ClotheType = _ClotheType;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _ClotheColor = String.Empty;
		public string ClotheColor
		{
			get
			{
				return _ClotheColor;
			}
			set
			{
				if (_ClotheColor == value)
					return;

				_ClotheColor = value;

				if (avataaars.Configuration.ClotheColor != value)
				{
					avataaars.Configuration.ClotheColor = _ClotheColor;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}

		private string _GraphicType = String.Empty;
		public string GraphicType
		{
			get
			{
				return _GraphicType;
			}
			set
			{
				if (_GraphicType == value)
					return;

				_GraphicType = value;

				if (avataaars.Configuration.GraphicType != value)
				{
					avataaars.Configuration.GraphicType = _GraphicType;

					if (!string.IsNullOrEmpty(value))
						GenerateAvataaars();
				}

				OnPropertyChanged();
			}
		}
		#endregion

		#region VISIBILITY PROPERTIES
		private Visibility _AccessoriesVisibility = Visibility.Collapsed;
		public Visibility AccessoriesVisibility
		{
			get
			{
				return _AccessoriesVisibility;
			}
			set
			{
				if (_AccessoriesVisibility == value)
					return;

				_AccessoriesVisibility = value;
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
				if (_FacialHairVisibility == value)
					return;

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
				if (_HatColorVisibility == value)
					return;

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
				if (_HairColorVisibility == value)
					return;

				_HairColorVisibility = value;

				OnPropertyChanged();
			}
		}

		private Visibility _ClotheColorVisibility = Visibility.Collapsed;
		public Visibility ClotheColorVisibility
		{
			get
			{
				return _ClotheColorVisibility;
			}
			set
			{
				if (_ClotheColorVisibility == value)
					return;

				_ClotheColorVisibility = value;

				OnPropertyChanged();
			}
		}

		private Visibility _GraphicTypeVisibility = Visibility.Collapsed;
		public Visibility GraphicTypeVisibility
		{
			get
			{
				return _GraphicTypeVisibility;
			}
			set
			{
				if (_GraphicTypeVisibility == value)
					return;

				_GraphicTypeVisibility = value;

				OnPropertyChanged();
			}
		}
		#endregion

		#region PRIVATE METHODS
		private async void GenerateAvataaars()
		{
			// generate avatar and preview
			Bitmap bmp = await avataaars.Generate();
			AvataaarsPreview.Source = ImageConverterHelper.BitmapToBitmapImage(bmp);

			// dependency properties
			Avatar = bmp;
			Configuration = avataaars.Configuration;
		}

		private void AssignLists()
		{
			AvatarWidthCombo.ItemsSource = AvataaarsSettings.WidthList;
			AvatarStyleCombo.ItemsSource = AvataaarsSettings.AvatarStyleList;
			SkinColorCombo.ItemsSource = AvataaarsSettings.SkinColorList;
			EyebrowTypeCombo.ItemsSource = AvataaarsSettings.EyebrowTypeList;
			EyeTypeCombo.ItemsSource = AvataaarsSettings.EyeTypeList;
			MouthTypeCombo.ItemsSource = AvataaarsSettings.MouthTypeList;
			TopTypeCombo.ItemsSource = AvataaarsSettings.TopTypeList;
			HatColorCombo.ItemsSource = AvataaarsSettings.HatColorList;
			AccessoriesTypeCombo.ItemsSource = AvataaarsSettings.AccessoriesTypeList;
			HairColorCombo.ItemsSource = AvataaarsSettings.HairColorList;
			FacialHairTypeCombo.ItemsSource = AvataaarsSettings.FacialHairTypeList;
			FacialHairColorCombo.ItemsSource = AvataaarsSettings.FacialHairColorList;
			ClotheTypeCombo.ItemsSource = AvataaarsSettings.ClotheTypeList;
			ClotheColorCombo.ItemsSource = AvataaarsSettings.ClotheColorList;
			GraphicTypeCombo.ItemsSource = AvataaarsSettings.GraphicTypeList;
		}

		private void LoadConfiguration()
		{
			AvatarWidth = avataaars.Configuration.AvatarWidth;
			AvatarStyle = avataaars.Configuration.AvatarStyle;
			SkinColor = avataaars.Configuration.SkinColor;
			EyebrowType = avataaars.Configuration.EyebrowType;
			EyeType = avataaars.Configuration.EyeType;
			MouthType = avataaars.Configuration.MouthType;
			TopType = avataaars.Configuration.TopType;
			HatColor = avataaars.Configuration.HatColor;
			AccessoriesType = avataaars.Configuration.AccessoriesType;
			HairColor = avataaars.Configuration.HairColor;
			FacialHairType = avataaars.Configuration.FacialHairType;
			FacialHairColor = avataaars.Configuration.FacialHairColor;
			ClotheType = avataaars.Configuration.ClotheType;
			ClotheColor = avataaars.Configuration.ClotheColor;
			GraphicType = avataaars.Configuration.GraphicType;
		}
		#endregion

		public AvataaarsGenerator()
		{
			InitializeComponent();
			DataContext = this;

			avataaars = new Avataaars();

			AssignLists();
			LoadConfiguration();
			GenerateAvataaars();
		}

		#region PROPERTY CHANGED EVENTS & CALLBACKS
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

		private static void OnConfigurationPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			if (avataaars.Configuration != (sender as AvataaarsGenerator).Configuration)
			{
				avataaars.Configuration = (sender as AvataaarsGenerator).Configuration;
				(sender as AvataaarsGenerator).LoadConfiguration();
				(sender as AvataaarsGenerator).GenerateAvataaars();
			}
		}
		#endregion
	}
}
