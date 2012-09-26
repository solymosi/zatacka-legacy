using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ZatackaLegacy
{
    public partial class GameForm : Form
    {
        public Game Game;
        public Timer Timer;

        public List<string> DebugMessages = new List<string>();

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys Key);

        public GameForm()
        {
            InitializeComponent();
            SetupUI();
            SetupGame();
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

        private void SetupGame()
        {
            Game = new StandardGame(new Pool(new Size(Width, Height)));
            new Player(Game, new Keys[] { Keys.D1, Keys.Q, Keys.D2 }, Color.Red);
            new Player(Game, new Keys[] { Keys.LButton, Keys.RButton, Keys.MButton }, Color.Green);
            Game.Initialize();

            Timer = new Timer();
            Timer.Interval = 20;
            Timer.Enabled = true;
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();
        }

        public void Print(string Message)
        {
            if (DebugMessages.Count > 20) { DebugMessages.RemoveAt(0); }
            DebugMessages.Add(Message);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Player P in Game.Players)
            {
                foreach (KeyValuePair<Action, Keys> Item in P.Buttons)
                {
                    if (GetAsyncKeyState(Item.Value) != 0)
                    {
                        Game.Input(P, Item.Key);
                    }
                }
            }

            Game.Tick();
            Refresh();
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


            if (DebugMessages.Count > 0)
            {
                string Message = "";
                foreach (string M in DebugMessages)
                {
                    Message += M + "\r\n";
                }
                GFX.DrawString(Message, new Font(FontFamily.GenericMonospace, 10), Brushes.White, new PointF(10, 10));
            }
        }
    }
}