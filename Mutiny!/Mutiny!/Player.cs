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
    //to-do: behöver en update och en draw metod, behöver en textur, position, etc
    class Player
    {
        Vector2 pos;
        Vector2 speed;
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



        public Player (Texture2D tex, Vector2 pos, SpriteFont spriteFont)
        {
            this.pos = pos;
            this.tex = tex;
            speed = new Vector2(0, 0);
            this.spriteFont = spriteFont;
            facing = Facing.Down;
        }
        public void Update (KeyboardState currentKeyboardState, KeyboardState oldKeyboardState)
        {
            PlayerInput(currentKeyboardState, oldKeyboardState);

            pos += speed;
        }
        public void Draw (SpriteBatch sb)
        {
            sb.Draw(tex, pos, Color.White);
            switch (facing)
            {
                case Facing.Down:
                    facingText = "down";
                    break;
                case Facing.Left:
                    facingText = "left";
                    break;
                case Facing.Right:
                    facingText = "right";
                    break;
                case Facing.Up:
                    facingText = "up";
                    break;
            }
            sb.DrawString(spriteFont, facingText, pos, Color.White);
        }
        private void PlayerInput(KeyboardState currentKeyboardState, KeyboardState oldKeyboardState)
        {
            if (currentKeyboardState.IsKeyDown(Keys.Left) && !currentKeyboardState.IsKeyDown(Keys.Right))
            {
                speed.X = -1;
                facing = Facing.Left;
                walkingHorizontally = true;
            }
            else if (currentKeyboardState.IsKeyDown(Keys.Right) && !currentKeyboardState.IsKeyDown(Keys.Left))
            {
                speed.X = 1;
                facing = Facing.Right;
                walkingHorizontally = true;
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
            }
            else if (currentKeyboardState.IsKeyDown(Keys.Down) && !currentKeyboardState.IsKeyDown(Keys.Up))
            {
                speed.Y = 1;
                if (!walkingHorizontally)
                {
                    facing = Facing.Down;
                }
            }
            else
            {
                speed.Y = 0;
            }
        }
    }
}
