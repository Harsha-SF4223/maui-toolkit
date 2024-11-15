﻿using System.Windows.Input;
using Microsoft.Maui.Controls.Shapes;
using Syncfusion.Maui.Toolkit.Chips;
using Syncfusion.Maui.Toolkit.EffectsView;
using Syncfusion.Maui.Toolkit.Graphics.Internals;
using Syncfusion.Maui.Toolkit.Internals;
using Grid = Microsoft.Maui.Controls.Grid;
using Image = Microsoft.Maui.Controls.Image;
using PointerEventArgs = Syncfusion.Maui.Toolkit.Internals.PointerEventArgs;

namespace Syncfusion.Maui.Toolkit
{
	/// <summary>
	/// Represents the <see cref="ButtonBase"/> class.
	/// </summary>
	public abstract class ButtonBase : SfView, ITouchListener, ITextElement, ITapGestureListener
	{

		#region Bindable Properties

		/// <summary>
		/// Gets or sets the value of CornerRadius. This property can be used to change the corner radius. This is a bindable property.
		/// </summary>
		public static readonly BindableProperty CornerRadiusProperty =
			BindableProperty.Create(nameof(CornerRadius), typeof(CornerRadius), typeof(ButtonBase), new CornerRadius(8), BindingMode.Default, null, OnCornerRadiusPropertyChanged);

		/// <summary>
		/// Gets or sets the value of BorderThickness.This property can be used to give border thickness to ButtonBase control.This is a bindable property.
		/// </summary>
		public static readonly BindableProperty StrokeThicknessProperty =
			BindableProperty.Create(nameof(StrokeThickness), typeof(double), typeof(ButtonBase), 1d, BindingMode.TwoWay, null, OnStrokeThicknessPropertyChanged);

		/// <summary>
		///  Gets or sets the value of Stroke.This property can be used to give border Color to ButtonBase control.This is a bindable property.
		/// </summary>
		public static readonly BindableProperty StrokeProperty =
			BindableProperty.Create(nameof(Stroke), typeof(Brush), typeof(ButtonBase), new SolidColorBrush(Color.FromArgb("#79747E")), BindingMode.Default, null, OnStrokePropertyChanged);

		/// <summary>
		/// Gets or sets the value of BackgroundColor.This property can be used to give Background Color to ButtonBase control.This is a bindable property.
		/// </summary>
		public static new readonly BindableProperty BackgroundProperty =
			BindableProperty.Create(nameof(Background), typeof(Brush), typeof(ButtonBase), new SolidColorBrush(Colors.Transparent), BindingMode.Default, null, OnBackgroundPropertyChanged);

		/// <summary>
		///  Gets or sets the value of Text.This property can be used to give Text to the ButtonBase control.This is Bindable Property.
		/// </summary>
		public static readonly BindableProperty TextProperty =
			BindableProperty.Create(nameof(Text), typeof(string), typeof(ButtonBase), string.Empty, BindingMode.Default, null, OnTextPropertyChanged);

		/// <summary>
		/// Gets or sets the value of Text Color.This property can be used to give Text Color to the text in the ButtonBase control.This is Bindable Property
		/// </summary>
		public static readonly BindableProperty TextColorProperty =
			BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(ButtonBase), Color.FromArgb("#49454F"), BindingMode.Default, null, OnTextColorPropertyChanged);

		/// <summary>
		/// Gets or sets the value of FontSize.This property can be used to give FontSize to the Text in ButtonBase control.This is Bindable Property.
		/// </summary>
		public static readonly BindableProperty FontSizeProperty = FontElement.FontSizeProperty;

		/// <summary>
		/// Identifies the <see cref="FontAutoScalingEnabled"/> bindable property.
		/// </summary>
		/// <value>
		/// The identifier for <see cref="FontAutoScalingEnabled"/> bindable property.
		/// </value>
		public static readonly BindableProperty FontAutoScalingEnabledProperty = FontElement.FontAutoScalingEnabledProperty;

