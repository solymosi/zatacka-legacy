using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;
using System.Globalization;

namespace Zatacka.Unit
{
    class Text : Unit
    {
        /// <summary>
        /// Default font family to use when no font family is specified for a Text.
        /// </summary>
        static public FontFamily DefaultFontFamily { get; set; }

        /// <summary>
        /// Default font size to use when no font size is specified for a Text.
        /// </summary>
        static public double DefaultFontSize { get; set; }

        /// <summary>
        /// Default font weight to use when no font weight is specified for a Text.
        /// </summary>
        static public FontWeight DefaultFontWeight { get; set; }

        /// <summary>
        /// Default font style to use when no font style is specified for a Text.
        /// </summary>
        static public FontStyle DefaultFontStyle { get; set; }

        /// <summary>
        /// Default fill to use when no fill is specified for a Text.
        /// </summary>
        static public Brush DefaultFill { get; set; }

        /// <summary>
        /// Default background to use when no background is specified for a Text.
        /// </summary>
        static public Brush DefaultBackground { get; set; }

        /// <summary>
        /// Default text alignment to use when no text alignment is specified for a Text.
        /// </summary>
        static public TextAlignment DefaultTextAlignment { get; set; }

        /// <summary>
        /// Default line height to use when no line height is specified for a Text.
        /// </summary>
        static public double DefaultLineHeight { get; set; }

        /// <summary>
        /// Default overflow mode to use when no overflow mode is specified for a Text.
        /// </summary>
        static public TextTrimming DefaultOverflow { get; set; }

        /// <summary>
        /// Initializes the default parameters.
        /// </summary>
        static Text()
        {
            DefaultFontFamily = new FontFamily("Open Sans");
            DefaultFontSize = 20;
            DefaultFontWeight = FontWeights.Normal;
            DefaultFontStyle = FontStyles.Normal;
            DefaultFill = new SolidColorBrush(Colors.White);
            DefaultFill.Freeze();
            DefaultBackground = null;
            DefaultTextAlignment = TextAlignment.Left;
            DefaultLineHeight = 1.25;
            DefaultOverflow = TextTrimming.CharacterEllipsis;
        }

        protected string _Label { get; set; }

        /// <summary>
        /// The string displayed by this Text. Null is accepted and treated as an empty string.
        /// </summary>
        public string Label
        {
            get { return _Label; }
            set
            {
                string L = value == null ? "" : value;
                if (_Label != L)
                {
                    _Label = L;
                    Draw();
                }
            }
        }

        protected FontFamily _FontFamily { get; set; }

        /// <summary>
        /// The font family used to display this Text.
        /// </summary>
        public FontFamily FontFamily
        {
            get { return _FontFamily; }
            set
            {
                if (_FontFamily != value)
                {
                    _FontFamily = value;
                    Draw();
                }
            }
        }

        protected double _FontSize { get; set; }

        /// <summary>
        /// The font size used to display this Text.
        /// </summary>
        public double FontSize
        {
            get { return _FontSize; }
            set
            {
                if (_FontSize != value)
                {
                    _FontSize = value;
                    Draw();
                }
            }
        }

        protected FontWeight _FontWeight { get; set; }

        /// <summary>
        /// The font weight (e.g. normal or bold) used to display this Text.
        /// </summary>
        public FontWeight FontWeight
        {
            get { return _FontWeight; }
            set
            {
                if (_FontWeight != value)
                {
                    _FontWeight = value;
                    Draw();
                }
            }
        }

        protected FontStyle _FontStyle { get; set; }

        /// <summary>
        /// The font style (e.g. normal or italic) used to display this Text.
        /// </summary>
        public FontStyle FontStyle
        {
            get { return _FontStyle; }
            set
            {
                if (_FontStyle != value)
                {
                    _FontStyle = value;
                    Draw();
                }
            }
        }

        protected Brush _Fill { get; set; }

        /// <summary>
        /// The fill applied when displaying this Text.
        /// </summary>
        public Brush Fill
        {
            get { return _Fill; }
            set
            {
                if (_Fill != value)
                {
                    _Fill = value;
                    _Fill.Freeze();
                    Draw();
                }
            }
        }

        protected Brush _Background { get; set; }

        /// <summary>
        /// The Brush used to fill the background of this Text.
        /// </summary>
        public Brush Background
        {
            get { return _Background; }
            set
            {
                if (_Background != value)
                {
                    _Background = value;
                    if (_Background != null)
                    {
                        _Background.Freeze();
                    }
                    Draw();
                }
            }
        }

