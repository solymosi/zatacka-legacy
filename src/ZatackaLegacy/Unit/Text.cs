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
        protected string _Label { get; set; }

        public string Label
        {
            get { return _Label; }
            set
            {
                _Label = value;
                Draw();
            }
        }

        protected double _Size { get; set; }

        public double Size
        {
            get { return _Size; }
            set
            {
                _Size = value;
                Draw();
            }
        }

        protected Rect _Bounds { get; set; }

        public Rect Bounds
        {
            get { return _Bounds; }
            set
            {
                _Bounds = value;
                Draw();
            }
        }

        protected AlignmentX _HorizontalAlignment { get; set; }

        public AlignmentX HorizontalAlignment
        {
            get { return _HorizontalAlignment; }
            set
            {
                _HorizontalAlignment = value;
                Draw();
            }
        }

        protected AlignmentY _VerticalAlignment { get; set; }

        public AlignmentY VerticalAlignment
        {
            get { return _VerticalAlignment; }
            set
            {
                _VerticalAlignment = value;
                Draw();
            }
        }

        public Text(Canvas.Canvas Canvas, string Label, double Size, Rect Bounds)
            : base(Canvas)
        {
            _Label = Label;
            _Size = Size;
            _Bounds = Bounds;
            Draw();
        }

        protected override void Update() { }

        protected void Draw()
        {
            using (DrawingContext Context = RenderOpen())
            {
                Context.DrawText(new FormattedText(Label, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, new Typeface(new FontFamily("Open Sans"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal), Size, Brushes.White), Bounds.Location);
                //Context.DrawText(new FormattedText(Label, CultureInfo.InvariantCulture, FlowDirection.LeftToRight, Font, Bounds, Fill), Location);
            }
        }
    }
}