		/// <summary>
		/// Gets or sets the value of HorizontalTextAlignment.This property can be used to give HorizontalTextAlignment to the Text in ButtonBase control.This is Bindable Property
		/// </summary>
		public static readonly BindableProperty HorizontalTextAlignmentProperty =
			BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(ButtonBase), TextAlignment.Center, BindingMode.Default, null, OnHorizantalAlignmentPropertyChanged);

		/// <summary>
		/// Gets or sets the value of VerticalTextAlignment.This property can be used to give VerticalTextAlignment to the Text in ButtonBase control.This is Bindable Property
		/// </summary>
		public static readonly BindableProperty VerticalTextAlignmentProperty =
			BindableProperty.Create(nameof(VerticalTextAlignment), typeof(TextAlignment), typeof(ButtonBase), TextAlignment.Center, BindingMode.Default, null, OnVerticalTextAlignmentPropertyChanged);

		/// <summary>
		/// Identifies the ImageSource property. This property can be used to set an source of an image.This is Bindable Property.
		/// </summary>
		public static readonly BindableProperty ImageSourceProperty =
			BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(ButtonBase), null, BindingMode.Default, null, OnImageSourcePropertyChanged);

		/// <summary>
		/// Identifies the ShowIcon property. This property can be used to set an icon by setting this property to true.This is Bindable Property.
		/// </summary>
		public static readonly BindableProperty ShowIconProperty =
			BindableProperty.Create(nameof(ShowIcon), typeof(bool), typeof(ButtonBase), false, BindingMode.Default, null, OnImageSourcePropertyChanged);

		/// <summary>
		/// Identifies the <see cref="ImageSize"/> bindable property. This property can be used to customize the width of an imgage in the ButtonBase control.
		/// </summary>
		/// <remarks>This <see cref="BindableProperty"/> is read-only.</remarks>
		public static readonly BindableProperty ImageSizeProperty =
			BindableProperty.Create(nameof(ImageSize), typeof(double), typeof(ButtonBase), 18d, BindingMode.Default, null, OnImageSizePropertyChanged);

		/// <summary>
		/// Identifies the ImageAlignment property. This property can be used to change the position of the image in the ButtonBase control.
		/// </summary>
		/// <remarks>This <see cref="BindableProperty"/> is read-only.</remarks>
		public static readonly BindableProperty ImageAlignmentProperty =
			BindableProperty.Create(nameof(ImageAlignment), typeof(Alignment), typeof(ButtonBase), Alignment.Start, BindingMode.Default, null, OnImageAlignmentChanged);

		/// <summary>
		/// Identifies the BackgroundImageSource property. This property can be used to set an image as the background of ButtonBase.
		/// </summary>
		/// <remarks>This <see cref="BindableProperty"/> is read-only.</remarks>
		public static readonly BindableProperty BackgroundImageSourceProperty =
			BindableProperty.Create(nameof(BackgroundImageSource), typeof(ImageSource), typeof(ButtonBase), null, BindingMode.Default, null, OnBackgroundImageSourcePropertyChanged);

		/// <summary>
		/// Identifies the <see cref="Command"/> bindable property. It invokes when the ButtonBase is activated. The default value is null.
		/// </summary>
		/// <remarks>This bindable property is read-only.</remarks>
		public static readonly BindableProperty CommandProperty =
			BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ButtonBase), null, BindingMode.OneWay, null, OnCommandPropertyChanged);

		/// <summary>
		/// Identifies the <see cref="CommandParameter"/> bindable property. It is a parameter to pass to the Command property. This is a bindable property.
		/// </summary>
		/// <remarks>This bindable property is read-only.</remarks>
		public static readonly BindableProperty CommandParameterProperty =
			BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ButtonBase), null, BindingMode.OneWay, null, OnCommandParameterPropertyChanged);

		/// <summary>
		/// Identifies the Padding property. This property can be used to set padding to the sides of ButtonBase.
		/// </summary>
		/// <remarks>This <see cref="BindableProperty"/> is read-only.</remarks>
		public static readonly BindableProperty PaddingProperty =
			BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(ButtonBase), DeviceInfo.Platform == DevicePlatform.Android ? new Thickness(2) : new Thickness(0), BindingMode.Default, null, OnPaddingPropertyChanged);

		/// <summary>
		/// Identifies the FontFamily property. This property can be used to change the font family of the text in ButtonBase.
		/// </summary>
		/// <remarks>This <see cref="BindableProperty"/> is read-only.</remarks>
		public static readonly BindableProperty FontFamilyProperty = FontElement.FontFamilyProperty;

		/// <summary>
		/// Identifies the FontAttributes property. This property can be used to change the font of text to either bold or italic.
		/// </summary>
		/// <remarks>This <see cref="BindableProperty"/> is read-only.</remarks>
		public static readonly BindableProperty FontAttributesProperty = FontElement.FontAttributesProperty;

		/// <summary>
		/// Identifies the EnableRippleEffect property. This property can be used to enable ripple effect of ButtonBase.
		/// </summary>
		/// <remarks>This <see cref="BindableProperty"/> is read-only.</remarks>
		public static readonly BindableProperty EnableRippleEffectProperty =
			 BindableProperty.Create(nameof(EnableRippleEffect), typeof(bool), typeof(ButtonBase), true, BindingMode.Default, null, OnEnableRippleEffectPropertyChanged);

		/// <summary>
		/// Identifies the IsCheckable property. This property can be used to change the state of the ButtonBase.
		/// </summary>
		/// <remarks>This <see cref="BindableProperty"/> is read-only.</remarks>
		internal static readonly BindableProperty IsCheckableProperty =
			BindableProperty.Create(nameof(IsCheckable), typeof(bool), typeof(ButtonBase), false, BindingMode.Default, null, OnCheckPropertyChanged);

		/// <summary>
		/// Identifies the IsChecked property. It indicates whether the ButtonBase is in the default state . 
		/// </summary>
		/// <remarks>This <see cref="BindableProperty"/> is read-only.</remarks>
		internal static readonly BindableProperty IsCheckedProperty =
			BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(ButtonBase), false, BindingMode.TwoWay, null, OnCheckPropertyChanged);

		#endregion

		#region Fields

		private bool isItemTemplate = false;

		private bool isFontIconText = false;

		internal bool isRTL;

		internal bool isImageIconUpdated;

		/// <summary>
		/// The color of the disabled background.
		/// </summary>
		internal readonly Color disabledBackgroundColor = Color.FromRgb(255, 251, 254);

		/// <summary>
		/// The color of the disabled border.
		/// </summary>
		internal readonly Color disabledBorderColor = Color.FromRgba(28, 27, 31, 30);

		/// <summary>
		/// The color of the disabled text.
		/// </summary>
		internal readonly Color disabledTextColor = Color.FromRgba(28, 27, 31, 97);

		/// <summary>
		/// The color of the disabled pressed background.
		/// </summary>
		internal readonly Color disabledPressedBackgroundColor = new Color(209, 209, 209);

		/// <summary>
		/// The color of the disabled pressed background.
		/// </summary>
		internal readonly Color disabledPressedTextColor = new Color(148, 148, 148);

		internal Grid? imageViewGrid = new Grid();

		private RectF closeButtonRippleRectF = new RectF();

		internal RectF backgroudRectF = new RectF();

		internal TextStyle textStyle = new TextStyle();

		private Color textColor = Color.FromArgb("#1C1B1F");

		private Brush backgroundColor = Colors.Transparent;

		internal float leftPadding = 12f;

		internal float rightPadding = 12f;

		internal float leftIconPadding = 8f;

		internal float rightIconPadding = 8f;

		internal float textAreaPadding = 4f;

		internal double textHeightPadding = 13d;

		internal float textAlignmentPadding = 1.15f;

		internal float textSelectionPadding = 0.25f;

		internal float normalTextPadding = 0.5f;

		internal float textSizePadding = 10f;

#if ANDROID || MACCATALYST || IOS
        internal double textPadding = 8d;