        protected Point _Location { get; set; }

        /// <summary>
        /// Specifies the top left corner of the displayed Text.
        /// </summary>
        public Point Location
        {
            get { return _Location; }
            set
            {
                if (_Location != value)
                {
                    _Location = value;
                    Draw();
                }
            }
        }

        protected Size _Size { get; set; }

        /// <summary>
        /// Specifies the max. width and height of the area occupied by this Text. Lines longer than Size.Width are broken into multiple lines. Lines overflowing Size.Height are not shown. Set Size.Width to zero to disable line wrapping and automatically calculate the width based on the longest line. Set Size.Height to zero to automatically calculate the height based on the line height and the number of lines.
        /// </summary>
        public Size Size
        {
            get { return _Size; }
            set
            {
                if (_Size != value)
                {
                    _Size = value;
                    Draw();
                }
            }
        }

        protected double _LineHeight { get; set; }

        /// <summary>
        /// The line height used to display this Text in relation to the font size. 1 = single, 2 = double, etc.
        /// </summary>
        public double LineHeight
        {
            get { return _LineHeight; }
            set
            {
                if (_LineHeight != value)
                {
                    _LineHeight = value;
                    Draw();
                }
            }
        }

        protected TextAlignment _TextAlignment { get; set; }

        /// <summary>
        /// The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.
        /// </summary>
        public TextAlignment TextAlignment
        {
            get { return _TextAlignment; }
            set
            {
                if (_TextAlignment != value)
                {
                    _TextAlignment = value;
                    Draw();
                }
            }
        }

        protected TextTrimming _Overflow { get; set; }

        /// <summary>
        /// Specifies the method used to trim lines that overflow the bounding area of this Text. Used only if either Size.Width or Size.Height is not zero.
        /// </summary>
        public TextTrimming Overflow
        {
            get { return _Overflow; }
            set
            {
                if (_Overflow != value)
                {
                    _Overflow = value;
                    Draw();
                }
            }
        }

