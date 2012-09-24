using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ZatackaLegacy
{
    public class Engine : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager Graphics;

        SpriteBatch SpriteBatch;
        SpriteFont Font;

        public Engine()
        {
            Graphics = new GraphicsDeviceManager(this);

            Graphics.IsFullScreen = true;
            Graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            Graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("Prophit");
        }

        protected override void Update(GameTime Time)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) || GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            base.Update(Time);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, Matrix.CreateScale((float)GraphicsDevice.Viewport.Width / 1280.0f, (float)GraphicsDevice.Viewport.Height / 720.0f, 1.0f));
            SpriteBatch.DrawString(Font, "Welcome to Zatacka Legacy", new Vector2(500.0f, 500.0f), Color.White);
            SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}