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
    class WheelCactus : Enemy
    {
        //Skapad och grundlagd av Sara inklusive simple art
        Point pos;
        Rectangle sourceRect;
        Rectangle destRect;

        public WheelCactus(Texture2D tex, Point startPos)
        {
            this.tex = tex;
            pos = startPos;
            sourceRect = new Rectangle(0, 0, tex.Width, tex.Height);
            destRect = new Rectangle(pos.X - (sourceRect.Width/2), pos.Y - (sourceRect.Height/2), sourceRect.Width, sourceRect.Height);
            hitbox = destRect;
        }
        public override void Update()
        {
            destRect = new Rectangle(pos.X - (sourceRect.Width / 2), pos.Y - (sourceRect.Height / 2), sourceRect.Width, sourceRect.Height);
            hitbox = destRect;
            hurtbox = hitbox;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, destRect, sourceRect, Color.White);
        }
        public override void GetHurt()
        {
            pos.X = 1000;
            pos.Y = 1000;
        }
    }
}