#endif

		private readonly int defaultCloseButtonWidth = 18;

		internal bool filterType;

		/// <summary>
		/// The background image view.
		/// </summary>
		internal Image backgroundImageView = new Image();

		internal Grid backgroundImageGrid = new Grid();

		internal RectF textRectF = new RectF();

		internal EffectsRenderer? effectsRenderer;

		internal Color background = Colors.Transparent;

		private Color highlightColor = Color.FromRgba(73, 69, 78, 30);

		private Color borderColor = Color.FromArgb("#79747E");

		private int textSizeWidthPadding = 4;

		private TextAlignment horizontalTextAlignment;

		#endregion

		#region Constructor

		/// It represents single ButtonBase.
		/// +-0 or 18-+--0 or 24-+---------star----------+---0 or 18----+CORNERRADIUS
		/// |         |          |                       |              |         
		/// 5         |          |      PADDING          |              |         
		/// |         |          |                       |              |        
		/// |---------|----------|-----------------------|--------------|  HEIGHT = Default ButtonBase height (or) ItemHeight  
		/// |         |          |                       |              |          
		/// |INDICATOR|  ICON    |    ButtonBase TEXT    | CLOSEBUTTON  | 
		/// |         |          |                       |              |        
		/// |---------|----------|-----------------------|--------------+   
		/// |         |          |                       |              |           
		/// |         |          |      PADDING          |              |           
		/// +---------+----------+-----------------------+--------------+CORNERRADIUS   
		/// <summary>
		/// Initializes a new instance of the <see cref="ButtonBase"/> class.
		/// </summary>
		public ButtonBase()
		{
			InitializeElements();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ButtonBase"/> class.
		/// </summary>
		/// <param name="isCreatedInternally">If set to <c>true</c> is created internally.</param>
		internal ButtonBase(bool isCreatedInternally)
		{
			InitializeElements();
			this.IsCreatedInternally = isCreatedInternally;
		}

		#endregion

		#region events

		/// <summary>
		/// It represents the Clicked event handler. This clicked event is hooked when clicking the ButtonBase control.
		/// </summary>
		public event EventHandler<EventArgs>? Clicked;

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the value of corner radius.This property can be used to customize the corners of ButtonBase control.
		/// </summary>
		/// <value>Specifies the corner radius.The default value is cornerradius(8).</value>
		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}

		/// <summary>
		/// Gets or sets the value of BorderThickness.This property can be used to give border thickness to ButtonBase control
		/// </summary>
		/// <value>Specifies the stroke thickness.The default value is 1f.</value>
		public double StrokeThickness
		{
			get { return (double)GetValue(StrokeThicknessProperty); }
			set { SetValue(StrokeThicknessProperty, value); }
		}

		/// <summary>
		///  Gets or sets the value of stroke.This property can be used to give border Color to ButtonBase control.
		/// </summary>
		/// <value>Specifies the stroke.The default value is Color.FromArgb("#79747E").</value>
		public Brush Stroke
		{
			get { return (Brush)GetValue(StrokeProperty); }
			set { SetValue(StrokeProperty, value); }
		}

		/// <summary>
		///  Gets or sets the value of BackgroundColor.This property can be used to give Background Color to the ButtonBase control.
		/// </summary>
		/// <value>Specifies the background color.The default value is null .</value>
		public new Brush? Background
		{
			get { return (Brush)GetValue(BackgroundProperty); }
			set { SetValue(BackgroundProperty, value); }
		}

		/// <summary>
		/// Gets or sets the value of Text.This property can be used to give Text to the ButtonBase control.
		/// </summary>
		/// <value>Specifies the text.The default value is string.Empty.</value>
		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		/// <summary>
		/// Gets or sets the value of Text Color.This property can be used to give Text Color to the text in Buttonbase control.
		/// </summary>
		/// <value>Specifies the text color.The default value is Color.FromArgb("#1C1B1F").</value>
		public Color TextColor
		{
			get { return (Color)GetValue(TextColorProperty); }
			set { SetValue(TextColorProperty, value); }
		}

		/// <summary>
		///  Gets or sets the value of FontSize.This property can be used to give FontSize to the Text in ButtonBase control.
		/// </summary>
		/// <value>Specifies the font size.The default value is 14d.</value>
		[System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
		public double FontSize
		{
			get { return (double)GetValue(FontSizeProperty); }
			set { SetValue(FontSizeProperty, value); }
		}

		/// <summary>
		/// Enables automatic font size adjustment based on device settings.
		/// </summary>
		public bool FontAutoScalingEnabled
		{
			get { return (bool)this.GetValue(FontAutoScalingEnabledProperty); }
			set { this.SetValue(FontAutoScalingEnabledProperty, value); }
		}

		/// <summary>
		/// Gets or sets the value of HorizontalTextAlignment.This property can be used to give HorizontalTextAlignment to the Text in ButtonBase control.
		/// </summary>
		/// <value>Specifies the text alignment.The default value is <see cref="TextAlignment.Center"/>.</value>
		public TextAlignment HorizontalTextAlignment
		{
			get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
			set { SetValue(HorizontalTextAlignmentProperty, value); }
		}

		/// <summary>
		/// Gets or sets the value of VerticalTextAlignment.This property can be used to give VerticalTextAlignment to the Text in ButtonBase control.
		/// </summary>
		/// <value>Specifies the text alignment.The default value is <see cref="TextAlignment.Center"/>.</value>
		public TextAlignment VerticalTextAlignment
		{
			get { return (TextAlignment)GetValue(VerticalTextAlignmentProperty); }
			set { SetValue(VerticalTextAlignmentProperty, value); }
		}

		/// <summary>
		/// Gets or sets a value of the ImageSoure. This property can be used to set the source to an image. 
		/// </summary>
		/// <value>Specifies the image source.The default value is null.</value>
		public ImageSource ImageSource
		{
			get { return (ImageSource)GetValue(ImageSourceProperty); }
			set { SetValue(ImageSourceProperty, value); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the image icon of SfButton is visible or not. The icon is in visible state when this property is set to true.
		/// </summary>
		/// <value>
		/// Specifies the show icon property.The default value is false.
		/// </value>
		public bool ShowIcon
		{
			get { return (bool)GetValue(ShowIconProperty); }
			set { SetValue(ShowIconProperty, value); }
		}

		/// <summary>
		/// Gets or sets a value for the Image width  
		/// </summary>
		/// <value>
		/// Specifies the image width.The default value is 18.
		/// </value>
		public double ImageSize
		{
			get { return (double)GetValue(ImageSizeProperty); }
			set { SetValue(ImageSizeProperty, value); }
		}

		/// <summary>
		/// Gets or sets the ImageAlignment for the Image. 
		/// </summary>
		/// <value>
		/// Specifies the image alignment.The default value is <see cref="Alignment.Start"/>.
		/// </value>
		public Alignment ImageAlignment
		{
			get { return (Alignment)GetValue(ImageAlignmentProperty); }
			set { SetValue(ImageAlignmentProperty, value); }
		}

		/// <summary>
		/// Gets or sets the value of the BackgroundImageSource. This property can be used to set an image as the background of ButtonBase.
		/// </summary>
		/// <value>
		/// Specifies the background image source.The default value is null.
		/// </value>
		public ImageSource BackgroundImageSource
		{
			get { return (ImageSource)GetValue(BackgroundImageSourceProperty); }
			set { this.SetValue(BackgroundImageSourceProperty, value); }
		}

		/// <summary>
		/// Gets or sets the value of the Command. It invokes when the ButtonBase is activated. It is a bindable property. 
		/// </summary>
		/// <value>Specifies the command.</value>
		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { this.SetValue(CommandProperty, value); }
		}

		/// <summary>
		/// Gets or sets the value of the CommandParameter, which is a parameter to pass the Command property. This is a bindable property.
		/// </summary>
		/// <value>Specifies the command parameter.</value>
		public object CommandParameter
		{
			get { return (object)GetValue(CommandParameterProperty); }
			set { this.SetValue(CommandParameterProperty, value); }
		}

		/// <summary>
		/// Gets or sets the value of Padding. This property can be used to set padding to the sides of ButtonBase.
		/// </summary>
		/// <value>Specifies the padding.The default value is 2 for Android platform and 0 for other platform. </value>
		public new Thickness Padding
		{
			get { return (Thickness)GetValue(PaddingProperty); }
			set { this.SetValue(PaddingProperty, value); }
		}

		/// <summary>
		/// Gets or sets the value of the FontFamily. This property can be used to change the font family of the text in ButtonBase.
		/// </summary>
		/// <value>Specifies the font family.The default value is string.empty. </value>
		public string FontFamily
		{
			get { return (string)GetValue(FontFamilyProperty); }
			set { this.SetValue(FontFamilyProperty, value); }
		}

		/// <summary>
		/// Gets or sets the value of FontAttributes. This property can be used to change the font of text in either bold or italic.
		/// </summary>
		/// <value>Specifies the font attributes.The default value is  <see cref="FontAttributes.None"/> </value>
		public FontAttributes FontAttributes
		{
			get { return (FontAttributes)GetValue(FontAttributesProperty); }
			set { this.SetValue(FontAttributesProperty, value); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the ripple effect of ButtonBase is enabled or not.
		/// </summary>
		/// <value> Specifies the Enable ripple effect property. The default value is true.</value>
		/// <remarks></remarks>
		public bool EnableRippleEffect
		{
			get { return (bool)GetValue(EnableRippleEffectProperty); }
			set { this.SetValue(EnableRippleEffectProperty, value); }
		}

		internal void SetRTL()
		{
			if (((this as IVisualElementController).EffectiveFlowDirection & EffectiveFlowDirection.RightToLeft) == EffectiveFlowDirection.RightToLeft)
			{

				this.isRTL = true;
				if (this.effectsRenderer != null)
					effectsRenderer.IsRTL = this.isRTL;
			}
			else
			{
				this.isRTL = false;
				if (this.effectsRenderer != null)
					effectsRenderer.IsRTL = this.isRTL;
			}
			this.InvalidateDrawable();
		}


		#endregion

		#region Internal Properties

		/// <summary>
		/// Close button color update property.
		/// </summary>
		internal bool IsItemTemplate
		{
			get { return isItemTemplate; }
			set { isItemTemplate = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the ButtonBase is in the default state or not. This property can be used to change the state of the ButtonBase.
		/// </summary>
		///  <value>
		/// Specifies the ischeckable property.The default value is false.
		/// </value>
		internal bool IsCheckable
		{
			get { return (bool)GetValue(IsCheckableProperty); }
			set { this.SetValue(IsCheckableProperty, value); }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the ButtonBase is checkable. It is used to check the state of the ButtonBase.
		/// </summary>
		///  <value>
		/// Specifies the ischecked property.The default value is false.
		/// </value>
		internal bool IsChecked
		{
			get { return (bool)GetValue(IsCheckedProperty); }
			set { this.SetValue(IsCheckedProperty, value); }
		}

		/// <summary>
		/// The image view.
		/// </summary>
		internal Image? ActualImageView { get; set; } = new Image();

		/// <summary>
		/// Gets or sets the value of highlight color.This property can be used to customize the highlight color of ButtonBase control
		/// </summary>
		/// <value>Specifies the highlight color.The default value is Color.FromRgba(73, 69, 78, 30).
		/// </value>
		internal Color HighlightColor
		{
			get { return highlightColor; }
			set { highlightColor = value; }
		}

		/// <summary>
		/// Measure the size of the Text.
		/// </summary>
		internal virtual Size TextSize
		{
			get
			{
				var size = Text.Measure(this);
#if ANDROID
                size.Width = size.Width * 1.03 + textSizeWidthPadding;
#else
				size.Width = size.Width + textSizeWidthPadding;
#endif
				size.Height = FontSize;
				return size;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Syncfusion.Maui.Toolkit.ButtonBase"/> is created internally.
		/// </summary>
		/// <value><c>true</c> if is created internally; otherwise, <c>false</c>.</value>
		internal bool IsCreatedInternally
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or set the value for text color.
		/// </summary>
		internal Color BaseTextColor
		{
			get { return textColor; }
			set { textColor = value; }
		}

		internal Brush? BaseBackgroundColor
		{
			get { return backgroundColor; }
			set
			{
				if (value != null)
				{
					backgroundColor = value;
					base.Background = backgroundColor;
				}
			}
		}

		/// <summary>
		/// Gets or sets a value for border color value.
		/// </summary>
		internal Color BaseStrokeColor
		{
			get { return borderColor; }
			set { borderColor = value; }
		}

		/// <summary>
		/// Gets or sets the data context.
		/// </summary>
		/// <value>The data context.</value>
		internal object? DataContext
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Syncfusion.Maui.Toolkit.ButtonBase"/> is selected.
		/// </summary>
		/// <value><c>true</c> if is selected; otherwise, <c>false</c>.</value>
		internal bool IsSelected
		{
			get;
			set;
		}

		internal bool IsEditorControl { get; set; }

		#endregion

		#region Public Methods

		/// <summary>
		/// Releases all resources used by the <see cref="ButtonBase"/> object. Using this method, all the dead objects are removed.
		/// </summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}


		#endregion

		#region Internal Methods

		/// <summary>
		/// This Method is used for the RippleEffects rendering in the ButtonBase control
		/// </summary>
		internal void UpdateRippleEffectsRenderer()
		{
			if (IsEnabled)
			{
				if (EnableRippleEffect)
				{
					if (this.effectsRenderer != null)
					{
						this.effectsRenderer.RippleBoundsCollection.Clear();
						this.effectsRenderer.RippleBoundsCollection.Add(backgroudRectF);

					}
				}
				else
				{
					this.effectsRenderer?.RippleBoundsCollection.Clear();
				}
			}

		}

		/// <summary>
		/// Method performs initialization for all the views.
		/// </summary>
		internal void InitializeElements()
		{
			this.AddTouchListener(this);
#if WINDOWS
            this.DrawingOrder = DrawingOrder.AboveContentWithTouch;
#else
			this.DrawingOrder = DrawingOrder.AboveContent;
#endif
			base.Background = this.Background;
			this.effectsRenderer = new EffectsRenderer(this);
			effectsRenderer.RippleAnimationDuration = 150;
			this.AddGestureListener(this);
		}

		Microsoft.Maui.Font ITextElement.Font => (Microsoft.Maui.Font)GetValue(FontElement.FontProperty);

		void ITextElement.OnFontFamilyChanged(string oldValue, string newValue)
		{
			this.InvalidateMeasure();
			this.InvalidateDrawable();
		}

		void ITextElement.OnFontSizeChanged(double oldValue, double newValue)
		{
			this.InvalidateMeasure();
			this.InvalidateDrawable();
		}

		double ITextElement.FontSizeDefaultValueCreator()
		{
			return 14d;
		}

		void ITextElement.OnFontAttributesChanged(FontAttributes oldValue, FontAttributes newValue)
		{
			this.InvalidateMeasure();
			this.InvalidateDrawable();
		}

		void ITextElement.OnFontChanged(Microsoft.Maui.Font oldValue, Microsoft.Maui.Font newValue)
		{
			this.InvalidateMeasure();
			this.InvalidateDrawable();
		}

		/// <summary>
		/// Invoked when the <see cref="FontAutoScalingEnabledProperty"/> changed.
		/// </summary>
		/// <param name="oldValue"></param>
		/// <param name="newValue"></param>
		void ITextElement.OnFontAutoScalingEnabledChanged(bool oldValue, bool newValue)
		{
			this.InvalidateDrawable();
		}

		#endregion

		#region Internal Methods
		internal void RaiseClicked(EventArgs args)
		{
			if (this.IsEnabled)
			{
				this.Command?.Execute(CommandParameter);
				this.Clicked?.Invoke(this, args);
			}
		}

		/// <summary>
		/// Disposing all the resources used by the <see cref="Syncfusion.Maui.Toolkit.ButtonBase"/> object. 
		/// </summary>
		/// <param name="disposing">If set to <c>true</c> disposing.</param>
		/// <exclude/>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.DataContext != null)
				{
					this.DataContext = null;
				}
			}
		}

		#endregion

		#region Override Methods

		/// <summary>
		/// Measure content method.
		/// </summary>
		/// <exclude/>
		protected override Size MeasureContent(double widthConstraint, double heightConstraint)
		{
			base.MeasureContent(widthConstraint, heightConstraint);
			var width = widthConstraint;
			var height = heightConstraint;

			textRectF.Width = Math.Abs((float)this.Width - (float)this.ImageSize - 2 * leftIconPadding - 2 * rightIconPadding - defaultCloseButtonWidth);

			if (width == double.PositiveInfinity || width < 0 || IsCreatedInternally)
			{
				width = TextSize.Width + leftPadding + rightPadding + this.Padding.Right + this.Padding.Left;
			}

			if (height == double.PositiveInfinity || height < 0 || IsCreatedInternally)
			{

				if (ImageAlignment == Alignment.Top || ImageAlignment == Alignment.Bottom)
				{
					height = ShowIcon ? 2 * this.ImageSize + TextSize.Height + this.Padding.Top + this.Padding.Bottom : TextSize.Height + textHeightPadding + this.Padding.Top + this.Padding.Bottom;
				}

				else
					height = ShowIcon ? FontSize + this.ImageSize + this.Padding.Top + this.Padding.Bottom : TextSize.Height + textHeightPadding + this.Padding.Top + this.Padding.Bottom;
			}
			return new Size(width, height);
		}

		/// <summary>
		/// To change the visual state of the ButtonBase control.
		/// </summary>
		/// <exclude/>
		protected override void ChangeVisualState()
		{
			base.ChangeVisualState();
			if (IsEnabled)
			{
				Color default1 = Color.FromArgb("FFFBFE");
				Color default2 = Color.FromArgb("#E8DEF8");

				this.BaseTextColor = this.TextColor;
				if (this.Stroke != null)
				{
					this.BaseStrokeColor = ((SolidColorBrush)this.Stroke).Color;
				}
				this.StrokeThickness = this.StrokeThickness;
				if (this.Background == null || this.Background.Equals(default2))
				{
					this.BaseBackgroundColor = default1;
				}
				else
				{
					this.BaseBackgroundColor = this.Background;
				}
			}
			else
			{
				if (!VisualStateManager.HasVisualStateGroups(this) && !Application.Current!.Resources.TryGetValue("SfButtonTheme", out var theme))
				{
					this.BaseBackgroundColor = Color.FromRgba(28, 27, 31, 30);
				}
				else
				{
					this.BaseBackgroundColor = this.Background;
				}
				this.BaseStrokeColor = this.disabledBorderColor;
				this.BaseTextColor = this.disabledTextColor;
			}
			this.InvalidateDrawable();
		}

		/// <exclude/>
		protected override void OnPropertyChanged(string propertyName)
		{
			if (propertyName == "FlowDirection")
			{
				this.SetRTL();
			}
			base.OnPropertyChanged(propertyName);
		}

		#endregion

		#region PropertyChanged Methods

		/// <summary>
		/// Property changed method for corner radius property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of CornerRadius property.</param>
		/// <param name="newValue">The new value of CornerRadius property </param>
		private static void OnCornerRadiusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.InvalidateMeasure();
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		/// <summary>
		/// Property changed method for stroke thickness property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of StrokeThickness property.</param>
		/// <param name="newValue">The new value of StrokeThickness property.</param>
		private static void OnStrokeThicknessPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.InvalidateMeasure();
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		/// <summary>
		/// Property changed method for border color property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of border color property.</param>
		/// <param name="newValue">The new value of border color property. </param>
		private static void OnStrokePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.UpdateStroke();
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		/// <summary>
		/// Property changed method for background color property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of background property.</param>
		/// <param name="newValue">The new value of background property.</param>
		private static void OnBackgroundPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.UpdateBackground();
			(bindable as ButtonBase)?.InvalidateDrawable();

		}

		/// <summary>
		/// Property changed method for text property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of text property.</param>
		/// <param name="newValue">The new value of text property.</param>
		private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is ButtonBase buttonbase)
			{
				if (newValue is string text)
				{
					buttonbase.ContainsUnicodeCharacter(text);
				}
				buttonbase.InvalidateMeasure();
				buttonbase.InvalidateDrawable();
			}
		}

		/// <summary>
		/// Property changed method for text color property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of text color property.</param>
		/// <param name="newValue">The new value of text color property.</param>
		private static void OnTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.UpdateTextColor();
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		/// <summary>
		/// Property changed method for font size property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of font size property.</param>
		/// <param name="newValue">The new value of font size property </param>
		private static void OnFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.BaseGroupHeight();
			(bindable as ButtonBase)?.InvalidateMeasure();
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		/// <summary>
		/// Property changed method for HorizantalAlignment property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of HorizantalAlignment property.</param>
		/// <param name="newValue">The new value of HorizantalAlignment property.</param>
		private static void OnHorizantalAlignmentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		/// <summary>
		/// Property changed method for Vertical Alignment property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of VerticalAlignment property.</param>
		/// <param name="newValue">The new value of VerticalAlignment property.</param>
		private static void OnVerticalTextAlignmentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		/// <summary>
		/// Property changed method for image source property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue"> The old value of image source property.</param>
		/// <param name="newValue">The new value of image source property. </param>
		private static void OnImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.OnImageSourcePropertyChanged();
			(bindable as ButtonBase)?.InvalidateMeasure();
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		/// <summary>
		/// Property changed method for image alignment property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue"> The old value of image alignment property.</param>
		/// <param name="newValue">The new value of image alignment property. </param>
		private static void OnImageAlignmentChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.InvalidateMeasure();
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		/// <summary>
		/// Property changed method for image width property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of image width property.</param>
		/// <param name="newValue">The new value of image width property.</param>
		private static void OnImageSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var buttonBase = bindable as ButtonBase;
			if (buttonBase != null && buttonBase.ShowIcon)
			{
				buttonBase.OnImageSourcePropertyChanged();
				buttonBase.BaseGroupHeight();
				buttonBase.InvalidateMeasure();
				buttonBase.InvalidateDrawable();
			}

		}

		/// <summary>
		/// Property changed method for background image property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event</param>
		/// <param name="oldValue">The old value of background image property.></param>
		/// <param name="newValue">The new value of background image property. </param>
		private static void OnBackgroundImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.InitializeBackgroundImage();
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		/// <summary>
		/// Property changed method for enable ripple effect property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of enable ripple effect property.</param>
		/// <param name="newValue">The new value of enable ripple effect property.</param>
		private static void OnEnableRippleEffectPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.InvalidateDrawable();
			(bindable as ButtonBase)?.UpdateRippleEffectsRenderer();
			(bindable as ButtonBase)?.UpdateCloseButtonRippleEffectsRenderer();
		}

		/// <summary>
		/// Property changed method for checkable property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of check property.</param>
		/// <param name="newValue">The new value of check property.</param>
		private static void OnCheckPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.CheckPropertyChanged();
		}

		/// <summary>
		/// Property changed method for command property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of command property.</param>
		/// <param name="newValue">The new value of command property.</param>
		private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var buttonBase = bindable as ButtonBase;
			if (oldValue != null)
			{
				buttonBase?.UnhookEvent((ICommand)oldValue);
			}

			buttonBase?.OnCommandPropertyChanged();
		}

		/// <summary>
		/// Property changed method for command parameter property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of command parameter property.</param>
		/// <param name="newValue">The new value of command parameter property.</param>
		private static void OnCommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.OnCommandParameterPropertyChanged();
		}

		/// <summary>
		/// Property changed method for padding property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of padding property.</param>
		/// <param name="newValue">The new value of padding property.</param>
		private static void OnPaddingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.InvalidateMeasure();
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		/// <summary>
		/// Property changed method for font family property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of font family property.</param>
		/// <param name="newValue">The new value of font family property.</param>

		private static void OnFontFamilyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.InvalidateMeasure();
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		/// <summary>
		/// Property changed method for font attributes property.
		/// </summary>
		/// <param name="bindable">The original source of property changed event.</param>
		/// <param name="oldValue">The old value of font attributes property.</param>
		/// <param name="newValue">The new value of font attributes property.</param>
		private static void OnFontAttributesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			(bindable as ButtonBase)?.InvalidateMeasure();
			(bindable as ButtonBase)?.InvalidateDrawable();
		}

		#endregion

		#region Private Methods

		private void OnImageSourcePropertyChanged()
		{
			if (this.ShowIcon && this.ImageSource != null && !this.IsItemTemplate)
			{
				this.isImageIconUpdated = true;

				if (this.ImageSource != null && this.ActualImageView != null)
					this.ActualImageView.Source = this.ImageSource;

				if (this.imageViewGrid != null)
				{
					this.imageViewGrid.Children.Clear();
					AutomationProperties.SetIsInAccessibleTree(ActualImageView, false);
					this.imageViewGrid.Add(ActualImageView);
					this.imageViewGrid.InputTransparent = true;
				}

			}
			else
			{

				if (this.imageViewGrid != null)
				{
					if (this.imageViewGrid.Parent != null)
					{
						this.imageViewGrid.Children.Clear();
						this.Remove(this.imageViewGrid);
					}
				}

			}
		}

		private void BaseGroupHeight()
		{
			if (IsCreatedInternally)
			{
				this.HeightRequest = ShowIcon ? FontSize + this.ImageSize + this.Padding.Top + this.Padding.Bottom : TextSize.Height + textHeightPadding + this.Padding.Top + this.Padding.Bottom;
			}
		}

		private void UpdateTextColor()
		{
			this.BaseTextColor = this.TextColor;
		}

		private void UpdateBackground()
		{
			base.Background = this.Background;
		}

		private void UpdateStroke()
		{
			if (this.Stroke != null)
			{
				this.BaseStrokeColor = ((SolidColorBrush)this.Stroke).Color;
			}
		}

		internal void UpdateBaseClip()
		{
			var x = 0;
			var y = 0;
#if WINDOWS && NET8_0
            if (!(Parent is Frame))
                   this.Clip = new RoundRectangleGeometry(this.CornerRadius, new Rect(x, y, this.Width, this.Height));
#else
			this.Clip = new RoundRectangleGeometry(this.CornerRadius, new Rect(x, y, this.Width, this.Height));
#endif
		}

		private void InitializeBackgroundImage()
		{
			if (this.Children.Contains(this.backgroundImageGrid))
			{
				this.Children.Remove(this.backgroundImageGrid);
			}

			if (this.BackgroundImageSource != null)
			{
				this.backgroundImageGrid.Children.Clear();
				this.backgroundImageView.Aspect = Aspect.AspectFill;
				this.backgroundImageView.Source = this.BackgroundImageSource;
				this.backgroundImageGrid.Add(this.backgroundImageView);
				this.Children.Insert(0, this.backgroundImageGrid);
			}

		}

		/// <summary>
		/// The command property changed.
		/// </summary>
		private void OnCommandPropertyChanged()
		{
			if (this.Command != null)
			{
				this.Command.CanExecuteChanged -= this.OnCommandCanExecuteChanged;
				this.Command.CanExecuteChanged += this.OnCommandCanExecuteChanged;
				if (!this.Command.CanExecute(this.CommandParameter))
				{
					this.IsEnabled = false;
				}
			}
		}

		/// <summary>
		/// Unwire CanExecuteChanged event.
		/// </summary>
		/// <param name="command">Old Command.</param>
		private void UnhookEvent(ICommand command)
		{
			if (command != null)
			{
				command.CanExecuteChanged -= this.OnCommandCanExecuteChanged;
			}
		}

		/// <summary>
		/// Call the Commands can execute changed method.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event args.</param>
		private void OnCommandCanExecuteChanged(object? sender, EventArgs e)
		{
			ICommand command = this.Command;
			if (command != null)
			{
				this.IsEnabled = command.CanExecute(this.CommandParameter);
			}
		}

		/// <summary>
		/// Calls the CanExecute method when the property is changed.
		/// </summary>
		private void OnCommandParameterPropertyChanged()
		{
			this.OnCommandCanExecuteChanged(this, EventArgs.Empty);
		}

		internal void CheckPropertyChanged()
		{
			if (IsEnabled)
			{
				if (this.IsCheckable)
				{
					if (this.IsChecked)
					{
						this.TriggerChecked();
					}
					else
					{
						this.TriggerUnchecked();
					}
				}
				else
				{
					base.Background = this.Background;
					this.Stroke = this.Stroke;
					this.TextColor = this.TextColor;
					VisualStateManager.GoToState(this, "Normal");
				}
			}
			else
			{
				if (this.IsCheckable)
				{
					if (this.IsChecked)
					{
						this.TriggerChecked();
					}
					else
					{
						this.TriggerUnchecked();
					}
				}
				else
				{
					base.Background = this.disabledBackgroundColor;
					this.Stroke = this.disabledBorderColor;
					this.TextColor = this.disabledTextColor;
					VisualStateManager.GoToState(this, "Disabled");
				}
			}

		}
		private void TriggerChecked()
		{
			if (IsEnabled)
			{
				base.Background = Colors.Gray;
				VisualStateManager.GoToState(this, "Pressed");
			}
			else
			{
				base.Background = disabledPressedBackgroundColor;
				this.Stroke = this.disabledBorderColor;
				this.TextColor = this.disabledPressedTextColor;
				VisualStateManager.GoToState(this, "Disabled");
			}

		}
		private void TriggerUnchecked()
		{
			if (IsEnabled)
			{
				base.Background = this.Background;
				VisualStateManager.GoToState(this, "Normal");
			}
			else
			{
				base.Background = this.disabledBackgroundColor;
				this.Stroke = this.disabledBorderColor;
				this.TextColor = this.disabledTextColor;
				VisualStateManager.GoToState(this, "Disabled");
			}

		}

		private void UpdateCloseButtonRippleEffectsRenderer()
		{
			if (this.IsEnabled)
			{
				if (this.EnableRippleEffect)
				{

					if (this.effectsRenderer != null)
					{
						this.effectsRenderer.RippleBoundsCollection.Clear();
						this.effectsRenderer.RippleBoundsCollection.Add(closeButtonRippleRectF);

					}
				}
				else
				{
					this.effectsRenderer?.RippleBoundsCollection.Clear();
				}
			}
		}

		#endregion

		#region Draw Methods

		/// <summary>
		/// Draws the text content within the view on the provided canvas with the specified text style and alignment.
		/// </summary>
		/// <param name="canvas">The canvas on which the text will be drawn.</param>
		/// <param name="dirtyRect">The area to be updated on the canvas (dirty rectangle).</param>
		internal virtual void DrawText(ICanvas canvas, RectF dirtyRect)
		{
			UpdateTextBounds(dirtyRect, this.VerticalTextAlignment);
			canvas.CanvasSaveState();

			var trimmedText = isFontIconText ? this.Text : RequiredTextTrim(this.Text, this.textRectF.Width);

			if (textRectF.Width > 0 && textRectF.Height > 0)
			{
				GetHorizontalTextAlignment();
				canvas.DrawText(trimmedText, textRectF, (HorizontalAlignment)horizontalTextAlignment, (VerticalAlignment)this.VerticalTextAlignment, this);
			}

			canvas.CanvasRestoreState();
		}

		private void GetHorizontalTextAlignment()
		{
			if (HorizontalTextAlignment == TextAlignment.Start)
			{
				horizontalTextAlignment = isRTL ? TextAlignment.End : TextAlignment.Start;
			}
			else if (HorizontalTextAlignment == TextAlignment.End)
			{
				horizontalTextAlignment = isRTL ? TextAlignment.Start : TextAlignment.End;
			}
			else
			{
				horizontalTextAlignment = HorizontalTextAlignment;
			}
		}

		private bool ContainsUnicodeCharacter(string input)
		{
			const int MaxAnsiCode = 255;
			const int CyrillicStart = 1024;
			const int CyrillicEnd = 1279;

			return input.Any(c => c > MaxAnsiCode && (c < CyrillicStart || c > CyrillicEnd));
		}

		private string RequiredTextTrim(string text, double availableWidth)
		{
			double value = 0;
			var trimmedText = text;
			var textSize = text.Measure(this);
			var Rightpadding = 4;
			var ellipsisWidth = ("...").Measure(this).Width + Rightpadding;

			do
			{
				if (textSize.Width > availableWidth && text.Length > 0)
				{
					text = text.Substring(0, text.Length - 1);
					value = text.Measure(this).Width;
				}
				else
				{
					continue;
				}
			}
			while (availableWidth > ellipsisWidth && value > availableWidth - ellipsisWidth && text.Length > 0);

			if (trimmedText != text)
			{
				trimmedText = text + "...";
			}
			return trimmedText;
		}

		/// <summary>
		/// Draws an outline on the provided canvas for the current view.
		/// </summary>
		/// <param name="canvas">The canvas on which the outline will be drawn.</param>
		/// <param name="dirtyRect">The area to be updated on the canvas (dirty rectangle).</param>
		/// <exclude/>
		protected virtual void DrawOutline(ICanvas canvas, RectF dirtyRect)
		{
			if (this.Stroke != null && this.StrokeThickness > 0)
			{
				var x = dirtyRect.X;
				var y = dirtyRect.Y;
				var width = (float)(this.Width);
				var height = dirtyRect.Height;

				var topLeftRadius = (float)CornerRadius.TopLeft;
				var topRightRadius = (float)CornerRadius.TopRight;
				var bottomLeftRadius = (float)CornerRadius.BottomLeft;
				var bottomRightRadius = (float)CornerRadius.BottomRight;

				canvas.CanvasSaveState();
				canvas.StrokeColor = this.BaseStrokeColor;
				canvas.StrokeSize = (float)this.StrokeThickness;
				if (!this.IsSelected)
				{
					canvas.DrawRoundedRectangle(x, y, width, height, topLeftRadius, topRightRadius, bottomLeftRadius, bottomRightRadius);
				}
				canvas.CanvasRestoreState();
			}
		}

		/// <summary>
		/// Updates the background rectangle's dimensions based on the provided dirty rectangle and stroke thickness.
		/// </summary>
		/// <param name="dirtyRect">The area to be updated on the canvas (dirty rectangle).</param>
		internal void UpdateBackgroundRectF(RectF dirtyRect)
		{
			backgroudRectF.X = dirtyRect.X + (float)this.StrokeThickness / 2;
			backgroudRectF.Y = dirtyRect.Y + (float)this.StrokeThickness / 2;
			backgroudRectF.Width = dirtyRect.Width - (float)this.StrokeThickness;
			backgroudRectF.Height = dirtyRect.Height - (float)this.StrokeThickness;
		}

		#endregion

		#region Interface Implementation

		/// <summary>
		/// Touch action method for ButtonBase.
		/// </summary>
		/// <param name="e">The <see cref="PointerEventArgs"/> that contains the event data.</param>
		public virtual void OnTouch(PointerEventArgs e)
		{
			if (e.Action == PointerActions.Pressed)
			{
				if (background != HighlightColor && !this.IsEditorControl)
				{
					background = HighlightColor;
					this.InvalidateDrawable();
				}
				if (IsCheckable)
				{
					IsChecked = !IsChecked;
					this.CheckPropertyChanged();

				}
				UpdateRippleEffectsRenderer();
				VisualStateManager.GoToState(this, "Pressed");

			}

			if (e.Action == PointerActions.Released)
			{
				if (!background.Equals(Colors.Transparent))
				{
					background = Colors.Transparent;
					this.InvalidateDrawable();
				}

				SfChip? chip = null;
				if (this.Children.Count == 0 && this.Children != null && this.Children is SfChip)
				{
					chip = this.Children as SfChip;
				}

				if (chip != null && chip is SfChip)
				{
					if (!chip.IsTouchInsideCloseButton(e.TouchPoint) && IsEnabled)
					{
						RaiseClicked(EventArgs.Empty);
					}
				}
				else
				{
					RaiseClicked(EventArgs.Empty);
				}
#if ANDROID || IOS
                VisualStateManager.GoToState(this, "Normal");
#endif
			}

#if ANDROID
            if (e.Action == PointerActions.Cancelled)
            {
                if (!background.Equals(Colors.Transparent))
                {
                    background = Colors.Transparent;
                    this.InvalidateDrawable();
                }
            }
#endif

			if (e.Action == PointerActions.Moved)
			{
#if ANDROID
                if (!background.Equals(Colors.Transparent))
                {
                    background = Colors.Transparent;
                    this.InvalidateDrawable();
                }
#endif

#if WINDOWS || MACCATALYST

                    if (this.Background != null && !this.IsEditorControl)
                    {
                        if (this.Background as SolidColorBrush != null && ((SolidColorBrush)this.Background).Color.Equals (Colors.Transparent))
                        {
                            if (!background.Equals(Colors.Gray.MultiplyAlpha(0.1f)))
                            {
                                background = Colors.Gray.MultiplyAlpha(0.1f);
                                this.InvalidateDrawable();
                            }
                        }
                        else
                        {
                            if(this.Background is SolidColorBrush background)
                            {
                                base.Background = new SolidColorBrush(Color.FromRgba(background.Color.Red, background.Color.Green, background.Color.Blue, 0.8));
                            }    
                        }
                    }
                    VisualStateManager.GoToState(this, "Hovered");

                
#endif


			}

			if (e.Action == PointerActions.Exited)
			{
				base.Background = this.Background;
				background = Colors.Transparent;
				this.InvalidateDrawable();
#if MACCATALYST || IOS
                if (this.Background != null)
                    VisualStateManager.GoToState(this, "Normal");
#else
				VisualStateManager.GoToState(this, "Normal");
#endif
			}

		}

		void ITapGestureListener.OnTap(TapEventArgs e)
		{
			OnTapEvents();
		}

