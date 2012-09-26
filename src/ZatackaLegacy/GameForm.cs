using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZatackaLegacy
{
    public partial class GameForm : Form
    {
        public Game Game;

        public GameForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Cursor.Hide();

            SetupGame();
        }

        private void SetupGame()
        {
            Game = new StandardGame(new Options(), new Pool(new Size(Width, Height)));   
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                return;
            }
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics GFX = e.Graphics;

            GFX.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            GFX.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            GFX.Clear(Color.Black);
            GFX.DrawEllipse(new Pen(Brushes.Yellow, 10), new Rectangle(50, 50, 100, 100));
        }
    }
}