        /// <summary>
        /// Returns the actual bounds of the rectangle occupied by this Text.
        /// </summary>
        /*public double Bounds
        {

        }*/

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        public Text(Canvas.Canvas Canvas, string Label, Point Location) :
            this(Canvas, Label, DefaultFontSize, Location) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="Size">Specifies the max. width and height of the area occupied by this Text. Lines longer than Size.Width are broken into multiple lines. Lines overflowing Size.Height are not shown. Set Size.Width to zero to disable line wrapping and automatically calculate the width based on the longest line. Set Size.Height to zero to automatically calculate the height based on the line height and the number of lines.</param>
        public Text(Canvas.Canvas Canvas, string Label, Point Location, Size Size) :
            this(Canvas, Label, DefaultFontSize, Location, Size) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="TextAlignment">The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.</param>
        public Text(Canvas.Canvas Canvas, string Label, Point Location, TextAlignment TextAlignment) :
            this(Canvas, Label, DefaultFontSize, Location, TextAlignment) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="Size">Specifies the max. width and height of the area occupied by this Text. Lines longer than Size.Width are broken into multiple lines. Lines overflowing Size.Height are not shown. Set Size.Width to zero to disable line wrapping and automatically calculate the width based on the longest line. Set Size.Height to zero to automatically calculate the height based on the line height and the number of lines.</param>
        /// <param name="TextAlignment">The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.</param>
        public Text(Canvas.Canvas Canvas, string Label, Point Location, Size Size, TextAlignment TextAlignment) :
            this(Canvas, Label, DefaultFontSize, Location, Size, TextAlignment) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        public Text(Canvas.Canvas Canvas, string Label, double FontSize, Point Location) :
            this(Canvas, Label, FontSize, DefaultFill, DefaultBackground, Location) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="Size">Specifies the max. width and height of the area occupied by this Text. Lines longer than Size.Width are broken into multiple lines. Lines overflowing Size.Height are not shown. Set Size.Width to zero to disable line wrapping and automatically calculate the width based on the longest line. Set Size.Height to zero to automatically calculate the height based on the line height and the number of lines.</param>
        public Text(Canvas.Canvas Canvas, string Label, double FontSize, Point Location, Size Size) :
            this(Canvas, Label, FontSize, DefaultFill, DefaultBackground, Location, Size) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="TextAlignment">The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.</param>
        public Text(Canvas.Canvas Canvas, string Label, double FontSize, Point Location, TextAlignment TextAlignment) :
            this(Canvas, Label, FontSize, DefaultFill, DefaultBackground, Location, TextAlignment) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="Size">Specifies the max. width and height of the area occupied by this Text. Lines longer than Size.Width are broken into multiple lines. Lines overflowing Size.Height are not shown. Set Size.Width to zero to disable line wrapping and automatically calculate the width based on the longest line. Set Size.Height to zero to automatically calculate the height based on the line height and the number of lines.</param>
        /// <param name="TextAlignment">The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.</param>
        public Text(Canvas.Canvas Canvas, string Label, double FontSize, Point Location, Size Size, TextAlignment TextAlignment) :
            this(Canvas, Label, FontSize, DefaultFill, DefaultBackground, Location, Size, TextAlignment) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        public Text(Canvas.Canvas Canvas, string Label, double FontSize, Brush Fill, Brush Background, Point Location) :
            this(Canvas, Label, FontSize, DefaultFontWeight, DefaultFontStyle, Fill, Background, Location) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="Size">Specifies the max. width and height of the area occupied by this Text. Lines longer than Size.Width are broken into multiple lines. Lines overflowing Size.Height are not shown. Set Size.Width to zero to disable line wrapping and automatically calculate the width based on the longest line. Set Size.Height to zero to automatically calculate the height based on the line height and the number of lines.</param>
        public Text(Canvas.Canvas Canvas, string Label, double FontSize, Brush Fill, Brush Background, Point Location, Size Size) :
            this(Canvas, Label, FontSize, DefaultFontWeight, DefaultFontStyle, Fill, Background, Location, Size) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="TextAlignment">The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.</param>
        public Text(Canvas.Canvas Canvas, string Label, double FontSize, Brush Fill, Brush Background, Point Location, TextAlignment TextAlignment) :
            this(Canvas, Label, FontSize, DefaultFontWeight, DefaultFontStyle, Fill, Background, Location, TextAlignment) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="Size">Specifies the max. width and height of the area occupied by this Text. Lines longer than Size.Width are broken into multiple lines. Lines overflowing Size.Height are not shown. Set Size.Width to zero to disable line wrapping and automatically calculate the width based on the longest line. Set Size.Height to zero to automatically calculate the height based on the line height and the number of lines.</param>
        /// <param name="TextAlignment">The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.</param>
        public Text(Canvas.Canvas Canvas, string Label, double FontSize, Brush Fill, Brush Background, Point Location, Size Size, TextAlignment TextAlignment) :
            this(Canvas, Label, FontSize, DefaultFontWeight, DefaultFontStyle, Fill, Background, Location, Size, TextAlignment) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="FontWeight">The font weight (e.g. normal or bold) used to display this Text.</param>
        /// <param name="FontStyle">The font style (e.g. normal or italic) used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        public Text(Canvas.Canvas Canvas, string Label, double FontSize, FontWeight FontWeight, FontStyle FontStyle, Brush Fill, Brush Background, Point Location) :
            this(Canvas, Label, DefaultFontFamily, FontSize, FontWeight, FontStyle, Fill, Background, Location) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="FontWeight">The font weight (e.g. normal or bold) used to display this Text.</param>
        /// <param name="FontStyle">The font style (e.g. normal or italic) used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="Size">Specifies the max. width and height of the area occupied by this Text. Lines longer than Size.Width are broken into multiple lines. Lines overflowing Size.Height are not shown. Set Size.Width to zero to disable line wrapping and automatically calculate the width based on the longest line. Set Size.Height to zero to automatically calculate the height based on the line height and the number of lines.</param>
        public Text(Canvas.Canvas Canvas, string Label, double FontSize, FontWeight FontWeight, FontStyle FontStyle, Brush Fill, Brush Background, Point Location, Size Size) :
            this(Canvas, Label, DefaultFontFamily, FontSize, FontWeight, FontStyle, Fill, Background, Location, Size) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="FontWeight">The font weight (e.g. normal or bold) used to display this Text.</param>
        /// <param name="FontStyle">The font style (e.g. normal or italic) used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="TextAlignment">The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.</param>
        public Text(Canvas.Canvas Canvas, string Label, double FontSize, FontWeight FontWeight, FontStyle FontStyle, Brush Fill, Brush Background, Point Location, TextAlignment TextAlignment) :
            this(Canvas, Label, DefaultFontFamily, FontSize, FontWeight, FontStyle, Fill, Background, Location, TextAlignment) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="FontWeight">The font weight (e.g. normal or bold) used to display this Text.</param>
        /// <param name="FontStyle">The font style (e.g. normal or italic) used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="Size">Specifies the max. width and height of the area occupied by this Text. Lines longer than Size.Width are broken into multiple lines. Lines overflowing Size.Height are not shown. Set Size.Width to zero to disable line wrapping and automatically calculate the width based on the longest line. Set Size.Height to zero to automatically calculate the height based on the line height and the number of lines.</param>
        /// <param name="TextAlignment">The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.</param>
        public Text(Canvas.Canvas Canvas, string Label, double FontSize, FontWeight FontWeight, FontStyle FontStyle, Brush Fill, Brush Background, Point Location, Size Size, TextAlignment TextAlignment) :
            this(Canvas, Label, DefaultFontFamily, FontSize, FontWeight, FontStyle, Fill, Background, Location, Size, TextAlignment) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontFamily">The font family used to display this Text.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="FontWeight">The font weight (e.g. normal or bold) used to display this Text.</param>
        /// <param name="FontStyle">The font style (e.g. normal or italic) used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        public Text(Canvas.Canvas Canvas, string Label, FontFamily FontFamily, double FontSize, FontWeight FontWeight, FontStyle FontStyle, Brush Fill, Brush Background, Point Location) :
            this(Canvas, Label, FontFamily, FontSize, FontWeight, FontStyle, Fill, Background, Location, DefaultTextAlignment) { }
        
        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontFamily">The font family used to display this Text.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="FontWeight">The font weight (e.g. normal or bold) used to display this Text.</param>
        /// <param name="FontStyle">The font style (e.g. normal or italic) used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="Size">Specifies the max. width and height of the area occupied by this Text. Lines longer than Size.Width are broken into multiple lines. Lines overflowing Size.Height are not shown. Set Size.Width to zero to disable line wrapping and automatically calculate the width based on the longest line. Set Size.Height to zero to automatically calculate the height based on the line height and the number of lines.</param>
        public Text(Canvas.Canvas Canvas, string Label, FontFamily FontFamily, double FontSize, FontWeight FontWeight, FontStyle FontStyle, Brush Fill, Brush Background, Point Location, Size Size) :
            this(Canvas, Label, FontFamily, FontSize, FontWeight, FontStyle, Fill, Background, Location, Size, DefaultTextAlignment) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontFamily">The font family used to display this Text.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="FontWeight">The font weight (e.g. normal or bold) used to display this Text.</param>
        /// <param name="FontStyle">The font style (e.g. normal or italic) used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="TextAlignment">The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.</param>
        public Text(Canvas.Canvas Canvas, string Label, FontFamily FontFamily, double FontSize, FontWeight FontWeight, FontStyle FontStyle, Brush Fill, Brush Background, Point Location, TextAlignment TextAlignment) :
            this(Canvas, Label, FontFamily, FontSize, FontWeight, FontStyle, Fill, Background, Location, TextAlignment, DefaultLineHeight, DefaultOverflow) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontFamily">The font family used to display this Text.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="FontWeight">The font weight (e.g. normal or bold) used to display this Text.</param>
        /// <param name="FontStyle">The font style (e.g. normal or italic) used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="Size">Specifies the max. width and height of the area occupied by this Text. Lines longer than Size.Width are broken into multiple lines. Lines overflowing Size.Height are not shown. Set Size.Width to zero to disable line wrapping and automatically calculate the width based on the longest line. Set Size.Height to zero to automatically calculate the height based on the line height and the number of lines.</param>
        /// <param name="TextAlignment">The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.</param>
        public Text(Canvas.Canvas Canvas, string Label, FontFamily FontFamily, double FontSize, FontWeight FontWeight, FontStyle FontStyle, Brush Fill, Brush Background, Point Location, Size Size, TextAlignment TextAlignment) :
            this(Canvas, Label, FontFamily, FontSize, FontWeight, FontStyle, Fill, Background, Location, Size, TextAlignment, DefaultLineHeight, DefaultOverflow) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontFamily">The font family used to display this Text.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="FontWeight">The font weight (e.g. normal or bold) used to display this Text.</param>
        /// <param name="FontStyle">The font style (e.g. normal or italic) used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="TextAlignment">The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.</param>
        /// <param name="LineHeight">The line height used to display this Text in relation to the font size. 1 = single, 2 = double, etc.</param>
        /// <param name="Overflow">Specifies the method used to trim lines that overflow the bounding area of this Text. Used only if either Size.Width or Size.Height is not zero.</param>
        public Text(Canvas.Canvas Canvas, string Label, FontFamily FontFamily, double FontSize, FontWeight FontWeight, FontStyle FontStyle, Brush Fill, Brush Background, Point Location, TextAlignment TextAlignment, double LineHeight, TextTrimming Overflow) :
            this(Canvas, Label, FontFamily, FontSize, FontWeight, FontStyle, Fill, Background, Location, new Size(0, 0), TextAlignment, LineHeight, Overflow) { }

