using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace ZatackaLegacy.Unit
{
    class TestUnit : Unit
    {
        public TestUnit(Game Game)
            : base(Game)
        {
            
        }

        public override void Draw(long Lifetime)
        {
            using (DrawingContext DC = RenderOpen())
            {
                DC.DrawText(new FormattedText("HELLOOOOO!", System.Globalization.CultureInfo.CurrentCulture, System.Windows.FlowDirection.LeftToRight, new Typeface("Arial Black"), 100, new SolidColorBrush(Color.FromRgb((byte)Tools.Random(200, 255), (byte)Tools.Random(200, 255), (byte)Tools.Random(200, 255)))), new System.Windows.Point(100, 100));
            }
        }
    }
}
