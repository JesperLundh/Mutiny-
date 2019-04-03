using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mutiny_
{
    //Skapad av Jesper. Kod för att röra på sig och hantera facing skriven av Sara
    //Animation fixad av Sara
    class Player
    {
        Point pos;
        Rectangle destRect;
        Rectangle sourceRect;
        double frameTimer;
        double frameInterval;
        Point speed;
        Texture2D tex;
        SpriteFont spriteFont;
        enum Facing
        {
            Up,
            Down,
            Left,
            Right
        }
        Facing facing;
        string facingText = "none";
        bool walkingHorizontally = false;
        bool walkingAtAll = false;


        public Player (Texture2D tex, Point pos, SpriteFont spriteFont)
        {
            this.pos = pos;
            destRect = new Rectangle(pos.X, pos.Y, 100, 150);
            sourceRect = new Rectangle(0, 0, 100, 150);
            this.tex = tex;
            speed = new Point(0, 0);
            this.spriteFont = spriteFont;
            facing = Facing.Down;
            frameInterval = 500;
            frameTimer = frameInterval;
        }
        public void Update (KeyboardState currentKeyboardState, KeyboardState oldKeyboardState, GameTime gameTime)
        {
            PlayerInput(currentKeyboardState, oldKeyboardState);
            frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            Animate();
            pos += speed;
            destRect.X = pos.X - (destRect.Width/2);
            destRect.Y = pos.Y - (destRect.Height/2);
        }
        public void Draw (SpriteBatch sb)
        {
            sb.Draw(tex, destRect, sourceRect, Color.White);
            switch (facing)
            {
                case Facing.Down:
                    facingText = "down";
                    sourceRect.Y = 0;
                    break;
                case Facing.Left:
                    facingText = "left";
                    sourceRect.Y = 450;
                    break;
                case Facing.Right:
                    facingText = "right";
                    sourceRect.Y = 300;
                    break;
                case Facing.Up:
                    facingText = "up";
                    sourceRect.Y = 150;
                    break;
            }
            sb.DrawString(spriteFont, facingText, new Vector2(pos.X, pos.Y), Color.White);
        }
        private void PlayerInput(KeyboardState currentKeyboardState, KeyboardState oldKeyboardState)
        {
            walkingAtAll = false;
            if (currentKeyboardState.IsKeyDown(Keys.Left) && !currentKeyboardState.IsKeyDown(Keys.Right))
            {
                speed.X = -1;
                facing = Facing.Left;
                walkingHorizontally = true;
                walkingAtAll = true;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.Right) && !currentKeyboardState.IsKeyDown(Keys.Left))
            {
                speed.X = 1;
                facing = Facing.Right;
                walkingHorizontally = true;
                walkingAtAll = true;
            }
            else
            {
                speed.X = 0;
                walkingHorizontally = false;
            }
            if (currentKeyboardState.IsKeyDown(Keys.Up) && !currentKeyboardState.IsKeyDown(Keys.Down))
            {
                speed.Y = -1;
                if (!walkingHorizontally)
                {
                    facing = Facing.Up;
                }
                walkingAtAll = true;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.Down) && !currentKeyboardState.IsKeyDown(Keys.Up))
            {
                speed.Y = 1;
                if (!walkingHorizontally)
                {
                    facing = Facing.Down;
                }
                walkingAtAll = true;
            }
            else
            {
                speed.Y = 0;

            }
        }
        private void Animate()
        {
            if (!walkingAtAll)
            {
                sourceRect.X = 0;
            }
            else if (frameTimer <= 0)
            {
                sourceRect.X += sourceRect.Width;
                frameTimer = frameInterval;
            }
            if (sourceRect.X > 200)
            {
                sourceRect.X = sourceRect.Width;
            }
        }
    }
}