        /// <summary>
        /// Creates and initializes this Text with the specified properties.
        /// </summary>
        /// <param name="Canvas">The Canvas this Text is displayed on.</param>
        /// <param name="Label">The string displayed by this Text. Null is accepted and treated as an empty string.</param>
        /// <param name="FontFamily">The font family used to display this Text.</param>
        /// <param name="FontSize">The font size used to display this Text.</param>
        /// <param name="FontWeight">The font weight (e.g. normal or bold) used to display this Text.</param>
        /// <param name="FontStyle">The font style (e.g. normal or italic) used to display this Text.</param>
        /// <param name="Fill">The fill applied when displaying this Text.</param>
        /// <param name="Background">The Brush used to fill the background of this Text.</param>
        /// <param name="Location">Specifies the top left corner of the displayed Text.</param>
        /// <param name="Size">Specifies the max. width and height of the area occupied by this Text. Lines longer than Size.Width are broken into multiple lines. Lines overflowing Size.Height are not shown. Set Size.Width to zero to disable line wrapping and automatically calculate the width based on the longest line. Set Size.Height to zero to automatically calculate the height based on the line height and the number of lines.</param>
        /// <param name="TextAlignment">The horizontal alignment of the text within its bounding area specified in the Size property. Used only if Size.Width is not zero.</param>
        /// <param name="LineHeight">The line height used to display this Text in relation to the font size. 1 = single, 2 = double, etc.</param>
        /// <param name="Overflow">Specifies the method used to trim lines that overflow the bounding area of this Text. Used only if either Size.Width or Size.Height is not zero.</param>
        public Text(Canvas.Canvas Canvas, string Label, FontFamily FontFamily, double FontSize, FontWeight FontWeight, FontStyle FontStyle, Brush Fill, Brush Background, Point Location, Size Size, TextAlignment TextAlignment, double LineHeight, TextTrimming Overflow)
            : base(Canvas)
        {
            _Label = Label == null ? "" : Label;
            _FontFamily = FontFamily;
            _FontSize = FontSize;
            _FontWeight = FontWeight;
            _FontStyle = FontStyle;
            _Fill = Fill;
            _Background = Background;
            _Location = Location;
            _Size = Size;
            _LineHeight = LineHeight;
            _TextAlignment = TextAlignment;
            _Overflow = Overflow;
            Fill.Freeze();
            Draw();
        }

        /// <summary>
        /// Updates the state of this Text.
        /// </summary>
        protected override void Update() { }

        /// <summary>
        /// Renders this Text to the screen.
        /// </summary>
        protected virtual void Draw()
        {
            using (DrawingContext Context = RenderOpen())
            {
                FormattedText Text = new FormattedText(Label, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface(FontFamily, FontStyle, FontWeight, FontStretches.Normal), FontSize, Fill);
                if (Size.Width > 0)
                {
                    Text.MaxTextWidth = Size.Width;
                    Text.TextAlignment = TextAlignment;
                }
                if (Size.Height > 0)
                {
                    Text.MaxTextHeight = Size.Height;
                    Text.Trimming = Overflow;
                }
                Text.LineHeight = LineHeight * FontSize;

                if (Background != null)
                {
                    Context.DrawRectangle(Background, null, new Rect(Location, new Size(Size.Width > 0 ? Text.MaxTextWidth : Text.Width, Size.Height > 0 ? Text.MaxTextHeight : Text.Height)));
                }

                Context.DrawText(Text, Location);
            }
        }
    }
}