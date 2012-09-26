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
            SetupUI();
            SetupGame();
        }

        private void SetupGame()
        {
            Game = new StandardGame(new Pool(new Size(Width, Height)));
            Game.Players.Add(new Player(Keys.D1, Keys.Q, Keys.D2));
            Game.Players.Add(new Player(Keys.LButton, Keys.RButton, Keys.MButton));
            Game.Initialize();
        }

        private void SetupUI()
        {
            Top = 0;
            Left = 0;
            Width = SystemInformation.VirtualScreen.Width;
            Height = SystemInformation.VirtualScreen.Height;
            WindowState = FormWindowState.Maximized;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Cursor.Hide();
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
            Game.Pool.Draw(GFX);
        }
    }
}