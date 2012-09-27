using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZatackaLegacy
{
    public partial class GameCanvas : Canvas
    {
        public GameCanvas()
        {
            InitializeComponent();
        }

        public Game Game;

        protected override void OnRender(DrawingContext Context)
        {
            if (Game != null)
            {
                Game.Pool.Render(Context);
            }
            base.OnRender(Context);
        }
    }
}