#if WINDOWS || MACCATALYST || IOS

        // Both Button and its Parent Commands are executed simultaneously. 
        // So, we are handling the gesture listener here.
        bool IGestureListener.IsTouchHandled => !this.InputTransparent;
#endif

		#endregion

		#region Virtual Methods

		/// <summary>
		/// Updates the bounds of the text within the view based on the provided dirty rectangle and vertical text alignment.
		/// </summary>
		/// <param name="dirtyRect">The area to be updated on the canvas (dirty rectangle).</param>
		/// <param name="verticalTextAlignment">The vertical alignment of the text within the view.</param>
		internal virtual void UpdateTextBounds(RectF dirtyRect, TextAlignment verticalTextAlignment)
		{
			if (this.ShowIcon)
			{
				if (this.ImageAlignment == Alignment.Default || this.ImageAlignment == Alignment.Start || this.ImageAlignment == Alignment.Left || this.ImageAlignment == Alignment.Top || this.ImageAlignment == Alignment.Bottom)
				{
					textRectF.X = this.isRTL ? (float)this.Padding.Left - (float)this.Padding.Right + leftIconPadding : (float)this.Padding.Left - (float)this.Padding.Right + (float)this.ImageSize + leftIconPadding + rightIconPadding;
					textRectF.Y = (float)this.Padding.Top - (float)this.Padding.Bottom - dirtyRect.Y - normalTextPadding;
					textRectF.Width = Math.Abs((float)this.Width - (float)this.ImageSize - leftIconPadding - rightPadding);
					textRectF.Height = Math.Abs((float)this.Height);
				}
				else if (this.ImageAlignment == Alignment.End || this.ImageAlignment == Alignment.Right)
				{
					textRectF.X = this.isRTL ? (float)this.Padding.Left - (float)this.Padding.Right + (float)this.ImageSize + leftIconPadding + rightIconPadding : (float)this.Padding.Left - (float)this.Padding.Right + leftIconPadding;
					textRectF.Y = (float)this.Padding.Top - (float)this.Padding.Bottom - dirtyRect.Y - textAlignmentPadding + (float)this.StrokeThickness / 2;
					textRectF.Width = Math.Abs((float)this.Width - (float)this.ImageSize - rightIconPadding - rightPadding);
					textRectF.Height = Math.Abs((float)this.Height - (float)StrokeThickness);
				}
			}
			else
			{
				textRectF.X = (float)this.Padding.Left - (float)this.Padding.Right + leftPadding;
				textRectF.Y = (float)(this.Padding.Top - this.Padding.Bottom - dirtyRect.Y - normalTextPadding);
				textRectF.Width = Math.Abs((float)(this.Width - leftPadding - rightPadding));
				textRectF.Height = (float)this.Height;
			}

#if ANDROID || MACCATALYST || IOS
                    if (VerticalTextAlignment == TextAlignment.End)
                    {
                        if ((this.Height - this.TextSize.Height) > 0)
                            textRectF.Y = (float)(this.Height - this.TextSize.Height - textPadding - this.Padding.Bottom);
                        else
                            textRectF.Y = (float)(this.Padding.Top - this.Padding.Bottom);
                    }
                    else
                    {
                        if (this.Padding.Top - (float)this.Padding.Bottom + this.Height > this.Height)
                        {
                            textRectF.Y = (float)(this.Height - this.Padding.Top - this.Padding.Bottom - this.TextSize.Height);

                        }
                        else
                        {
                            textRectF.Y = (float)this.Padding.Top - (float)this.Padding.Bottom + normalTextPadding;

                        }
                    }
                    textRectF.Height = Math.Abs((float)this.Height);
#endif
		}

		/// <summary>
		/// Drawing methods of ButtonBase control.
		/// </summary>
		/// <param name="canvas">The canvas.</param>
		/// <param name="dirtyRect">The rect</param>
		/// <exclude/>
		protected override void OnDraw(ICanvas canvas, RectF dirtyRect)
		{
			base.OnDraw(canvas, dirtyRect);
			canvas.Antialias = true;
			if (dirtyRect.Width > 0 && dirtyRect.Height > 0)
			{
				DrawOutline(canvas, dirtyRect);
				this.UpdateBaseClip();
				if (!IsItemTemplate)
				{
					DrawText(canvas, dirtyRect);

				}
			}
		}
		internal virtual void OnTapEvents() { }
		#endregion

	}
}
